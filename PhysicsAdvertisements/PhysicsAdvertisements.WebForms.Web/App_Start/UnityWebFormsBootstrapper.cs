using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.App_Start
{
    //http://stackoverflow.com/questions/8947423/webforms-and-dependency-injection
    public static class UnityWebFormsBootstrapper
    {
        private static readonly IUnityContainer _container = new UnityContainer();

        public static void Initialize()
        {
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(_container));

            _container.RegisterType<IPhysicsAdvertisementsDbContext, PhysicsAdvertisementsDbContext>(new PerResolveLifetimeManager());
            _container.RegisterType<IPhysicsAreasDictionaryRepo, PhysicsAreasDictionaryRepo>(new PerResolveLifetimeManager());
            _container.RegisterType<IUserRepo, UserRepo>(new PerResolveLifetimeManager());
        }

        //Czy nie lepiej zamiast funkcji TearDown wstrzyknac do konstruktorw Register new PerResolveLifetimeManager()
        public static void TearDown()
        {
            _container.Dispose();
        }
    }
}