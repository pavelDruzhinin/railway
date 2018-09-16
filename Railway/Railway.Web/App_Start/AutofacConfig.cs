using Autofac;
using Autofac.Integration.Mvc;
using Railway.Services.Infrastructure;
using System.Reflection;
using System.Web.Mvc;

namespace Railway.Web
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // Register the common controllers.
            builder.RegisterControllers(typeof(Global).Assembly);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register the Web API controllers.
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule<ServicesModule>();

            var container = builder.Build();

            // MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Webapi
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}