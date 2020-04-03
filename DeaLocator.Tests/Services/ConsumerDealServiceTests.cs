using DealLocator.API.Models;
using DealLocator.API.Services;

using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeaLocator.Tests.Services
{

    [ExcludeFromCodeCoverage]
    public class ConsumerDealServiceTests
    {
        ConsumerDealService sut;
        public ConsumerDealServiceTests()
        {
            var options = new DbContextOptionsBuilder<DealLocator.API.Models.DealLocatorDbContext>()
       .UseInMemoryDatabase(databaseName: "LocationDatabase")
       .Options;
            var context = new DealLocatorDbContext(options);
            sut = new ConsumerDealService(context);
            DbInitialize.Initialize(context);

        } 
        [Fact]
        public async Task Should_Return_Empty_List_If_All_Deals_Out_Of_Range()
        {
                       //Arrange 
            var filters = new UserFilters()
            {
                Category = 0,
                Location = new LocationDTO() { Latitude = 65.692, Longitude = -3.339 },
                Range = 10
            };
            //Act 
            var result = await sut.GetDeals(filters);

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<List<DealDTO>>(result);
            Assert.Empty(result);

        }
        [Fact]
         public async Task Should_Return_List_Of_Deals_Meeting_Filter_Requirements()
        {
            //Arrange 
             var filters = new UserFilters() {
                 Category= 0,
                 Location = new LocationDTO(){Latitude=51.692,Longitude=-3.339},
                 Range = 10
             };

            //Act 
             var result = await sut.GetDeals(filters);

            //Assert
             Assert.NotNull(result);
             Assert.IsAssignableFrom<List<DealDTO>>(result);
            
        }

     
    }
}
