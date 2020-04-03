using Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DealLocator.Helpers
{
    public static class LocationConverter
    {

        public static async Task<string> FetchLocation(List<string> claims)
        {

            HttpClient client = new HttpClient();
            string queryAddress = CreateQueryString(claims);

            string uri = Constants.AZUREMAPSURLBASE + $"/search/address/Json?subscription-key={Constants.AZUREMAPKEY}&api-version=1.0&query={queryAddress}";
            string response = await client.GetStringAsync(uri);
            client.Dispose();
            return response;
        }


        public static async Task<Location> UpdateLocationAsync(List<string> claimsList, Guid userId)
        {

            string response = await FetchLocation(claimsList);

            LocationDTO loc = ExtractLocation(response);

            return new Location
            {
                BusinessId = userId,
                Longitude = loc.Longitude,
                Latitude = loc.Latitude
            };
        }


        private static string CreateQueryString(List<string> claims)
        {

            string queryAddress = string.Empty;

            for (int i = 1; i < claims.Count; i++)
                queryAddress += claims[i] + " ,";

            if (queryAddress.Length == 0)
                queryAddress = null;


            return queryAddress;
        }


        private static LocationDTO ExtractLocation(string response)
        {

            LocationDTO location = new LocationDTO();

            try
            {
                JObject o = JObject.Parse(response);
                var pos = o["results"][0]["position"];
                location.Longitude = pos.Value<double>("lon");
                location.Latitude = pos.Value<double>("lat");
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception(nameof(ExtractLocation), ex);
            }

            return location;
        }
    }
}
