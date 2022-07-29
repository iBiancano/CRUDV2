using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.DataAccess
{
    public class PassengerDataContext : DbContext
    {
        public virtual DbSet<Passenger.Core.Entities.Passenger> Passengers { get; set; }
        
        public PassengerDataContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
