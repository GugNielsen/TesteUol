using System;
using Newtonsoft.Json;

namespace TesteUol.ModelsDtos
{
    public partial class Minutely
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("icon")]
        public Icon Icon { get; set; }

        [JsonProperty("data")]
        public MinutelyDatum[] Data { get; set; }
    }
}
