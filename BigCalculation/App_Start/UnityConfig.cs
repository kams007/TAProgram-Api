using BigCalculation.DBContext;
using BigCalculation.Repositories;
using BigCalculation.Repositories.Interfaces;
using System;
using System.Data.Entity;
using System.Web.Http;
using BigCalculation.Services.Interfaces;
using Unity;
using Unity.WebApi;
using BigCalculation.Services;

namespace BigCalculation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
           //// GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        internal static IUnityContainer GetConfiguredContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<DbContext, CalculationDbContext>();
            container.RegisterType(typeof(ICalculationService), typeof(CalculationService));
            container.RegisterType(typeof(IUserService), typeof(UserService));
            container.RegisterType(typeof(IUserRepository), typeof(UserRepository));
            container.RegisterType(typeof(ICalculationRepository), typeof(CalculationRepository));
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            return container;
        }
    }
}