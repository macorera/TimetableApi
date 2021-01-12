using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TimetableApi.Test
{
    
    public class TimetableControllerTest : IClassFixture<WebTestFixture>
    {
        public HttpClient client { get; }
        
        public TimetableControllerTest(WebTestFixture factory)
        {
            client = factory.CreateClient();
        }

        [Fact]
        public async Task RequestTimetableWithIncorrectPath()
        {
            //Arrange

            //Act
            var response = await client.GetAsync("/api/incorrect/1");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task RequestTimetableForStudent()
        {
            //Arrange

            //Act
            var response = await client.GetAsync("/api/students/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
