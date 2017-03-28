using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MERITOR.StockRoom.Web.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILog logger = null;
        public ErrorController()
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        // 400 Error
        public ActionResult BadRequest()
        {
            logger.Error("BadRequest");
            return View();
        }

        // 401 Error
        public ActionResult Unauthorized()
        {
            logger.Error("Unauthorized");
            return View();
        }
        // 404 Error
        public ActionResult NotFound()
        {
            logger.Error("NotFound");
            return View();
        }

        // 500 Error 
        public ActionResult InternalServer()
        {
            logger.Error("InternalServer");
            return View();
        }
        //public ActionResult GlobalError(string exception)
        //{
        //    logger.Error("GlobalError");
        //    ViewBag.exceptionName = exception;
        //    return View();
        //}

        public ActionResult GlobalError()
        {
            logger.Error("GlobalError");
            return View();
        }
    }
}