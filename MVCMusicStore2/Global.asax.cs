using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVCMusicStore2.Models;
namespace MVCMusicStore2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           //一般用来进行网站初始化，初始化数据库，然后填充一些数据
           System.Data.Entity.Database.SetInitializer(new MVCMusicStore2.Models.SampleData());
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}
