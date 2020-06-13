using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Fundamentos_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Fundamentos_MVC
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            //Cambiando de referencia
            //builder.RegisterType<InMemoryRestaurantData>()
            builder.RegisterType<SqlRestaurantData>()
                .As<IRestaurantData>()
                //.SingleInstance();
                .InstancePerRequest();
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}