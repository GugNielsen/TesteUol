using System;
using System.Collections.Generic;
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



        public TempoViewModel(INavigationService navigationService) : base(navigationService)
        {
            //WeatherData();
            _ForecastIORequest = new ForecastIORequest("8cdfe5016e2c5632b2f1e060380b873a",37.8267,-122.4233,Unit.us,Language.pt);
            _taskInit = TaskInit();
        }

    
        private async Task TaskInit()
        {
            await ApiLoad();
        }

        private async Task ApiLoad()
        {
             Tempo =  _ForecastIORequest.Get();
              Currently= Tempo.currently;
              Daily= Tempo.daily;
              Minutely= Tempo.minutely;
              Hourly = Tempo.hourly;
        } 

    }
}

