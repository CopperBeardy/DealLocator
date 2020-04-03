using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DealLocator.API.Models.DealProvider
{
    [ExcludeFromCodeCoverage]
    public class Properties
    {
        [JsonProperty("geometryId")]
        public string GeometryId { get; set; } = Guid.NewGuid().ToString();
    }
}
