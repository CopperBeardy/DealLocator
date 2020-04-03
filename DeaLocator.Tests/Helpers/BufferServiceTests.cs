using DealLocator.API.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace DeaLocator.Tests.Helpers
{
    public class BufferServiceTests
    {
        [ExcludeFromCodeCoverage]
        public BufferServiceTests()
        {

        }

        [Theory]
        [InlineData("{\"geometries\": {\"type\": \"FeatureCollection\",\"features\": [{\"type\": \"Feature\",\"properties\": {\"geometryId\": \"ExeId\"},\"geometry\": {\"type\": \"Point\",\"coordinates\": [51.69158,-3.33906]}}]},\"distances\": [5]}")]
        [InlineData("{\"geometries\": {\"type\": \"FeatureCollection\",\"features\": [{\"type\": \"Feature\",\"properties\": {\"geometryId\": \"ExeId\"},\"geometry\": {\"type\": \"Point\",\"coordinates\": [51.69158,-3.33906]}}]},\"distances\": [10]}")]
        [InlineData("{\"geometries\": {\"type\": \"FeatureCollection\",\"features\": [{\"type\": \"Feature\",\"properties\": {\"geometryId\": \"ExeId\"},\"geometry\": {\"type\": \"Point\",\"coordinates\": [163.69158,4.33906]}}]},\"distances\": [5]}")]
        public async Task Should_Return_List_Of_Coordinates(string body)
        {


            //Act
            var result = await BufferService.GetBuffer(body);

            //Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<List<List<double>>>(result);
        }

        [Fact]
        public async Task Should_throw_exception_when_given_incorrect_data()
        {
            //Arrange
            string body = "{\"type\": \"FeatureCollection\",\"features\": [{\"type\": \"Feature\",\"properties\": {\"geometryId\": \"ExeId\"},\"geometry\": {\"type\": \"Point\",\"coordinates\": [51.69158,-3.33906]}}]},\"distances\": [5]}";


            //Act

            var result = await Record.ExceptionAsync(() => BufferService.GetBuffer(body));

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Exception>(result);
        }


    }
}
