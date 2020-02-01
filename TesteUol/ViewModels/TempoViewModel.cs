using System;
using System.Collections.Generic;
using Prism.Navigation;
using TesteUol.MockModel;

namespace TesteUol.ViewModels
{
    public class TempoViewModel : ViewModelBase
    {
        public TempoViewModel(INavigationService navigationService) : base(navigationService)
        {
            WeatherData();
        }

        #region Lista Mock
        public List<Clima> Weathers { get => WeatherData(); }

        private List<Clima> WeatherData()
        {
            var tempList = new List<Clima>();
            tempList.Add(new Clima { Temp = "22", Date = "Sunday 16", Icon = "weather.png" });
            tempList.Add(new Clima { Temp = "21", Date = "Monday 17", Icon = "weather.png" });
            tempList.Add(new Clima { Temp = "20", Date = "Tuesday 18", Icon = "weather.png" });
            tempList.Add(new Clima { Temp = "12", Date = "Wednesday 19", Icon = "weather.png" });
            tempList.Add(new Clima { Temp = "17", Date = "Thursday 20", Icon = "weather.png" });
            tempList.Add(new Clima { Temp = "20", Date = "Friday 21", Icon = "weather.png" });

            return tempList;
        }

        #endregion



        #region Prop
        //private string _visiteeCorpLogoUrl = Settings.DefaultCoacheeLogoImg;
        //public string VisiteeCorpLogoUrl
        //{
        //    get { return _visiteeCorpLogoUrl; }
        //    set { SetProperty(ref _visiteeCorpLogoUrl, value); }
        //}

        #endregion
    }
}

