using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Journey.Core.Entities;

namespace Journey.DataAccess
{
    public class JourneyDataContext : DbContext
    {
        public virtual DbSet<Jorney> Journeys { get; set; }

        public JourneyDataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
