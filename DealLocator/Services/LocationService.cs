using DealLocator.Helpers;
using Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace DealLocator.Services
{
    public static class LocationService
    {

        public static async Task<string> FetchLocation(CancellationToken token,List<string> claims)
        {
            if (token.IsCancellationRequested)
                throw new OperationCanceledException(token);
            HttpClient client = new HttpClient();
            string queryAddress = await CreateQueryString(token,claims);
            var uri = Constants.AZUREMAPSURLBASE + $"/search/address/Json?subscription-key={Constants.AZUREMAPKEY}&api-version=1.0&query={queryAddress}";
            string response = await client.GetStringAsync(uri);
            client.Dispose();
            return response;
        }

        public static async Task<LocationDTO> ExtractLocation(string response, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                throw new OperationCanceledException(token);
            LocationDTO location = new LocationDTO();
            await Task.Run(() =>
            {
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
            });
            return location;
        }

       public static async Task<string> CreateQueryString(CancellationToken token,List<string> claims)
        {
            if (token.IsCancellationRequested)
                throw new OperationCanceledException(token);
            string queryAddress = string.Empty;
            await Task.Run(() =>
            {
                for (int i = 1; i < claims.Count; i++)
                    queryAddress += claims[i] + " ,";

                if (queryAddress.Length == 0)
                    queryAddress = null;
            });

            return queryAddress;
        }
    }
}
