using Microsoft.Practices.Unity;
using SpaUserControl.Business.Services;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Infraestruture.Data;
using SpaUserControl.Infraestruture.Repositories;
using System.Web.Mvc;
using Unity.Mvc3;

namespace SpaUserControl.Ux.Mvc
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}