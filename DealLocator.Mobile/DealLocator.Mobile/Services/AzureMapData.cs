using DealLocator.Mobile.Models;
using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DealLocator.Mobile.Services
{
    public static class AzureMapData
    {


        public async static Task<List<DealDTO>> GetDeals(UserFilters userFilters)
        {
            HttpClient httpClient =  GetClient();
     
         string APiUrl = "";

        APiUrl += $"?lat={userFilters.Location.Latitude}&";
            APiUrl += $"lon={userFilters.Location.Longitude}&";
            APiUrl += $"range={userFilters.Range}&";
            APiUrl += $"category={userFilters.Category}";

            string response= await httpClient.GetStringAsync(APiUrl);
           
            return JsonConvert.DeserializeObject<List<DealDTO>>(response);
          
        }

        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();  
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}
