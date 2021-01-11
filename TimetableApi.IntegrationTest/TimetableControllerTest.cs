using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TimetableApi.Dtos;
using System.Net.Http;
using Xunit;

namespace TimetableApi.IntegrationTest
{
    public class TimetableControllerTest : IntegrationTest
    {
        [Fact]
        public async Task GetTimetablesWithoutPath()
        {
            //Arrange

            //Act
            var response = await testClient.GetAsync("/students");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            

        }
    }
}
