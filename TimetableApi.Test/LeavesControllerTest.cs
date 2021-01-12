using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TimetableApi.Test
{
    public class LeavesControllerTest : IClassFixture<WebTestFixture>
    {
        public HttpClient client { get; }

        public LeavesControllerTest(WebTestFixture factory)
        {
            client = factory.CreateClient();
        }

        [Fact]
        public async Task CrateLeaveRequest()
        {
            //Arrange

            //Act

           string jsonString = "{\"teacherId\": 1,\"from\": \"2020-01-11T00:00:00\",\"to\": \"2020-01-11T23:59:59\"}";

            var response = await client.PostAsync("/api/leaves", new StringContent(jsonString, Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        
    }
}
