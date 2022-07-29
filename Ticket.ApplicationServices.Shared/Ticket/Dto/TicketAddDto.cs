using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.ApplicationServices.Shared.Ticket.Dto
{
    public class TicketAddDto
    {
        [Required]
        public int JourneyId { get; set; }

        [Required]
        public int PassengerId { get; set; }

        [Required]
        public int Seat { get; set; }
    }
}
