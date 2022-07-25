using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.ApplicationServices.Journies
{
    public interface IJourneyAppService
    {
        Task<Core.Entities.Journey> GetJourneyById(int journeyId);
    }
}
