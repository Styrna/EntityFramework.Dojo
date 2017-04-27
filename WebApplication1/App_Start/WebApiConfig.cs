using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
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


            // Variables used to store the available completion port thread counts. 
            int workerThreads, completionPortThreads;
            // Variables used to store the min. and max. worker thread counts. 
            int minWorkerThreads, maxWorkerThreads;
            // Variables used to store the min. and max. completion port thread counts. 
            int minCompletionPortThreads, maxCompletionPortThreads;

            // Query the number of available threads in the app pool. 
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            // Query the minimum number of threads in the app pool. 
            ThreadPool.GetMinThreads(out minWorkerThreads, out minCompletionPortThreads);
            // Query the maximum number of threads that can be in the app pool. 
            ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxCompletionPortThreads);

            // Set the maximum number of threads available in the app pool. 
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(5, 5);

            ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxCompletionPortThreads);

            HttpContext.Current.Server.ScriptTimeout = 10;

            // Web API configuration and services
            config.Services.Replace(typeof(IExceptionLogger), new HttpExcptionLogger());
            config.MessageHandlers.Add(new HttpLogger());
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
