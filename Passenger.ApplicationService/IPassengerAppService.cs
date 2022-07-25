using Passenger.ApplicationServices.Shared.Passenger.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.ApplicationServices
{
    public interface IPassengerAppService
    {
        Task<int> AddPassengerAsync(PassengerAddDto entity);

        Task EditPassengerAsync(PassengerDto entity);

        Task DeletePassengerAsync(int passengerId);

        Task<PassengerDto> GetPassengerById(int passengerId);

        Task<List<PassengerDto>> GetPassengersAsync();
    }
}
