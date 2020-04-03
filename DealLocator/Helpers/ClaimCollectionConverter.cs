using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;

namespace DealLocator.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class ClaimCollectionConverter
    {

        public static List<string> ConvertClaimEnumerableToListStringClaimValues(IEnumerable<Claim> claim)
        {
            List<string> claimValues = new List<string>();
            try
            {
                List<Claim> claims = claim.ToList();


                for (var i = 2; i < claims.Count - 1; i++)
                {
                    string temp = claims[i].Value;
                    if (temp.Equals(true) || temp.Equals(false) ||
                        temp.Equals("true") || temp.Equals("false"))
                    {
                        continue;
                    }
                    claimValues.Add(claims[i].Value.ToUpper());
                };
            }
            catch (Exception ex)
            {
                throw new Exception(nameof(ClaimCollectionConverter), ex);
            }

            return claimValues;
        }
    }
}
