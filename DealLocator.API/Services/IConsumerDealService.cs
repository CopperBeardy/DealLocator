using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealLocator.API.Services
{
    public interface IConsumerDealService
    {
     
        Task<List<DealDTO>> GetDeals(UserFilters userFilter);
    }
}
