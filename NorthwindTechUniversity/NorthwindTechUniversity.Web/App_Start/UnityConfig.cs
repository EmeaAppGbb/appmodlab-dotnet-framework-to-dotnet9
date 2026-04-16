using System;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;
using NorthwindTechUniversity.Web.Data;
using NorthwindTechUniversity.Web.Data.Repositories;
using NorthwindTechUniversity.Web.Models;

namespace NorthwindTechUniversity.Web.App_Start
{
    public static class UnityConfig
    {
        // Legacy: Code-based DI configuration (modern apps would use built-in DI)
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            
            // Register DbContext with per-request lifetime
            container.RegisterType<NorthwindTechContext>(new HierarchicalLifetimeManager());
            
            // Register repositories
            container.RegisterType<IRepository<Student>, StudentRepository>();
            container.RegisterType<IRepository<Course>, CourseRepository>();
            container.RegisterType<UnitOfWork>();
            
            // Set resolver for MVC
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
