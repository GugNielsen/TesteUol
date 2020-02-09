using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using TesteUol.Abstractions;
using TesteUol.ViewModels;
using Xamanimation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteUol.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsClimaPage : IAnimatedView
    {
        public DetailsClimaPage(Entities.DailyForecast item)
        {
            var vm = new DetailsClimaViewModel(item);
            BindingContext = vm;
            InitializeComponent();
        }

        public void StartAnimation()
        {
            if (Resources["InfoPanelAnimation"] is StoryBoard animation)
            {
                animation.Begin();
            }
        }

        //public static explicit operator PopupPage(DetailsClimaPage v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
