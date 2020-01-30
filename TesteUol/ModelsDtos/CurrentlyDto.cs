using System;
using Newtonsoft.Json;

namespace TesteUol.ModelsDtos
{
   
        public class Currently : ModelBase
        {
            [JsonProperty("time")]
            public long Time { get; set; }

            [JsonProperty("summary")]
            public Summary Summary { get; set; }

            [JsonProperty("icon")]
            public Icon Icon { get; set; }

            [JsonProperty("nearestStormDistance", NullValueHandling = NullValueHandling.Ignore)]
            public long? NearestStormDistance { get; set; }

            [JsonProperty("nearestStormBearing", NullValueHandling = NullValueHandling.Ignore)]
            public long? NearestStormBearing { get; set; }

            [JsonProperty("precipIntensity")]
            public double PrecipIntensity { get; set; }

            [JsonProperty("precipProbability")]
            public double PrecipProbability { get; set; }

            [JsonProperty("temperature")]
            public double Temperature { get; set; }

            [JsonProperty("apparentTemperature")]
            public double ApparentTemperature { get; set; }

            [JsonProperty("dewPoint")]
            public double DewPoint { get; set; }

            [JsonProperty("humidity")]
            public double Humidity { get; set; }

            [JsonProperty("pressure")]
            public double Pressure { get; set; }

            [JsonProperty("windSpeed")]
            public double WindSpeed { get; set; }

            [JsonProperty("windGust")]
            public double WindGust { get; set; }

            [JsonProperty("windBearing")]
            public long WindBearing { get; set; }

            [JsonProperty("cloudCover")]
            public double CloudCover { get; set; }

            [JsonProperty("uvIndex")]
            public long UvIndex { get; set; }

            [JsonProperty("visibility")]
            public long Visibility { get; set; }

            [JsonProperty("ozone")]
            public double Ozone { get; set; }

            [JsonProperty("precipType", NullValueHandling = NullValueHandling.Ignore)]
            public PrecipType? PrecipType { get; set; }
        
    }
}
