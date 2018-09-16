using AutoMapper;
using Railway.Services.Infrastructure.MapProfiles;
using Railway.Web.Infrastructure.Mappings;

namespace Railway.Web
{
    public static class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<PassengerDtoProfile>();
                cfg.AddProfile<PassengerModelProfile>();
            });
        }
    }
}
