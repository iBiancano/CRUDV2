using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Passenger.Test
{
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
            var response = await server.CreateRequest("/Passenger/1").SendAsync("GET");

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Test, Order(1)]
        public async Task AddInstance()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "/Passenger");
            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, string>()
            {
                { "firstName", "Ivan" },
                {"lastName", "Rivera"},
                {"age", "21"}
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
            var response = await server.CreateRequest("/Passenger").SendAsync("GET");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test, Order(3)]
        public async Task GetById()
        {

            var response = await server.CreateRequest("/Passenger/1").SendAsync("GET");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test, Order(4)]
        public async Task UpdateElement()
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "/Passenger/1");
            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, string>()
            {
                {"id", "1" },
                { "firstName", "Ivan" },
                {"lastName", "Blancas"},
                {"age", "22"}
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
            var response = await server.CreateRequest("/Passenger/1").SendAsync("Delete");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}