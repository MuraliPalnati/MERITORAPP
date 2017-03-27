using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MERITOR.StockRoom.Web.Controllers
{
    public class ErrorController : Controller
    {

        // 400 Error
        public ActionResult BadRequest()
        {
            return View();
        }

        // 401 Error
        public ActionResult Unauthorized()
        {
            return View();
        }
        // 404 Error
        public ActionResult NotFound()
        {
            return View();
        }

        // 500 Error 
        public ActionResult InternalServer()
        {
            return View();
        }
    }
}