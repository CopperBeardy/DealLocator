using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.Consumer
{
    [ExcludeFromCodeCoverage]
    public class Properties
    {
        [JsonProperty("geometryId")]
        public string GeometryId { get; set; } = "consumer";
    }
}
