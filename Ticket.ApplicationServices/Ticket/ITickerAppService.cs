using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.ApplicationServices.Shared.Ticket.Dto;

namespace Ticket.ApplicationServices.Ticket
{
    public interface ITickerAppService
    {
        Task<int> AddTicketAsync(TicketAddDto entity);

        Task EditTicketAsync(TicketDto entity);

        Task DeleteTicketAsync(int ticketId);

        Task<TicketShowDto> GetTicketById(int ticketId);

        Task<List<TicketDto>> GetTicketsAsync();
    }
}
