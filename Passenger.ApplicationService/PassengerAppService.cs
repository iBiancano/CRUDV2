using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Passenger.ApplicationServices.Shared.Passenger.Dto;
using Passenger.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.ApplicationServices
{
    public class PassengerAppService : IPassengerAppService
    {
        public readonly IRepository<int, Passenger.Core.Entities.Passenger> _repository;
        private readonly IMapper _mapper;

        public PassengerAppService(IRepository<int, Passenger.Core.Entities.Passenger> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> AddPassengerAsync(PassengerAddDto entity)
        {
            Passenger.Core.Entities.Passenger passenger = _mapper.Map<Passenger.Core.Entities.Passenger>(entity);
            await _repository.AddAsync(passenger);
            return passenger.Id;
        }

        public async Task DeletePassengerAsync(int passengerId)
        {
            await _repository.DeleteAsync(passengerId);
        }

        public async Task EditPassengerAsync(PassengerDto entity)
        {
            Passenger.Core.Entities.Passenger passenger = _mapper.Map<Passenger.Core.Entities.Passenger>(entity);
            await _repository.UpdateAsync(passenger);
        }

        public async Task<PassengerDto> GetPassengerById(int passengerId)
        {
            Passenger.Core.Entities.Passenger passenger = await _repository.GetAsync(passengerId);
            return _mapper.Map<PassengerDto>(passenger);
        }

        public async Task<List<PassengerDto>> GetPassengersAsync()
        {
            List<Passenger.Core.Entities.Passenger> passengers = await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<PassengerDto>>(passengers);
        }
    }
}
