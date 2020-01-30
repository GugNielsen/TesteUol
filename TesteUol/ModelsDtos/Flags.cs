using System;
using Newtonsoft.Json;

namespace TesteUol.ModelsDtos
{
    public partial class Flags
    {
        [JsonProperty("sources")]
        public string[] Sources { get; set; }

        [JsonProperty("nearest-station")]
        public double NearestStation { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }
}
