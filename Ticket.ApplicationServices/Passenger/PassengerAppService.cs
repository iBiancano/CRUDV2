using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.ApplicationServices.Passenger
{
    public class PassengerAppService : IPassengerAppService
    {
        private IHttpClientFactory _httpClientFactory;

        public PassengerAppService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Core.Entities.Passenger> GetPassengerById(int passengerId)
        {
            HttpClient client = _httpClientFactory.CreateClient("passengerDevelopment");
            HttpResponseMessage response;
            string url = "passenger";

            response = await client.GetAsync($"{url}/{passengerId}");

            Core.Entities.Passenger passenger;

            if (response.IsSuccessStatusCode)
            {
                passenger = Newtonsoft.Json.JsonConvert.DeserializeObject<Core.Entities.Passenger>(await response.Content.ReadAsStringAsync());
                return passenger;
            }
            else
            {
                return null;
            }
        }
    }
}
