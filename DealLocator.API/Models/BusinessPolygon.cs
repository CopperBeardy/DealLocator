using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealLocator.API.Models
{

    public class Feature
    {

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("properties")]
        public Properties properties { get; set; }

        [JsonProperty("geometry")]
        public Geometry geometry { get; set; }
    }
    public class Properties
    {

        [JsonProperty("geometryId")]
        public string geometryId { get; set; }
    }

    public class Geometry
    {

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("coordinates")]
        public List<List<List<double>>> coordinates { get; set; }
    }
    

    public class BusinessPolygon
    {

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("features")]
        public List<Feature> features { get; set; }
    }


}
