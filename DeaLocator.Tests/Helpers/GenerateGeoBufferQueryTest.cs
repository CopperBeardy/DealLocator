using DealLocator.API.Helpers;
using Domain;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace DeaLocator.Tests.Helpers
{
    [ExcludeFromCodeCoverage]
    public class GenerateGeoBufferQueryTest
    {
        [Theory]
        [InlineData(5, 55.3, -2.3)]
        [InlineData(3, 10.32323, -7.32323)]
        [InlineData(1, 43.432423, 2.3324)]
        [InlineData(11, 60.342342, 4.493343)]
        public async void Should_Return_Buffer_Coordinate_List(int range, double latitude, double longitude)
        {
            //act
            var result = await GenerateGeoBufferQuery.GenerateBuffer(
                range,
                new LocationDTO()
                {
                    Latitude = latitude,
                    Longitude = longitude
                }
                );

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<List<List<double>>>(result);

        }
        [Theory]

        [InlineData(3, 0.0, -7.32323)]
        [InlineData(1, 43.432423, 0.0)]
        public async void Should_return_null_On_Bad_Data(int range, double latitude, double longitude)
        {
            //act

            var result = await Record.ExceptionAsync(() => GenerateGeoBufferQuery.GenerateBuffer(
                range,
                new LocationDTO()
                {
                    Latitude = latitude,
                    Longitude = longitude
                }
                ));

            //Assert

            Assert.Null(result);
        }
    }
}
