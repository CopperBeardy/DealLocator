using DealLocator.Helpers;
using DealLocator.Models;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace DealLocator.Services
{
    
    //currently excluded from testing as I need to find a way to mock a Claims list
    [ExcludeFromCodeCoverage]
    public class BusinessRepository : IBusinessRepository
    {

        readonly DealLocatorDbContext _context;
        public BusinessRepository(DealLocatorDbContext context)
        {
            _context = context;
           
        }

        public async Task<bool> UpdateBusiness(List<string> claimsList, Guid userId)
        {
            try
            {
                Business business = await GetBusiness(userId);
                business.Name = claimsList[0];
                _context.Locations.Update(await UpdateLocation(claimsList, userId));
                _context.Businesses.Update(business);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(nameof(UpdateBusiness), ex);
            }
            return true;
        }

        private static async Task<Location> UpdateLocation(List<string> claimsList, Guid userId)
        {
            return await LocationConverter.UpdateLocationAsync(claimsList, userId);
        }

        private async Task<Business> GetBusiness(Guid userId)
        {
            return await _context.Businesses.FirstOrDefaultAsync(x => x.Id.Equals(userId));
        }

        public async Task<bool> GetBusinessExist( Guid userId)
        {
            Business business = await GetBusiness(userId);
            if (business == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> NewBusiness(List<string> claimsList, Guid userId)
        {
           
            try
            {
                Business business = new Business
                {
                    Id = userId,
                    Name = claimsList[0],
                    Location = await UpdateLocation(claimsList, userId)
                };

                _context.Businesses.Add(business);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(nameof(NewBusiness), ex);
            }
            return true;
        }


        public async Task<LocationDTO> GetBusinessLocation(Guid userId)
        {

            
            var loc = await _context.Locations.FirstOrDefaultAsync(b => b.BusinessId.Equals(userId));
            return new LocationDTO { Latitude = loc.Latitude, Longitude = loc.Longitude };

        }
    }
}

