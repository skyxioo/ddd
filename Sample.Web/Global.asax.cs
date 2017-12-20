using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net.Config;
using Sample.SiteSearch;

namespace Sample.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            XmlConfigurator.Configure(
                new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\log4net.config")    
            );

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //热搜排行定时任务计划
            QuartzTick.StartJob();
        }
    }
}
