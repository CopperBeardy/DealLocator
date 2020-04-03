using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.BufferResponse
{
    [ExcludeFromCodeCoverage]
    public class Geometry
    {
        [JsonProperty("coordinates")]
        public List<List<List<double>>> Coordinates { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
