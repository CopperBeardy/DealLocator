
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DealLocator.Mobile.Helpers
{
    public static class PhoneLocation
    {
          public static async Task<Location> CurrentLocation()
        {
            try
            {                
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
               
                return location;
            }
            catch (Exception ex)
            {
                throw new Exception(nameof(CurrentLocation), ex);
            }
            
        }

    }
}
