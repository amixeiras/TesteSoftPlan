using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TesteSoftPlanAPI.Client
{
    public class TesteSfotPlanClient : IDisposable
    {
        private readonly IConfiguration configuration;
        private HttpClient client;

        public TesteSfotPlanClient(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public HttpClient Client
        {
            get
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(configuration["urlApi"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));

                return client;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
