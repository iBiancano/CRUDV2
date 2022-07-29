using Journey.ApplicationServices.Shared.Journey.Dto;
using Journey.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.ApplicationServices
{
    public interface IJourneyAppService
    {

        Task<int> AddJourneyAsync(JourneyAddDto entity);

        Task EditJourneyAsync(JourneyDto entity);

        Task DeleteJourneyAsync(int journeyId);

        Task<JourneyDto> GetJourneyById(int journeyId);

        Task<List<JourneyDto>> GetJourneysAsync();
    }
}
