using Journey.ApplicationServices;
using Journey.ApplicationServices.Shared.Journey.Dto;
using Journey.Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Journey.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyAppService _journiesAppService;


        public JourneyController(IJourneyAppService journeyAppService)
        {
            _journiesAppService = journeyAppService;
        }


        // GET: api/<JourneyController>
        [HttpGet]
        public async Task<IEnumerable<JourneyDto>> Get()
        {
            return await _journiesAppService.GetJourneysAsync();
        }

        // GET api/<JourneyController>/5
        [HttpGet("{id}")]
        public async Task<JourneyDto> Get(int id)
        {
            return await _journiesAppService.GetJourneyById(id);
        }

        // POST api/<JourneyController>
        [HttpPost]
        public async Task Post(JourneyAddDto entity)
        {
            await _journiesAppService.AddJourneyAsync(entity);
        }

        // PUT api/<JourneyController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, JourneyDto journey)
        {
            await _journiesAppService.EditJourneyAsync(journey);
        }

        // DELETE api/<JourneyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _journiesAppService.DeleteJourneyAsync(id);
        }
    }
}
