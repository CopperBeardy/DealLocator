using DealLocator.API.Models.Consumer;
using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealLocator.API.Helpers
{
    public static class GenerateGeoBufferQuery
    {
        public static async Task<List<List<double>>> GenerateBuffer(int range, LocationDTO locationDTO)
        {
            Feature feat = new Feature()
            {
                Geometry = new Geometry()
                {
                    Coordinates = new List<double>() {  locationDTO.Longitude,locationDTO.Latitude }
                }
            };

            RootObject root = new RootObject()
            {
                Geometries = new Geometries
                {
                    Feature = new List<Feature>() { feat }
                },
                Distances = new List<int>() { range }
            };

          
                List<List<double>> coords = await  BufferService.GetBuffer(JsonConvert.SerializeObject(root));

                return coords;
          
            
        }
    }
}
