using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using TesteUol.Entities;
using TesteUol.Helpers;
using TesteUol.Services;

namespace TesteUol.ViewModels
{
    public class TempoViewModel : ViewModelBase
    {
       
       ForecastIORequest _ForecastIORequest;
        Unit Unit;
        Language Language;

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

        private Minutely _minutely;
        public Minutely Minutely
        {
            get { return _minutely; }
            set { SetProperty(ref _minutely, value); }
        }

        private Hourly _houly;
        public Hourly Hourly
        {
            get { return _houly; }
            set { SetProperty(ref _houly, value); }
        }
        private string _cTemp;
        public string CTemp
        {
            get { return _cTemp; }
            set { SetProperty(ref _cTemp, value); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private ObservableCollection<DailyForecast> _dailyForecast;
        public ObservableCollection<DailyForecast> DailyForecast
        {
            get { return _dailyForecast; }
            set { SetProperty(ref _dailyForecast, value); }
        }


        public TempoViewModel(INavigationService navigationService) : base(navigationService)
        {
            //WeatherData();
            _ForecastIORequest = new ForecastIORequest("8cdfe5016e2c5632b2f1e060380b873a",-22.9056075,-43.1167342, Unit.us,Language.pt);
            _taskInit = TaskInit();
        }

    
        private async Task TaskInit()
        {
            await ApiLoad();
            await LoadListDailyForecas();
        }

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
                    else if ((item.summary.Contains("nublado")))
                    {
                        item.icon = "nublado.png";
                    }
                    else
                    {
                        item.icon = "chuva.png";
                    }

                   
                }
                
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
           
        }

        private async Task ApiLoad()
        {
             Tempo =  _ForecastIORequest.Get();
              Currently= Tempo.currently;
              Daily= Tempo.daily;
              Minutely= Tempo.minutely;
              Hourly = Tempo.hourly;


            // Converter data
            Date = Extensions.ToDateTime(Currently.time);
            // Converter para Celsius
            CTemp =  Extensions.ConvertCelsius(Currently.temperature);

            LoadImageAnimada();

        }

        private void LoadImageAnimada()
        {
            // Pegar a Imagem Aminada de Acordo Com Summary
            // Explicando Para economizar tempo eu fiz deste jeito e logico que fosse MultiIdiomas faria de outra Maneira 
            if (Currently.summary.Contains("sol"))
            {
                Currently.icon = "sum.json";
            }
            else if ((Currently.summary.Contains("nublado")))
            {
                Currently.icon = "nublado.json";
            }
            else
            {
                Currently.icon = "chuva.json";
            }
        }
    }
}

