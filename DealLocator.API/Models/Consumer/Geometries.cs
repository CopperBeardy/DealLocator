using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.Consumer
{
    [ExcludeFromCodeCoverage]
    public class Geometries
    {

        [JsonProperty("type")]
        public string Type { get; set; } = "FeatureCollection";

        [JsonProperty("features")]
        public List<Feature> Feature { get; set; }
    }
}
