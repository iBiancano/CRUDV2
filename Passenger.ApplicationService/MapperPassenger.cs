using AutoMapper;
using Passenger.ApplicationServices.Shared.Passenger.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.ApplicationServices
{
    public class MapperPassenger : Profile
    {
        public MapperPassenger()
        {
            CreateMap<Core.Entities.Passenger, PassengerDto>();
            CreateMap<PassengerDto, Core.Entities.Passenger>();
            CreateMap<PassengerAddDto, Core.Entities.Passenger>();
        }
    }
}
