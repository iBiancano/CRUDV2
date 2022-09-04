using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.ApplicationServices.Journies
{
    public class JourneyAppService : IJourneyAppService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public JourneyAppService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Core.Entities.Journey> GetJourneyById(int journeyId)
        {
            HttpClient client = _httpClientFactory.CreateClient("journeyDevelopment");
            HttpResponseMessage response;
            string url = "journey";
            
            response = await client.GetAsync($"{url}/{journeyId}");

            Core.Entities.Journey journey;

            if (response.IsSuccessStatusCode)
            {
                journey = Newtonsoft.Json.JsonConvert.DeserializeObject<Core.Entities.Journey>(await response.Content.ReadAsStringAsync());
                return journey;
            }
            else
            {
                return null;
            }
        }
    }
}
