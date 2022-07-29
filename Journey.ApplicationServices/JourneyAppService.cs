using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Journey.ApplicationServices.Shared.Journey.Dto;
using Journey.Core.Entities;
using Journey.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Journey.ApplicationServices
{
    public class JourneyAppService : IJourneyAppService
    {
        public readonly IRepository<int, Jorney> _repository;
        private readonly IMapper _mapper;

        public JourneyAppService(IRepository<int, Jorney> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddJourneyAsync(JourneyAddDto entity)
        {
            Jorney journey = _mapper.Map<Jorney>(entity);
            await _repository.AddAsync(journey);
            return journey.Id;
        }

        public async Task DeleteJourneyAsync(int journeyId)
        {
            await _repository.DeleteAsync(journeyId);
        }

        public async Task EditJourneyAsync(JourneyDto entity)
        {
            Jorney journey = _mapper.Map<Jorney>(entity);
            await _repository.UpdateAsync(journey);   
        }

        public async Task<JourneyDto> GetJourneyById(int journeyId)
        {
            Jorney journey  = await _repository.GetAsync(journeyId);
            return _mapper.Map<JourneyDto>(journey);
        }

        public async Task<List<JourneyDto>> GetJourneysAsync()
        {
            List<Jorney> jorneys =  await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<JourneyDto>>(jorneys);
        }
    }
}
