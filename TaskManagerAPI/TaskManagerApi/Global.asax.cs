using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TaskManagerApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.EnsureInitialized();


            //GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            string[] allowedOrigin = new string[] { "http://localhost:4200/" };
            var origin = HttpContext.Current.Request.Headers["Origin"];
            if (origin != null && allowedOrigin.Contains(origin))
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", origin);
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET,POST");
            }

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                //These headers are handling the "pre-flight" OPTIONS call sent by the browser
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200/");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Accepts, Content-Type, Origin, X-My-Header");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "60");
                HttpContext.Current.Response.End();
            }
        }
    }
}
