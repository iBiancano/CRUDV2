using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.ApplicationServices.Shared.Journey.Dto
{
    public class JourneyDto
    {
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number!")]
        public int DestinationId { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number!")]
        public int OriginId { get; set; }
        [Required]
        public DateTime Departure { get; set; }
        [Required]
        public DateTime Arrival { get; set; }
    }
}
