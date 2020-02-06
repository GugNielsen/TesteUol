using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Plugin.ExternalMaps;
using Prism.Commands;
using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using TesteUol.Entities;
using TesteUol.Helpers;
using TesteUol.Services;
using TesteUol.Views;
using Xamarin.Essentials;

namespace TesteUol.ViewModels
{
    public class TempoViewModel : ViewModelBase
    {
       ForecastIORequest _ForecastIORequest;
        Unit Unit;
        Language Language;

        #region Propriedades

        private ForecastIOResponse _tempo;
        public ForecastIOResponse Tempo
        {
            get { return _tempo; }
            set { SetProperty(ref _tempo, value); }
        }

        private Currently _currently;
        public Currently Currently
        {
            get { return _currently; }
            set { SetProperty(ref _currently, value); }
        }


        private Daily _daily;
        public Daily Daily
        {
            get { return _daily; }
            set { SetProperty(ref _daily, value); }
        }


        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }


        private string _city;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }


        private ObservableCollection<DailyForecast> _dailyForecast;
        public ObservableCollection<DailyForecast> DailyForecast
        {
            get { return _dailyForecast; }
            set { SetProperty(ref _dailyForecast, value); }
        }

        #endregion

        #region Latitude e Loginditude da Geo Localização
        public double LatitudeGeolocalizacao { get; set; }

        public double LongitudeGeolocalizacao  { get; set; }

        #endregion

        #region Latitude e Loginditude da Geo Localização
        public double LatitudeGeocodificacao { get; set; }

        public double LongitudeGeocodificacao { get; set; }

        #endregion

        public TempoViewModel(INavigationService navigationService) : base(navigationService)
        {
            _taskInit = TaskInit();
        }

        private async Task TaskInit()
        {

            await LoadGeolocation();
            await LoadApi();
            await ApiDados();
            await LoadListDailyForecas();
        }

        #region ApiDados e Carregar Imagem Anida

        /// <summary>
        /// LoadApi
        /// </summary>
        /// <returns></returns>
        private async Task LoadApi()
        {

            _ForecastIORequest = new ForecastIORequest(AppConstants.Apikey, LatitudeGeolocalizacao, LongitudeGeolocalizacao, Unit.si, Language.pt);

        }
        /// <summary>
        /// ApiDados
        /// </summary>
        /// <returns></returns>
        private async Task ApiDados()
        {
            Tempo = _ForecastIORequest.Get();
            Currently = Tempo.currently;
            Daily = Tempo.daily;

            // Converter data
            Date = Extensions.ToDateTime(Currently.time);

            // Carregar Imagem
            LoadImageAnimada();

        }
        /// <summary>
        /// LoadImageAnimada
        /// </summary>
        private void LoadImageAnimada()
        {
            // Pegar a Imagem Aminada de Acordo Com Summary
            // Explicando Para economizar tempo eu fiz deste jeito e logico que fosse MultiIdiomas faria de outra Maneira 
            if (Currently.summary.Contains("sol") || Currently.summary.Contains("Sol"))
            {
                Currently.icon = "sum.json";

            }
            else if (Currently.summary.Contains("nublado") || Currently.summary.Contains("Nublado"))
            {
                Currently.icon = "nublado.json";
            }
            else if (Currently.summary.Contains("Chuva") || Currently.summary.Contains("chuva") || Currently.summary.Contains("temporal") || Currently.summary.Contains("temporal"))
            {
                Currently.icon = "chuva.json";
            }
            else
            {
                Currently.icon = "sum.json";
            }
        }

        #endregion

        #region Carregar Lista e Geolocation
        /// <summary>
        /// /LoadListDailyForecas
        /// </summary>
        /// <returns></returns>
        private async Task LoadListDailyForecas()
        {
            try
            {
                // Array.Remove(Daily.data, 0);
                Daily.data.RemoveAt(0);
                foreach (var item in Daily.data)
                {
                    item.date = Extensions.ToDateTime(item.time);
                    item.celsiu = Extensions.ConvertCelsius(item.temperatureMax);

                    // Pegar a Imagem de Acordo Com Summary
                    // Explicando Para economizar tempo eu fiz deste jeito e logico que fosse MultiIdiomas faria de outra Maneira 
                    if (item.summary.Contains("sol"))
                    {
                        item.icon = "sol.png";
                    }
                    else if (item.summary.Contains("nublado"))
                    {
                        item.icon = "nublado.png";
                    }
                    else if (item.summary.Contains("chuva"))
                    {
                        item.icon = "chuva.png";
                    }
                    else
                    {
                        item.icon = "sol.png";
                    }
                }

            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }

        }

        /// <summary>
        /// Pegar Geo Localização Testando 
        /// </summary>
        /// <returns></returns>
        private async Task LoadGeolocation()
        {
            try
            {
                var localizacao = await Geolocation.GetLastKnownLocationAsync();
                if (localizacao != null)
                {
                    LatitudeGeolocalizacao = localizacao.Latitude;
                    LongitudeGeolocalizacao = localizacao.Longitude;

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Recurso não suportado no device
                var g = ("Erro ", fnsEx.Message, "Ok");
            }
            catch (PermissionException pEx)
            {
                // Tratando erro de permissão
                var g = ("Erro: ", pEx.Message, "Ok");
            }
            catch (Exception ex)
            {
                // Não foi possivel obter localização
                var g = ("Erro : ", ex.Message, "Ok");
            }

        }
        #endregion

        #region Commands e Metedos
        private DelegateCommand<DailyForecast> _detailClimaCommand;         public DelegateCommand<DailyForecast> DetailsClimaCommand => _detailClimaCommand ?? (_detailClimaCommand = new DelegateCommand<DailyForecast>(async (item) => await DetailsClimaAsync(item)));
        /// <summary>
        /// DetailsClimaAsync
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private async Task DetailsClimaAsync(DailyForecast item)
        {
            await PopupNavigation.Instance.PushAsync(new DetailsClimaPage(item));

        }

        private DelegateCommand<string> _mudarCidadeCommand;         public DelegateCommand<string> MudarCidadeCommand => _mudarCidadeCommand ?? (_mudarCidadeCommand = new DelegateCommand<string>(async (item) => await MudarCidadeAsync(item)));
        /// <summary>
        /// MudarCidadeAsync
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        private async Task MudarCidadeAsync(string city)
        {
            try
            {
                if (city == null)
                {
                    return;
                }
                // Passando Variavel para verdadeira
                // para Setar Api
                // Devido a Falta de tempo Infelizmente não deu para Fazer melhor
                //Porem queria mostra conhecimento que sei fazer. Pegar a Geocodificação 
                // IsGeocodificacao = true;
                var locations = await Geocoding.GetLocationsAsync(city);
                var location = locations?.FirstOrDefault();
                if (location != null)
                {
                    LatitudeGeocodificacao = location.Latitude;
                    LongitudeGeolocalizacao = location.Longitude;
                    await PopupNavigation.Instance.PushAsync(new CidadesPage(LatitudeGeocodificacao, LongitudeGeolocalizacao));
                }

            }
            catch (Exception ex)
            {
                var b = ex.Message;
            }
        }
        #endregion

    }
}

