using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.ApplicationServices.Passenger
{
    public interface IPassengerAppService
    {
        Task<Core.Entities.Passenger> GetPassengerById(int passengerId);
    }
}
