using Journey.ApplicationServices;
using Journey.ApplicationServices.Shared.Journey.Dto;
using Journey.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Journey.Test
{
    [TestFixture]
    public class Tests
    {
        protected TestServer server;

        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            
        }

        [Test, Order(0)]
        public async Task GetByIdIncorrect()
        {

            var response = await server.CreateRequest("/Journey/3").SendAsync("GET");

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Test, Order(1)]
        public async Task AddInstance()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "/Journey");
            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, string>()
            {
                { "destinationId", "1" },
                {"originId", "1"},
                {"departure", "2022-08-25T17:27:50.306Z"},
                {"arrival", "2022-08-25T17:27:50.306Z"  }
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
            var response = await server.CreateRequest("/Journey").SendAsync("GET");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test, Order(3)]
        public async Task GetById()
        {

            var response = await server.CreateRequest("/Journey/1").SendAsync("GET");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [Test, Order(4)]
        public async Task UpdateElement()
        {

            var request = new HttpRequestMessage(HttpMethod.Put, "/Journey/1");
            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, string>()
            {
                {"id", "1" },
                { "destinationId", "3" },
                {"originId", "2"},
                {"departure", "2022-08-25T17:27:50.306Z"},
                {"arrival", "2022-08-25T17:27:50.306Z"  }
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
            var response = await server.CreateRequest("/Journey/1").SendAsync("Delete");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}