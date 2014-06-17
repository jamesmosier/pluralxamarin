using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//using ProteinTrackerMVC.Api;
//using ServiceStack;
//using ServiceStack.Redis;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.ServiceHost;
using Funq;

namespace ProteinTrackerMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            new ProteinTrackerAppHost().Init();
        }
    }

    public class ProteinTrackerAppHost : AppHostBase
    {
        //https://github.com/ServiceStackV3/ServiceStackV3/wiki/Create-your-first-webservice
        public class HelloService
        {
        }

        public ProteinTrackerAppHost() : base("Protein Tracker Web Services", typeof(HelloService).Assembly) { }

        public override void Configure(Container container)
        {
            SetConfig(new EndpointHostConfig { ServiceStackHandlerFactoryPath = "api" });
        }
    }
}