using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.Consumer
{
    [ExcludeFromCodeCoverage]
    public class Geometry
    {

        [JsonProperty("type")]
        public string Type { get; set; } = "Point";

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }
}
