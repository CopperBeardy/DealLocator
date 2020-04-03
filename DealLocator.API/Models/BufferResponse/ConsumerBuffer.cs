using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.BufferResponse
{
    [ExcludeFromCodeCoverage]
    public class ConsumerBuffer
    {
        [JsonProperty("summary")]
        public Summary Summary { get; set; }
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}
