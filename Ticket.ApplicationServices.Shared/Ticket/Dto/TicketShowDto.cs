using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ticket.ApplicationServices.Shared.Ticket.Dto
{
    public class TicketShowDto
    {
        [Required]
        public Core.Entities.Journey Journey { get; set; }

        [Required]
        public Core.Entities.Passenger Passenger { get; set; }

        [Required]
        public int Seat { get; set; }
    }
}
