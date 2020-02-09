using System;
using System.Collections.Generic;
using TesteUol.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteUol.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CidadesPage
    {
        public CidadesPage(double latitudeGeocodificacao, double longitudeGeolocalizacao, string city)
        {
            var vm = new CidadesPagesViewModel(latitudeGeocodificacao, longitudeGeolocalizacao,city);
            BindingContext = vm;
            InitializeComponent();
        }
    }
}
