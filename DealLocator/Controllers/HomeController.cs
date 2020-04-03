using DealLocator.Helpers;
using DealLocator.Models;
using DealLocator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace DealLocator.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBusinessRepository _businessRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IBusinessRepository businessRepository,
            IHttpContextAccessor httpContextAccessor)
        {

            this._businessRepository = businessRepository;
            this._httpContextAccessor = httpContextAccessor;
          

        }

        public async Task<IActionResult> Index()
        {
           
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
               

                var claims = CheckUpdateRequired();
 
                if (claims != null && claims.Count > 0)
                {
                    await CheckBusiness(claims);
                }
            }
            return View();
        }

        public async Task<bool> CheckBusiness(List<string> claims)
        {
            Guid.TryParse(
                _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                out Guid userId);
          

            if (await GetExists(userId))
            {
                await _businessRepository.UpdateBusiness(claims, userId);
                return true;
            }
            else
            {
                await _businessRepository.NewBusiness(claims, userId);
                return true;
            }
        }

        private async Task<bool> GetExists(Guid userId)
        {
            return await _businessRepository.GetBusinessExist(userId);
        }

        private List<string> CheckUpdateRequired()
        {
            Claim claim = GetClaim();

            if (claim != null)
            {
                return ClaimCollectionConverter
                    .ConvertClaimEnumerableToListStringClaimValues(_httpContextAccessor.HttpContext.User.Claims);
            }
            return null;
        }

        private Claim GetClaim()
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
                x => string.Compare(x.Type, "newUser", StringComparison.Ordinal) == 0
                || string.Compare(x.Type, "extension_check", StringComparison.Ordinal) == 0);
        }
    }
}
