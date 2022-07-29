using Microsoft.AspNetCore.Mvc;
using Ticket.ApplicationServices.Shared.Ticket.Dto;
using Ticket.ApplicationServices.Ticket;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ticket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly ITickerAppService _ticketAppService;

        public TicketController(ITickerAppService tickerAppService)
        {
            _ticketAppService = tickerAppService;
        }

        // GET: api/<TicketController>
        [HttpGet]
        public async Task<IEnumerable<TicketDto>> Get()
        {
            return await _ticketAppService.GetTicketsAsync();
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public async Task<TicketShowDto> Get(int id)
        {
            return await _ticketAppService.GetTicketById(id);
        }

        // POST api/<TicketController>
        [HttpPost]
        public async Task Post(TicketAddDto entity)
        {
            await _ticketAppService.AddTicketAsync(entity);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public async Task Put(TicketDto ticketDto)
        {
            await _ticketAppService.EditTicketAsync(ticketDto);
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ticketAppService.DeleteTicketAsync(id);
        }
    }
}
