using System;
using System.Threading.Tasks;
using TesteUol.Entities;
using TesteUol.Helpers;

namespace TesteUol.ViewModels
{
    public class CidadesPagesViewModel : ViewModelBase
    {
        ForecastIORequest _ForecastIORequest;
        #region Propeidades
        public double Latitude { get; set; }

        public double Longitude { get; set; }

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


        #endregion
       
        public CidadesPagesViewModel(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;

            _taskInit = TaskInit();
        }

        private async Task TaskInit()
        {
            LoadApi();
            await ApiDados();
            await LoadListDailyForecas();
        }

        #region Carregando a logica Desta ViewModel

        /// <summary>
        /// Carregar Api
        /// </summary>
        private void LoadApi()
        {
            _ForecastIORequest = new ForecastIORequest(AppConstants.Apikey2, Latitude, Longitude, Unit.si, Language.pt);
        }

        /// <summary>
        /// Carregando Os Dados
        /// </summary>
        /// <returns></returns>
        private async Task ApiDados()
        {
            Tempo = _ForecastIORequest.Get();
            Currently = Tempo.currently;
            Daily = Tempo.daily;

            // Converter data
            Date = Extensions.ToDateTime(Currently.time);

            LoadImageAnimada();

        }

        /// <summary>
        /// Carregar Imagem
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
                Currently.icon = "chivinha.json";
            }
            else
            {
                Currently.icon = "sum.json";
            }
        }

        /// <summary>
        /// Carregar Lista
        /// </summary>
        /// <returns></returns>
        private async Task LoadListDailyForecas()
        {
            try
            {
                // Array.Remove(Daily.data, 0);
                Daily.data.RemoveAt(7);
                foreach (var item in Daily.data)
                {
                    item.date = Extensions.ToDateTime(item.time);

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
        #endregion

    }
}
