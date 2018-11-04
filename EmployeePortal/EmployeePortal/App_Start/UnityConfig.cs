using EmployeePortal.Interfaces;
using EmployeePortal.Repositories;
using EmployeePortal.ViewModel;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace EmployeePortal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRepository<EmployeeViewModel>, EmployeeRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}