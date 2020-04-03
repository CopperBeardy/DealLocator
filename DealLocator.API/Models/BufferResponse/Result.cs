using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.BufferResponse
{
    [ExcludeFromCodeCoverage]
    public class Result
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }
}
