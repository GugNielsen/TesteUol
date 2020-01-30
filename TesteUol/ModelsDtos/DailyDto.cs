using System;
using Newtonsoft.Json;

namespace TesteUol.ModelsDtos
{
    public partial class Daily
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("icon")]
        public Icon Icon { get; set; }

        [JsonProperty("data")]
        public DailyDatum[] Data { get; set; }
    }
}
