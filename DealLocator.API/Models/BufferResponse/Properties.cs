using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.BufferResponse
{
    [ExcludeFromCodeCoverage]
    public class Properties
    {
        [JsonProperty("geometryId")]
        public string GeometryId { get; set; }
        [JsonProperty("bufferDist")]
        public double BufferDist { get; set; }
    }
}
