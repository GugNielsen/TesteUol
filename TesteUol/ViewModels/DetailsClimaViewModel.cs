using System;
using Prism.Navigation;
using TesteUol.Entities;

namespace TesteUol.ViewModels
{
    public class DetailsClimaViewModel : ViewModelBase
    {
        private string _icon;
        public string icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }
        //Pressure
        private float _pressure;
        public float Pressure
        {
            get { return _pressure; }
            set { SetProperty(ref _pressure, value); }
        }

        private float _dewPoint;
        public float DewPoint
        {
            get { return _dewPoint; }
            set { SetProperty(ref _dewPoint, value); }
        }

        private float _windSpeed;
        public float WindSpeed
        {
            get { return _windSpeed; }
            set { SetProperty(ref _windSpeed, value); }
        }

        private string _temperaturaMaxima;
        public string TemperaturaMaxima
        {
            get { return _temperaturaMaxima; }
            set { SetProperty(ref _temperaturaMaxima, value); }
        }

        private string _temperaturaMinima;
        public string TemperaturaMinima
        {
            get { return _temperaturaMinima; }
            set { SetProperty(ref _temperaturaMinima, value); }
        }


        private string _sumary;
        public string Summary
        {
            get { return _sumary; }
            set { SetProperty(ref _sumary, value); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private string _imageAnimada;
        public string ImageAnimada
        {
            get { return _imageAnimada; }
            set { SetProperty(ref _imageAnimada, value); }
        }

        public DetailsClimaViewModel(DailyForecast item)
        {
            Summary = item.summary;
            TemperaturaMaxima = Extensions.ConvertCelsius(item.apparentTemperatureMax);
            TemperaturaMinima = Extensions.ConvertCelsius(item.apparentTemperatureMin);
            icon = item.icon;
            WindSpeed = item.windSpeed;
            DewPoint = item.dewPoint;
            Date = (System.DateTime)item.date;
            Pressure = item.pressure;
            LoadImageAnimada();

        }

        private void LoadImageAnimada()
        {
            // Pegar a Imagem Aminada de Acordo Com Summary
            // Explicando Para economizar tempo eu fiz deste jeito e logico que fosse MultiIdiomas faria de outra Maneira 
            if (Summary.Contains("sol"))
            {
                ImageAnimada = "sum.json";
            }
            else if (Summary.Contains("nublado"))
            {
                ImageAnimada = "nublado.json";
            }
            else
            {
                ImageAnimada= "chuva.json";
            }
        }
    }
}
