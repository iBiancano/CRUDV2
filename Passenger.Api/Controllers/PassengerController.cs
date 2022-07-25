using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passenger.ApplicationServices;
using Passenger.ApplicationServices.Shared.Passenger.Dto;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {

        private readonly IPassengerAppService _passengerAppService;

        public PassengerController(IPassengerAppService passengerAppService)
        {
            _passengerAppService = passengerAppService;
        }

        // GET: api/<ControllerController>
        [HttpGet]
        public async Task<IEnumerable<PassengerDto>> Get()
        {
            return await _passengerAppService.GetPassengersAsync();
        }

        // GET api/<PassengerController>/5
        [HttpGet("{id}")]
        public async Task<PassengerDto> Get(int id)
        {
            return await _passengerAppService.GetPassengerById(id);
        }

        // POST api/<PassengerController>
        [HttpPost]
        public async Task Post(PassengerAddDto entity)
        {
            await _passengerAppService.AddPassengerAsync(entity);
        }

        // PUT api/<PassengerController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, PassengerDto entity)
        {
            await _passengerAppService.EditPassengerAsync(entity);
        }

        // DELETE api/<PassengerController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _passengerAppService.DeletePassengerAsync(id);
        }
    }
}
