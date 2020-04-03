

using AzureMapsToolkit;
using AzureMapsToolkit.Spatial;
using DealLocator.API.Models.BufferResponse;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealLocator.API.Helpers
{
    public static class BufferService
    {

        public static async Task<List<List<double>>> GetBuffer(string body)
        {
            try
            {
                
                return ExtractBufferCoordinates(
                    DeserializeBuffer(
                        await FetchBuffer(body)));
                
            }
            catch (Exception ex)
            {
              
                throw new Exception("Buffer failed to be generated", ex);
            }     
        }

        private static List<List<double>> ExtractBufferCoordinates(ConsumerBuffer result)
        {
            return result.Result.Features.Select(c => c.Geometry.Coordinates).First().First().ToList();
        }

        private static async Task<Response<BufferResponse>> FetchBuffer(string body)
        {
            try
            {
                AzureMapsServices am = new AzureMapsServices(Constants.AZUREMAPKEY);
               var buffer = await am.PostBuffer(body);
                return buffer;
            }
            catch (Exception ex)
            {
                throw new Exception(nameof(FetchBuffer),ex);
            }
        }

        private static ConsumerBuffer DeserializeBuffer(Response<BufferResponse> rep)
        {
            return JsonConvert.DeserializeObject<ConsumerBuffer>(rep.Result.Result.ToString());
        }
    }
}
