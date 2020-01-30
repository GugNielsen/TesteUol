using System;
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TesteUol.ModelsDtos
{
    public partial class Tempo
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("currently")]
        public Currently Currently { get; set; }

        [JsonProperty("minutely")]
        public Minutely Minutely { get; set; }

        [JsonProperty("hourly")]
        public Hourly Hourly { get; set; }

        [JsonProperty("daily")]
        public Daily Daily { get; set; }

        [JsonProperty("alerts")]
        public Alert[] Alerts { get; set; }

        [JsonProperty("flags")]
        public Flags Flags { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
    }


  

    public enum Icon { ClearDay, ClearNight, Cloudy, PartlyCloudyDay, PartlyCloudyNight };

    public enum PrecipType { Rain };

    public enum Summary { Clear, MostlyCloudy, Overcast, PartlyCloudy };

    public partial class Tempo
    {
        public static Tempo FromJson(string json) => JsonConvert.DeserializeObject<Tempo>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Tempo self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                IconConverter.Singleton,
                PrecipTypeConverter.Singleton,
                SummaryConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class IconConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Icon) || t == typeof(Icon?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "clear-day":
                    return Icon.ClearDay;
                case "clear-night":
                    return Icon.ClearNight;
                case "cloudy":
                    return Icon.Cloudy;
                case "partly-cloudy-day":
                    return Icon.PartlyCloudyDay;
                case "partly-cloudy-night":
                    return Icon.PartlyCloudyNight;
            }
            throw new Exception("Cannot unmarshal type Icon");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Icon)untypedValue;
            switch (value)
            {
                case Icon.ClearDay:
                    serializer.Serialize(writer, "clear-day");
                    return;
                case Icon.ClearNight:
                    serializer.Serialize(writer, "clear-night");
                    return;
                case Icon.Cloudy:
                    serializer.Serialize(writer, "cloudy");
                    return;
                case Icon.PartlyCloudyDay:
                    serializer.Serialize(writer, "partly-cloudy-day");
                    return;
                case Icon.PartlyCloudyNight:
                    serializer.Serialize(writer, "partly-cloudy-night");
                    return;
            }
            throw new Exception("Cannot marshal type Icon");
        }

        public static readonly IconConverter Singleton = new IconConverter();
    }

    internal class PrecipTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PrecipType) || t == typeof(PrecipType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "rain")
            {
                return PrecipType.Rain;
            }
            throw new Exception("Cannot unmarshal type PrecipType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PrecipType)untypedValue;
            if (value == PrecipType.Rain)
            {
                serializer.Serialize(writer, "rain");
                return;
            }
            throw new Exception("Cannot marshal type PrecipType");
        }

        public static readonly PrecipTypeConverter Singleton = new PrecipTypeConverter();
    }

    internal class SummaryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Summary) || t == typeof(Summary?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Clear":
                    return Summary.Clear;
                case "Mostly Cloudy":
                    return Summary.MostlyCloudy;
                case "Overcast":
                    return Summary.Overcast;
                case "Partly Cloudy":
                    return Summary.PartlyCloudy;
            }
            throw new Exception("Cannot unmarshal type Summary");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Summary)untypedValue;
            switch (value)
            {
                case Summary.Clear:
                    serializer.Serialize(writer, "Clear");
                    return;
                case Summary.MostlyCloudy:
                    serializer.Serialize(writer, "Mostly Cloudy");
                    return;
                case Summary.Overcast:
                    serializer.Serialize(writer, "Overcast");
                    return;
                case Summary.PartlyCloudy:
                    serializer.Serialize(writer, "Partly Cloudy");
                    return;
            }
            throw new Exception("Cannot marshal type Summary");
        }

        public static readonly SummaryConverter Singleton = new SummaryConverter();
    }
}
