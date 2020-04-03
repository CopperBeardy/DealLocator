using DealLocator.Mobile.Helpers;
using DealLocator.Mobile.Models;
using DealLocator.Mobile.Services;
using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms.Maps;

namespace DealLocator.Mobile.ViewModels
{
    public class MapPageViewModel 
    {
        public List<Pin> Pins;
       public Map Map;

        public UserFilters UserFilters;


        public  MapPageViewModel()
        {
          
              Pins = new List<Pin>();
              Map = new Map();
            
 
            initUserFilters();
          
            _ = CreateMap();

            //TODO why are we losing all pins from here

        }

        private void initUserFilters()
        {
            UserFilters = new UserFilters();
            UserFilters.Range = int.Parse(Xamarin.Essentials.Preferences.Get("Range", "3"));
            UserFilters.Category= int.Parse(Xamarin.Essentials.Preferences.Get("Category", "0"));       
          
        }

        private async Task CreateMap()
        {
            UserFilters = await GetLocation();
         await GetDeals();
            //Map.Pins = Pins;
            //foreach (var item in Pins)
            //{
            //    Map.Pins.Add(item);
            //}

            var pin = new CustomPin
            {
                Type = PinType.Generic,
                Position = new Position(UserFilters.Location.Latitude, UserFilters.Location.Longitude),
                Label = "Your Position",
                Address = ""
            };
           // CustomPins.Add(pin);
            Map.Pins.Add(pin);
        
            

            Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(UserFilters.Location.Latitude, UserFilters.Location.Longitude),
                                                        Distance.FromMiles(5)));
            
        }

       

        private async Task<UserFilters> GetLocation()
        {
            var location = await PhoneLocation.CurrentLocation();

            UserFilters.Location.Latitude = location.Latitude;
            UserFilters.Location.Longitude = location.Longitude;
            return UserFilters;
        }       

        private async Task GetDeals()
        {     
            
            var deals = await AzureMapData.GetDeals(UserFilters);

            foreach (var deal in deals)
            {
                var pin = new CustomPin
                {
                    Type = PinType.Place,
                    Position = new Position(deal.Latitude, deal.Longitude),
                    Label = deal.BusinessName,
                    Address = deal.DealTitle + ": " + deal.DealDescription
                };
                Map.Pins.Add(pin);
            }      
        }
    }
}
