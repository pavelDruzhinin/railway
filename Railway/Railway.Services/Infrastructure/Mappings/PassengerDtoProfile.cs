using AutoMapper;
using Railway.Domain;
using Railway.Services.Dto;

namespace Railway.Services.Infrastructure.MapProfiles
{
    public class PassengerDtoProfile : Profile
    {
        public PassengerDtoProfile()
        {
            CreateMap<PassengerDto, Passenger>();
            CreateMap<Passenger, PassengerDto>();
        }

    }
}
