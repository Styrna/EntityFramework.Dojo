using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using EntityFramework.Data;
using Microsoft.Practices.Unity;
using Unity.WebApi;
using WebApplication1.Dal;
using WebApplication1.Log;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ITeacherDal, TeacherDal>();
            container.RegisterType<IContextFactory, ContextFactory>();
            config.DependencyResolver = new UnityDependencyResolver(container);

            // Web API configuration and services
            config.Services.Replace(typeof(IExceptionLogger), new HttpExcptionLogger());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
