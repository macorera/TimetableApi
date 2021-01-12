using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using TimetableApi.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;

namespace TimetableApi.Test
{
    public class IntegrationTest 
    {
        /*protected readonly HttpClient testClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(TimetableContext));
                        services.AddDbContext<TimetableContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });
            testClient = appFactory.CreateClient();
        }*/
    }
}
