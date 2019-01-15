using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using _2C2PWebAPI.Service.Interface;
using _2C2PWebAPI.Service;
using _2C2PDB.Model;
using _2C2PDB.Repository.Interface;
using _2C2PDB.Repository;

namespace _2C2PWebAPI.App_Start
{
    public class InjectorConfig
    {
        public static void Initialize()
        {
            // Create a new Simple Injector container
            var container = new Container();

            // Set default Lifestyle
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register Service
            container.Register<ICustomerService, CustomerService>();

            // Register Repository
            container.Register<IRepository<Customer, Guid>, Repository<Customer, Guid>>(Lifestyle.Scoped);
            container.Register<IRepository<Transaction, Guid>, Repository<Transaction, Guid>>(Lifestyle.Scoped);

            // Register Context
            container.Register<DBContext, DBContext>(Lifestyle.Scoped);


            // Register MVC Controller(IController) and Web API Controller(IHTTPController)
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // Verify Config
            container.Verify();

            // Store the container for use by the application
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}