using DealLocator.Controllers;
using DealLocator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


namespace DeaLocator.Tests.Controllers
{
    [ExcludeFromCodeCoverage]
    public class HomeControllerTests
    {

        private readonly HomeController sut;
        private readonly Mock<IBusinessRepository> _businessRepository;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;

        public HomeControllerTests()
        {
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _businessRepository = new Mock<IBusinessRepository>();
            sut = new HomeController(_businessRepository.Object, _httpContextAccessor.Object);
        }

        [Fact]
        public async Task Should_Return_Index_When_Not_AuthenticatedAsync()
        {

            // arrange
            _httpContextAccessor.Setup(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(false);

            //act
            var result = await sut.Index();

            //assert
            Assert.IsType<ViewResult>(result);


        }

        [Fact]
        public async Task UpdateBusiness_Completed_Successfully()
        {

            //arrange
            string id = new Guid().ToString();
            List<string> claims = new List<string>() { " ", " " };
            _httpContextAccessor.Setup(x => x.HttpContext.User.FindFirst(It.IsAny<string>()))
                .Returns(new Claim("NameIdentifier", id));
            _businessRepository.Setup(x => x.GetBusinessExist(It.IsAny<Guid>())).ReturnsAsync(true);

            //act
            await sut.CheckBusiness(claims);

            //assert

            _businessRepository.Verify(x => x.UpdateBusiness(It.IsAny<List<string>>(), It.IsAny<Guid>()), Times.Once);

        }

        [Fact]
        public async Task NewBusiness_Completed_Successfully()
        {

            //arrange
            string id = new Guid().ToString();
            List<string> claims = new List<string>() { " ", " " };
            _httpContextAccessor.Setup(x => x.HttpContext.User.FindFirst(It.IsAny<string>()))
                .Returns(new Claim("NameIdentifier", id));
            _businessRepository.Setup(x => x.GetBusinessExist(It.IsAny<Guid>())).ReturnsAsync(false);

            //act
            await sut.CheckBusiness(claims);

            //assert

            _businessRepository.Verify(x => x.NewBusiness(It.IsAny<List<string>>(), It.IsAny<Guid>()), Times.Once);

        }


    }
}