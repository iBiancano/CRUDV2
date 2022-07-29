using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.ApplicationServices.Shared.Ticket.Dto;

namespace Ticket.ApplicationServices
{
    public class MapperTicket : Profile
    {
        public MapperTicket()
        {
            CreateMap<Core.Entities.Ticket, TicketDto>();
            CreateMap<TicketDto, Core.Entities.Ticket>();
            CreateMap<TicketAddDto, Core.Entities.Ticket>();
            CreateMap<TicketShowDto, Core.Entities.Ticket>();
        }
    }
}
