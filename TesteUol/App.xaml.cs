using System;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using TesteUol.Abstractions;
using TesteUol.Services;
using TesteUol.ViewModels;
using TesteUol.Views;
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjA4MTMxQDMxMzcyZTM0MmUzMG5CVkRvZDJJRVZqenpIN1ptN1Y4amZiL3ZVV1puZzQycXU1RUs2TTNmYW89");
            NavigationService.NavigateAsync("Teste2");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Views Models/ Views
            containerRegistry.RegisterForNavigation<TempoPage, TempoViewModel>();
            containerRegistry.RegisterForNavigation<Teste2, TempoViewModel>();
            containerRegistry.RegisterForNavigation<DetailsClimaPage, DetailsClimaViewModel>();



            containerRegistry.Register<IConnectivityService, ConnectivityService>();
            //containerRegistry.Register<IRestService, RestServices>();
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
