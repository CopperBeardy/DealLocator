using DealLocator.API.Helpers;
using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace DeaLocator.Tests.Helpers
{

    [ExcludeFromCodeCoverage]
    public class GeoFenceHelperTests
    {
        List<List<double>> coords;
        public GeoFenceHelperTests()
        {
            coords = SetupCoordsList();
        }

        [Fact]
        public void Should_Return_String_If_coords_is_not_null()
        {
            //Arrange
            //Act
            var result = GeoFenceHelper.CreateRangeCheckJsonBody(coords);

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<string>(result);

        }

        [Fact]
        public void Should_Distance_as_a_double()
        {
            //Arrange
            LocationDTO location = new LocationDTO() { Longitude = 3.33, Latitude = 3.33 };
            var temp = new FilterDeal() { DealId = Guid.NewGuid(), LocationDto = location };


            //Act
            var result = GeoFenceHelper.FindRange(SetGeoFenceBody(), temp);

            //Assert
            Assert.IsType<int>(result);
            Assert.InRange(result, -1000, 1000);
        }

        [Fact]
        public void Should_Throw_Exception_When_Bad_Data_Passed()
        {
            //Arrange
            LocationDTO location = new LocationDTO() { Longitude = 3.33, Latitude = 3.33 };
            var temp = new FilterDeal() { DealId = Guid.NewGuid(), LocationDto = location };

            //Act
            var result = Record.Exception(() => GeoFenceHelper.FindRange("", temp));

            Assert.IsType<Exception>(result);
        }


        private List<List<double>> SetupCoordsList()
        {
            var temp = new List<double>() { 3.33, 4.33 };
            var temp2 = new List<double>() { 4.33, 3.33 };
            var temp3 = new List<double>() { 5.33, 2.33 };
            var temp4 = new List<double>() { 6.33, 1.33 };

            return new List<List<double>>() { temp, temp2, temp3, temp4 };

        }


        private string SetGeoFenceBody()
        {
            return "{\"type\":\"FeatureCollection\",\"features\":[{\"type\":\"Feature\",\"properties\":{\"geometryId\":\"79c007d9-fe63-4343-81ca-1ab29dff8497\"},\"geometry\":{\"type\":\"Polygon\",\"coordinates\":[[[51.691624992145492,-3.3390599999999941],[51.691624127634036,-3.3390512373690671],[51.69162156732235,-3.3390428114810464],[51.691617409601776,-3.3390350461381026],[51.691611814251182,-3.3390282397580306],[51.691604996296753,-3.339022653906238],[51.691597217748672,-3.3390185032438811],[51.691588777532154,-3.3390159472786149],[51.69158,-3.339015084234771],[51.691571222467857,-3.3390159472786149],[51.691562782251331,-3.3390185032438811],[51.691555003703257,-3.339022653906238],[51.691548185748829,-3.3390282397580306],[51.691542590398228,-3.3390350461381026],[51.691538432677653,-3.3390428114810464],[51.691617409601776,-3.3390849538612746],[51.69162156732235,-3.3390771885186616],[51.691624127634036,-3.3390687626308573],[51.691624992145492,-3.3390599999999941]]]}}]}"; 
         }
    }
}
