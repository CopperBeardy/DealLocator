using AzureMapsToolkit;
using AzureMapsToolkit.Spatial;
using DealLocator.API.Models.DealProvider;
using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DealLocator.API.Helpers
{
    public static class GeoFenceHelper
    {
        public static string CreateRangeCheckJsonBody(List<List<double>> coords)
        {

            Feature feat = new Feature()
            { 
                
                Geometry = new Geometry()
                {
                    Coordinates = new List<List<List<double>>>
                    {
                        coords
                    }
                },
                Properties = new Properties(),

            };

            FeatureCollection featureCollection = new FeatureCollection
            {
                Features = new List<Feature>
                {
                    feat
                }
            };

            //return the the json object
            return JsonConvert.SerializeObject(featureCollection);

        }

        public static int FindRange(string area, FilterDeal filterDeal)
        {

            string[] result = null; 
            PostPointInPolygonRequest req = new PostPointInPolygonRequest  
            {
                ApiVersion = "1.0",
                Lon = filterDeal.LocationDto.Longitude,
                Lat = filterDeal.LocationDto.Latitude,              
               
            };
            var am = new AzureMapsServices(Constants.AZUREMAPKEY);
            try
            {
                var response = am.PostPointInPolygon(req, area);



               result = response.Result.Result.Result.IntersectingGeometries;
              
            }
            catch (Exception ex)
            {
               
                throw new Exception(nameof(FindRange), ex);
            } 
            if (result == null || result.Length == 0)
            {
                    return 0;
            }

             return 1;
        }



    }
}

