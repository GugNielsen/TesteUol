using System;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using TesteUol.Abstractions;
using TesteUol.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteUol
{
    public partial class App : PrismApplication
    {

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IConnectivityService, ConnectivityService>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

      
    }
}
