using DealLocator.Models;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DealLocator.Services
{
    //Boilerplate code will not be unit testing
    [ExcludeFromCodeCoverage]
    public class DealRepository : IDealRepository
    {
        readonly DealLocatorDbContext _context;
        public DealRepository(DealLocatorDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Deal>> GetDealsById(Guid id)
        {
            var deals = _context.Deals
                .Where(x => x.BusinessId.Equals(id))
                .Include(d => d.Business);

            return await deals.ToListAsync();
        }

        public async Task<Deal> GetDealById(Guid id)
        {
            var deal = await _context.Deals
                 .Include(d => d.Business)
                 .FirstOrDefaultAsync(m => m.Id == id);

            return deal;
        }

        public async Task<Deal> Add(Deal deal)
        {
            deal.Id = Guid.NewGuid();
            _context.Add(deal);
            await _context.SaveChangesAsync();

            return deal;
        }


        public async Task<Deal> CancelDeal(Guid id)
        {

            var deal = await _context.Deals
                            .FirstOrDefaultAsync(m => m.Id == id);
            deal.DealStatus = DealStatus.Cancelled;

            _context.Update(deal);
            await _context.SaveChangesAsync();

            return deal;
        }
    }
}
