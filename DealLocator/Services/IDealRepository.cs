using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealLocator.Services
{
    public interface IDealRepository
    {
        Task<Deal> Add(Deal deal);
        Task<Deal> GetDealById(Guid id);
        Task<IList<Deal>> GetDealsById(Guid id);
        Task<Deal> CancelDeal(Guid id);
    }
}