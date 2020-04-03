using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.DealProvider
{
    [ExcludeFromCodeCoverage]
    public class FeatureCollection
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "FeatureCollection";


        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }
}
