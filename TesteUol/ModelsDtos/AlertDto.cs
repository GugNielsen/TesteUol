using System;
using Newtonsoft.Json;

namespace TesteUol.ModelsDtos
{
	public partial class Alert
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("regions")]
		public string[] Regions { get; set; }

		[JsonProperty("severity")]
		public string Severity { get; set; }

		[JsonProperty("time")]
		public long Time { get; set; }

		[JsonProperty("expires")]
		public long Expires { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("uri")]
		public Uri Uri { get; set; }
	}
}
