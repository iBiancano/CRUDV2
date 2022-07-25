using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.DataAccess
{
    public class TicketDataContext : DbContext
    {
        public virtual DbSet<Ticket.Core.Entities.Ticket> Tickets { get; set; }
        public TicketDataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
