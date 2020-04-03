using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DealLocator.Services
{
    public interface IBusinessRepository
    {
        Task<bool> GetBusinessExist(Guid userId);
        Task<LocationDTO> GetBusinessLocation(Guid userId);
        Task<bool> NewBusiness(List<string> claimsList, Guid userId);
        Task<bool> UpdateBusiness(List<string> claimsList, Guid userId);
    }
}
