using log4net;
using MERITOR.StockRoom.Web.Areas.Manage.Handler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MERITOR.StockRoom.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception GlobalException = Server.GetLastError();
            ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logger.Error("Gloabl Error Handler --" + GlobalException.Message);
            Server.ClearError();
            HttpException httpException = GlobalException as HttpException;
            //Response.Redirect("/Error/GlobalError");
            //Response.Write(httpException.Message);
            if (httpException != null)
            {
                switch (httpException.GetHttpCode())
                {
                    case 400:
                        // BadRequest
                        Response.Redirect("Error/BadRequest");
                        break;
                    case 401:
                        // Unauthorized
                        Response.Redirect("/Error/Unauthorized");
                        break;
                    case 404:
                        // page not found
                        Response.Redirect("/Error/NotFound");
                        break;
                    case 500:
                        // InternalServer error
                        Response.Redirect(" /Error/InternalServer");
                        break;
                    default:
                        Response.Redirect(" /Error/GlobalError");
                        break; 
                }
            }
            else
            {
                Response.Redirect(" /Error/GlobalError");
            }
        }
    }
}
