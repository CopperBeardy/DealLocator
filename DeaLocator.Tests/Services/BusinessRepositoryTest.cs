using DealLocator.Models;
using DealLocator.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DeaLocator.Tests.Services
{
    [ExcludeFromCodeCoverage]
    public class BusinessRepositoryTest
    {
        private readonly IBusinessRepository sut;
        private readonly DealLocatorDbContext context;
        
        public BusinessRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<DealLocatorDbContext>()
          .UseInMemoryDatabase(databaseName: "LocationDatabase")
          .Options;
            context = new DealLocatorDbContext(options);
            sut = new BusinessRepository(context);
        }

        [Fact]
        public async Task Should_Return_True_When_Valid_Values_In_Address_List_sent()
        {

            //arrange
            List<string> values = new List<string> { "47", "Cardiff Road", "Troedyrhiw", "CF48 4JZ" };

            //act
            var result = await sut.NewBusiness(values, Guid.NewGuid());

            //assert
            Assert.True(result);
        }

        [Fact]
        public async Task Should_False_Return_With_Invalid_Address_List()
        {

            //arrange
            List<string> values = new List<string> { };

            //act

            var exception = await Record.ExceptionAsync(() => sut.NewBusiness(values, Guid.NewGuid()));
            //assert
            Assert.IsType<Exception>(exception);

        }







    }
}
