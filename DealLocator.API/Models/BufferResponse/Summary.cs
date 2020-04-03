using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.BufferResponse
{
    [ExcludeFromCodeCoverage]
    public class Summary
    {
        [JsonProperty("udid")]
        public object UdId { get; set; }
        [JsonProperty("information")]
        public string Information { get; set; }
    }
}
