using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.BufferResponse
{
    [ExcludeFromCodeCoverage]
    public class Feature
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("properties")]
        public Properties Properties { get; set; }
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }
}
