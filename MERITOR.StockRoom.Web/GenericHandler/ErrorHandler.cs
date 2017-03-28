using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MERITOR.StockRoom.Web.GenericHandler
{
    public class ErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                Exception ex = filterContext.Exception;
                filterContext.ExceptionHandled = true;
                var model = new HandleErrorInfo(filterContext.Exception, "Error", "GlobalError");
                filterContext.Controller.TempData["exception"] = filterContext.Exception.Message;
                filterContext.Result = new ViewResult()
                {
                    ViewName = "GlobalErrorHandler",
                    ViewData = new ViewDataDictionary(model),
                    TempData = filterContext.Controller.TempData
                };
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Error("Error from Controller "+ filterContext.Controller +" Method " + filterContext.RouteData.Values["action"]+" Exception " + filterContext.Exception.Message);
            }
        }
    }
}