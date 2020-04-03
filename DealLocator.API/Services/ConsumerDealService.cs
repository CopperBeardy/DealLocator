using DealLocator.API.Helpers;
using DealLocator.API.Models;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DealLocator.API.Services
{
    public class ConsumerDealService : IConsumerDealService
    {
        private List<Deal> _deals;
        private readonly List<FilterDeal> _filteredDeals;
        readonly DealLocatorDbContext _context;
        private UserFilters UserFilters;

        public ConsumerDealService(DealLocatorDbContext context)
        {

            _context = context;
            _deals = new List<Deal>();
            _filteredDeals = new List<FilterDeal>();
            UserFilters = new UserFilters();
        }


        public async Task<List<DealDTO>> GetDeals(UserFilters userFilters)
        {
            UserFilters = userFilters;
            await FilterDealsByCategory();
            ConvertToLocationDTO();

            return await CheckConsumerIsInRange();
        }

        private async Task<List<DealDTO>> CheckConsumerIsInRange()
        {
            List<DealDTO> ConsumerDeals = new List<DealDTO>();
          
            var consumerBuffer = await GenerateGeoBufferQuery.GenerateBuffer(UserFilters.Range * 1000 , UserFilters.Location);
         

            
            var queryBody = GeoFenceHelper.CreateRangeCheckJsonBody(consumerBuffer);

            foreach (FilterDeal filterDeal in _filteredDeals)
            {
                var val = GeoFenceHelper.FindRange(queryBody, filterDeal);
                if ( val == 0)
                {
                    continue;
                }
                Deal temp = _deals.First(d => d.Id.Equals(filterDeal.DealId));
                DealDTO deal = new DealDTO
                {
                    DealTitle = temp.Title,
                    DealDescription = temp.Description,
                    BusinessName = temp.Business.Name,
                    Latitude = temp.Business.Location.Latitude,
                    Longitude = temp.Business.Location.Longitude
                };

                ConsumerDeals.Add(deal);
            }


            return ConsumerDeals;
        }

        private async Task FilterDealsByCategory()
        {
            var category = (Category)UserFilters.Category;

                _deals = await _context.Deals.Where(x => x.DealStatus.Equals(DealStatus.Active))
                .Where(y => y.Category == category)
                .Include(x => x.Business)
                .ThenInclude(l => l.Location)
                .Include(l => l.Business.Location)
                .ToListAsync();
           


        }

        private void ConvertToLocationDTO()
        {
            foreach (Deal deal in _deals)
            {
                _filteredDeals.Add(new FilterDeal
                {
                    DealId = deal.Id,
                    LocationDto = new LocationDTO
                    {
                        Latitude = deal.Business.Location.Latitude,
                        Longitude = deal.Business.Location.Longitude
                    }
                });
            }

        }
    }

}

