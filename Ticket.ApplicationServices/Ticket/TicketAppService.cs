using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.ApplicationServices.Journies;
using Ticket.ApplicationServices.Passenger;
using Ticket.ApplicationServices.Shared.Ticket.Dto;
using Ticket.DataAccess;
using Ticket.DataAccess.Repositories;

namespace Ticket.ApplicationServices.Ticket
{
    public class TicketAppService : ITickerAppService
    {
        public readonly IRepository<int, Core.Entities.Ticket> _repository;
        private readonly IJourneyAppService _journeyAppService;
        private readonly IPassengerAppService _passengerAppService;
        private readonly IMapper _mapper;

        public TicketAppService(IRepository<int, Core.Entities.Ticket> repository, IMapper mapper, IJourneyAppService journeyAppService, IPassengerAppService passengerAppService)
        {
            _repository = repository;
            _journeyAppService = journeyAppService;
            _passengerAppService = passengerAppService;
            _mapper = mapper;
        }


        public async Task<int> AddTicketAsync(TicketAddDto entity)
        {
            Core.Entities.Ticket ticket = _mapper.Map<Core.Entities.Ticket>(entity);
            await _repository.AddAsync(ticket);
            return ticket.Id;
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            await _repository.DeleteAsync(ticketId);
        }

        public async Task EditTicketAsync(TicketDto entity)
        {
            Core.Entities.Ticket ticket = _mapper.Map<Core.Entities.Ticket>(entity);
            await _repository.UpdateAsync(ticket);
        }

        public async Task<TicketShowDto> GetTicketById(int ticketId)
        {
            Core.Entities.Ticket ticket = await _repository.GetAsync(ticketId);
            Core.Entities.Journey journey = await _journeyAppService.GetJourneyById(ticket.JourneyId);
            Core.Entities.Passenger passenger = await _passengerAppService.GetPassengerById(ticket.PassengerId);
            TicketShowDto ticketShowDto = _mapper.Map<TicketShowDto>(ticket);
            ticketShowDto.Journey = journey;
            ticketShowDto.Passenger = passenger;
            return ticketShowDto;
        }

        public async Task<List<TicketDto>> GetTicketsAsync()
        {
            List<Core.Entities.Ticket> tickets = await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<TicketDto>>(tickets);
        }
    }
}
