using Domain;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DealLocator.API.Models
{
    [ExcludeFromCodeCoverage]
    public static class DbInitialize
    {
        public static void Initialize(DealLocatorDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Businesses.Any())
            {
                return;
            }

            #region Business seed data
            var Businesses = new Business[]
            {
                new Business{Id=Guid.Parse("0dc5b674-580c-45b2-9c37-68724c36eee0"),Name="abc",},
                new Business{Id=Guid.Parse("693f9eec-a43d-402d-aa99-721f96145577"),Name="ddd",},
                new Business{Id=Guid.Parse("392b9930-8dac-4997-bac6-22bc00f5560a"),Name="bnj",},

            };

            foreach (Business b in Businesses)
            {
                context.Businesses.Add(b);
            }
            context.SaveChanges();
            #endregion


            #region Location seed data

            var Locations = new Location[]
            {
                new Location{BusinessId=Guid.Parse("0dc5b674-580c-45b2-9c37-68724c36eee0"),Latitude=51.6916,Longitude=-3.33905},
                 new Location{BusinessId=Guid.Parse("693f9eec-a43d-402d-aa99-721f96145577"),Latitude= 51.6915,Longitude=-3.33906},
                 new Location{BusinessId=Guid.Parse("392b9930-8dac-4997-bac6-22bc00f5560a"),Latitude= 51.2914,Longitude=-3.33907}
            };


            foreach (Location l in Locations)
            {
                context.Locations.Add(l);
            }
            context.SaveChanges();
            #endregion


            #region Deal seed data
            var Deals = new Deal[]
            {
                new Deal{
                    Id =Guid.Parse("827d5822-fe56-437b-8353-11d2e58df295"),
                    Title ="Skirt summer sale",
                    Description ="20% of skirts",
                    Duration =2,
                    StartDate =DateTime.Today,
                    EndDate =  DateTime.Today.AddDays(2),
                    BusinessId =Guid.Parse("0dc5b674-580c-45b2-9c37-68724c36eee0"),
                    DealStatus = DealStatus.Active,
                    Category =Category.Fashion},

                new Deal{
                    Id =Guid.Parse("9920b16f-8cde-4052-89f2-d39bba046233"),
                    Title ="Blow out sale",
                    Description ="50% of everything",
                    Duration =2,
                    StartDate =DateTime.Today.AddDays(-3),
                    EndDate = DateTime.Today.AddDays(-1),
                    BusinessId =Guid.Parse("0dc5b674-580c-45b2-9c37-68724c36eee0"),
                    DealStatus= DealStatus.Completed,
                    Category =Category.Food},

                new Deal{
                    Id =Guid.Parse("144cf61b-94c9-412c-9630-78d7a24d9998"),
                    Title ="End of line deals",
                    Description ="up to 60% reduced",
                    Duration =4,
                    StartDate =DateTime.Today.AddDays(-1),
                    EndDate = DateTime.Today.AddDays(3),
                    BusinessId =Guid.Parse("0dc5b674-580c-45b2-9c37-68724c36eee0"),
                    DealStatus = DealStatus.Active,
                    Category =Category.Sport},

                new Deal{
                    Id =Guid.Parse("ae938c9e-241d-4e52-938c-29d1e6947ece"),
                    Title ="Cap July sale",
                    Description =" 2 for 1 caps staring from £4.99",
                    Duration =7,
                    StartDate =DateTime.Today.AddDays(-2),
                    EndDate =DateTime.Today.AddDays(-1),
                    BusinessId =Guid.Parse("0dc5b674-580c-45b2-9c37-68724c36eee0"),
                    DealStatus = DealStatus.Cancelled,
                    Category =Category.Sport},
                new Deal{
                    Id =Guid.Parse("4e277d75-2892-4d58-b477-c34ff31fca3b"),
                    Title ="30 of over 100",
                    Description ="30% of when you spend £100 or more",
                    Duration =3,
                    StartDate =DateTime.Today.AddDays(2),
                    EndDate = DateTime.Today.AddDays(1),
                    BusinessId =Guid.Parse("693f9eec-a43d-402d-aa99-721f96145577"),
                    DealStatus =DealStatus.Active,
                    Category =Category.Shopping},
                 new Deal{
                    Id =Guid.Parse("65bfe6b0-c5d4-4e5e-9301-c7392d1345b3"),
                    Title ="2 For 1",
                    Description ="Prime Oranges",
                    Duration =3,
                    StartDate =DateTime.Today.AddDays(2),
                    EndDate = DateTime.Today.AddDays(5),
                    BusinessId =Guid.Parse("392b9930-8dac-4997-bac6-22bc00f5560a"),
                    DealStatus =DealStatus.Active,
                    Category =Category.Shopping},
                  new Deal{
                    Id =Guid.Parse("d456fb7f-b1c0-4a6e-b4bb-0b9bcd67b850"),
                    Title ="up 80% super savings",
                    Description ="Clearance sale with up to 80% of all products",
                    Duration =3,
                    StartDate =DateTime.Today.AddDays(1),
                    EndDate = DateTime.Today.AddDays(3),
                    BusinessId =Guid.Parse("392b9930-8dac-4997-bac6-22bc00f5560a"),
                    DealStatus =DealStatus.Active,
                    Category =Category.Sport},
                   new Deal{
                    Id =Guid.Parse("b5d8cb71-86db-4888-adb2-2e3359369de9"),
                    Title ="Handbag Free with purchase of £100 or more",
                    Description ="30% of when you spend £100 or more",
                    Duration =3,
                    StartDate =DateTime.Today.AddDays(1),
                    EndDate = DateTime.Today.AddDays(2),
                    BusinessId =Guid.Parse("392b9930-8dac-4997-bac6-22bc00f5560a"),
                    DealStatus =DealStatus.Active,
                    Category =Category.Fashion}



            };
            foreach (Deal deal in Deals)
            {
                context.Deals.Add(deal);
            }
            context.SaveChanges();
            #endregion



        }
    }
}
