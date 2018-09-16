using Autofac;
using Railway.Data;

namespace Railway.Services.Infrastructure
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PassengerService>().InstancePerRequest();
            builder.RegisterType<RailwayContext>().InstancePerRequest();
        }
    }
}
