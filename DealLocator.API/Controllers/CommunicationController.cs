using DealLocator.API.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace DealLocator.API.Controllers
{
    //Excluded from test coverage as testing done with PostMan
    [ExcludeFromCodeCoverage]
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        readonly IConsumerDealService consumerDealService;
        public CommunicationController(IConsumerDealService consumerDealService)
        {
            this.consumerDealService = consumerDealService;
        }

        [HttpGet] 
        public async Task<List<DealDTO>> GetDeals(
                [FromQuery(Name ="lat")]string lat,
                [FromQuery(Name ="lon")]string lon,
                [FromQuery(Name ="range")]string range,
                [FromQuery(Name ="category")]string category) {
       

            UserFilters uf = new UserFilters();
            uf.Category = int.Parse(category);
            uf.Range = int.Parse(range);
            uf.Location = new LocationDTO()
            {
                Latitude = double.Parse(lat),
                Longitude = double.Parse(lon)
            };
         

              List<DealDTO> result = await consumerDealService.GetDeals(uf);
         
            return result;
        }

      



    }
}