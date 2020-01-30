using System;
using Newtonsoft.Json;

namespace TesteUol.ModelsDtos
{
    public class baseModelDto
    {
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
    }
}
