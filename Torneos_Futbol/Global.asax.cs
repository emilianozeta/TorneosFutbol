using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Datos;

namespace Torneos_Futbol
{
    public class Global : HttpApplication
    {
        public usuario u;

        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            if (u != null)
                Session["Usuario"] = u;
            if (((usuario)Session["Usuario"]) == null)
            {
                Response.Redirect("~/Login");

            }
        }

        void Session_End(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Session.RemoveAll();
        }
    }
}