using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Ticket.Test
{
    public class Tests
    {
        protected TestServer server;

        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        [Test, Order(1)]
        public async Task AddInstance()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "api/Ticket");
            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, string>()
            {
                { "journeyId", "6" },
                {"passengerId", "12"},
                {"seat", "31"}
            }), Encoding.Default, "application/json");

            var client = server.CreateClient();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [Test, Order(2)]
        public async Task GetAll()
        {
            var response = await server.CreateRequest("api/Ticket").SendAsync("GET");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [Test, Order(4)]
        public async Task UpdateElement()
        {

            var request = new HttpRequestMessage(HttpMethod.Put, "api/Ticket/1");
            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, string>()
            {
                {"id", "1" },
                {"journeyId", "6" },
                {"passengerId", "12"},
                {"seat", "31"}
            }), Encoding.Default, "application/json");

            var client = server.CreateClient();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test, Order(5)]
        public async Task DeleteElement()
        {
            var response = await server.CreateRequest("api/Ticket/1").SendAsync("Delete");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}