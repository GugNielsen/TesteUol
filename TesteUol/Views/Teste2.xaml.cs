using System;
using System.Collections.Generic;
using TesteUol.Abstractions;
using TesteUol.Helpers;
using TesteUol.Services;
using Xamanimation;
using Xamarin.Forms;

namespace TesteUol.Views
{
    public partial class Teste2 : ContentPage, IAnimatedView
    {
      //  RestClient _restService;
        public Teste2()
        {
            InitializeComponent();
            //_restService = new RestClient();
        }

        public void StartAnimation()
        {
            if (Resources["InfoPanelAnimation"] is StoryBoard animation)
            {
                animation.Begin();
            }
        }

    }
}
