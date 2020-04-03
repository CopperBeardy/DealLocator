using DealLocator.Controllers;
using DealLocator.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DeaLocator.Tests.Controllers
{
    [ExcludeFromCodeCoverage]
    public class DealControllerTests
    {
        private readonly DealController sut;

        private readonly Mock<IDealRepository> _dealRepository;
        public DealControllerTests()
        {
            _dealRepository = new Mock<IDealRepository>();
            sut = new DealController(_dealRepository.Object);
        }


        private List<Deal> FakeDeals()
        {
            return new List<Deal>()
            {
                 new Deal{
                    Id = It.IsAny<Guid>(),
                    Title =It.IsAny<string>(),
                    Description = It.IsAny<string>(),
                    Duration = It.IsAny<int>(),
                    StartDate =It.IsAny<DateTime>(),
                    EndDate = It.IsAny<DateTime>(),
                    BusinessId = It.IsAny<Guid>(),
                    DealStatus= It.IsAny<DealStatus>(),
                    Category = It.IsAny<Category>()
                 },
                new Deal{
                    Id = It.IsAny<Guid>(),
                    Title =It.IsAny<string>(),
                    Description = It.IsAny<string>(),
                    Duration = It.IsAny<int>(),
                    StartDate =It.IsAny<DateTime>(),
                    EndDate = It.IsAny<DateTime>(),
                    BusinessId = It.IsAny<Guid>(),
                    DealStatus= It.IsAny<DealStatus>(),
                    Category = It.IsAny<Category>()
                }
            };
        }


        [Fact]
        public async void Should_Return_List_of_deals_for_the_current_user_id_if_deals_exist()
        {

            //Arrange                     
            var deals = FakeDeals();
            _dealRepository.Setup(x => x.GetDealsById(It.IsAny<Guid>())).ReturnsAsync(deals);

            //Act
            var result = await sut.Index(Guid.NewGuid());

            //Assert          
            var viewResult = Assert.IsType<ViewResult>(result);

            IEnumerable<Deal> model = Assert.IsAssignableFrom<IEnumerable<Deal>>(viewResult.ViewData.Model);

        }

        [Fact]
        public async void Should_Return_nothing_for_the_current_user_id__if_no_deals_exist()
        {

            //Arrange                    

            _dealRepository.Setup(x => x.GetDealsById(It.IsAny<Guid>())).ReturnsAsync(new List<Deal>());

            //Act
            var result = await sut.Index(Guid.NewGuid());

            //Assert          
            var viewResult = Assert.IsType<ViewResult>(result);
            IEnumerable<Deal> model = Assert.IsAssignableFrom<IEnumerable<Deal>>(viewResult.ViewData.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Should_Return_view_for_creating_a_deal()
        {
            //Arrange
            var id = Guid.NewGuid();
            //Act
            var result = sut.Create(id);

            //Assert          
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(id, viewResult.ViewData["BusinessId"]);
            var categories = viewResult.ViewData["Categories"];
            Assert.NotNull(categories);
        }

        [Fact]
        public async void Should_Return_deal_which_corresponds_to_the_Deal_Id()
        {
            var deal = FakeDeals().FirstOrDefault();
            var id = Guid.NewGuid();
            deal.Id = id;
            //Arrange 
            _dealRepository.Setup(x => x.GetDealById(It.IsAny<Guid>())).ReturnsAsync(deal);


            //Act
            var result = await sut.Details(id);

            //Assert          
            var viewResult = Assert.IsType<ViewResult>(result);
            Deal model = Assert.IsAssignableFrom<Deal>(viewResult.ViewData.Model);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public async void Should_Return_Correct_Deal_to_cancel()
        {

            var deal = FakeDeals().FirstOrDefault();
            var id = Guid.NewGuid();
            deal.Id = id;
            //Arrange 
            _dealRepository.Setup(x => x.GetDealById(It.IsAny<Guid>())).ReturnsAsync(deal);


            //Act
            var result = await sut.Cancel(id);

            //Assert          
            var viewResult = Assert.IsType<ViewResult>(result);
            Deal model = Assert.IsAssignableFrom<Deal>(viewResult.ViewData.Model);
            Assert.Equal(id, model.Id);
        }


        [Fact]
        public async void Should_Return_NoFound_if_deal_cannot_be_found_using_id()
        {

            var deal = FakeDeals().FirstOrDefault();
            var id = Guid.NewGuid();
            deal.Id = id;
            //Arrange 
            _dealRepository.Setup(x => x.GetDealById(It.IsAny<Guid>())).Returns(Task.FromResult<Deal>(null));

            //Act
            var result = await sut.Cancel(id);

            //Assert   
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public async void Should_fail_to_Create_and_insert_invalid_new_deal_into_database()
        {

            //Arrange
            Deal testDeal = new Deal();
            sut.ModelState.AddModelError("invalid", "invalid state");
            //Act
            var result = await sut.Create(testDeal);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
            Assert.IsAssignableFrom<Deal>(viewResult.Model);


        }


        [Fact]
        public async void Should_change_deal_from_active_to_cancelled()
        {
            var id = Guid.NewGuid();
            //Arrange
            var deal = FakeDeals().FirstOrDefault();
            deal.Id = id;
            deal.DealStatus = DealStatus.Active;
            _dealRepository.Setup(x => x.CancelDeal(It.IsAny<Guid>())).ReturnsAsync(deal);
            //Act
            var result = await sut.CancelConfirmed(id);

         
            //Assert

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            _dealRepository.Verify(x => x.CancelDeal(It.IsAny<Guid>()), Times.Once);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            

        }


    }
}
