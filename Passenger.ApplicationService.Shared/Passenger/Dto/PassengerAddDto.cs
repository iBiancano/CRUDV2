using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.ApplicationServices.Shared.Passenger.Dto
{
    public class PassengerAddDto
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [Range(0, 150, ErrorMessage = "Please enter a valid age!")]
        public int Age { get; set; }
    }
}
