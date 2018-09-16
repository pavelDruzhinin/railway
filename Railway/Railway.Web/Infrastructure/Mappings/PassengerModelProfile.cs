using AutoMapper;
using Railway.Services.Dto;
using Railway.Web.Models;

namespace Railway.Web.Infrastructure.Mappings
{
    public class PassengerModelProfile : Profile
    {
        public PassengerModelProfile()
        {
            CreateMap<PassengerModel, PassengerDto>();
            CreateMap<PassengerDto, PassengerModel>();
        }
    }
}