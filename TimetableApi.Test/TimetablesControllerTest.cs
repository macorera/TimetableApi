using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TimetableApi.Test
{
    
    public class TimetablesControllerTest : IClassFixture<WebTestFixture>
    {
        public HttpClient client { get; }
        
        public TimetablesControllerTest(WebTestFixture factory)
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

        [Fact]
        public async Task RequestTimetableForTeachers()
        {
            //Arrange

            //Act
            var response = await client.GetAsync("/api/teachers/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
