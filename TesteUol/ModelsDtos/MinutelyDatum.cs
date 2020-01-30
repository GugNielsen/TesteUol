using System;
using Newtonsoft.Json;

namespace TesteUol.ModelsDtos
{
    public partial class MinutelyDatum
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("precipIntensity")]
        public double PrecipIntensity { get; set; }

        [JsonProperty("precipProbability")]
        public double PrecipProbability { get; set; }

        [JsonProperty("precipIntensityError", NullValueHandling = NullValueHandling.Ignore)]
        public double? PrecipIntensityError { get; set; }

        [JsonProperty("precipType", NullValueHandling = NullValueHandling.Ignore)]
        public PrecipType? PrecipType { get; set; }
    }
}
