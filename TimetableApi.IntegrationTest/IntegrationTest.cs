using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TimetableApi.IntegrationTest
{
    public class IntegrationTest
    {
        protected readonly HttpClient testClient;
        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            testClient = appFactory.CreateClient();
        }

        
    }
}
