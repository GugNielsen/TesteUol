using System;
using System.Collections.Generic;
using TesteUol.Abstractions;
using Xamanimation;
using Xamarin.Forms;

namespace TesteUol.Views
{
    public partial class TempoPage : ContentPage, IAnimatedView
    {
        public TempoPage()
        {
            InitializeComponent();
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
