using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.Consumer
{
    [ExcludeFromCodeCoverage]
    public class Feature
    {

        [JsonProperty("type")]
        public string Type { get; set; } = "feature";

        [JsonProperty("properties")]
        public Properties Properties { get; set; } = new Properties();

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }
}
