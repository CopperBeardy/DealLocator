using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.Consumer
{
    [ExcludeFromCodeCoverage]
    public class RootObject
    {
        [JsonProperty("geometries")]
        public Geometries Geometries { get; set; }

        [JsonProperty("distances")]
        public List<int> Distances { get; set; }
    }
}

