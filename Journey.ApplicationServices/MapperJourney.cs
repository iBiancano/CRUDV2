using AutoMapper;
using Journey.ApplicationServices.Shared.Journey.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.ApplicationServices
{
    public class MapperJourney : Profile
    {
        public MapperJourney()
        {
            CreateMap<Core.Entities.Jorney, JourneyDto>();
            CreateMap<JourneyDto, Core.Entities.Jorney>();
            CreateMap<JourneyAddDto, Core.Entities.Jorney>();
        }
    }
}

