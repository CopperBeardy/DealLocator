using DealLocator.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealLocator.Controllers
{
    public class DealController : Controller
    {

        readonly IDealRepository _dealRepository;


        public DealController(IDealRepository dealRepository)
        {
            _dealRepository = dealRepository;

        }



        // GET: Deal
        public async Task<IActionResult> Index(Guid id)
        {
            IList<Deal> deals = await _dealRepository.GetDealsById(id);
            ViewData["BusinessId"] = id;
            return View(deals);
        }

        // GET: Deal/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            Deal deal = await _dealRepository.GetDealById(id);

            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // GET: Deal/Create
        public IActionResult Create(Guid id)
        {
            ViewData["BusinessId"] = id;

            List<Category> categories = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
            ViewData["Categories"] = new SelectList(categories);

            return View();
        }

        // POST: Deal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Duration,StartDate,BusinessId,Active,Category")] Deal deal)
        {
            if (ModelState.IsValid)
            {
                await _dealRepository.Add(deal);
                return RedirectToAction(nameof(Index), new { id = deal.BusinessId });
            }
            ViewData["BusinessId"] = deal.BusinessId;
            return View(deal);
        }


        public async Task<IActionResult> Cancel(Guid id)
        {
            Deal deal = await _dealRepository.GetDealById(id);

            if (deal == null)
                return NotFound();

            return View(deal);
        }


        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]        // GET: Deals/Delete/5
        public async Task<IActionResult> CancelConfirmed(Guid id)
        {

            Deal deal = await _dealRepository.CancelDeal(id);

            return RedirectToAction(nameof(Index), new { id = deal.BusinessId });
        }





    }
}
