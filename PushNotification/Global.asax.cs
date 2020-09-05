using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PushNotification
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //update global.asax.cs for start and stop sql dependency
        string con = ConfigurationManager.ConnectionStrings["sqlConString"].ConnectionString;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // here in application start  we will start sql dependency
            SqlDependency.Start(con);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            NotificationComponents NC = new NotificationComponents();
            var currentTime = DateTime.Now;
            HttpContext.Current.Session["LastUpdated"] = currentTime;
            NC.RegisterNotification(currentTime);
        }
        protected void Application_End()
        {
            //here we will stop sql dependency
            SqlDependency.Stop(con);
        }
    }
}
