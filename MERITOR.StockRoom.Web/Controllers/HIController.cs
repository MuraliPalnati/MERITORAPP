using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MERITOR.StockRoom.Web.Controllers
{
    public class HIController : Controller
    {
        // GET: HI
        public ActionResult Index()
        {
            return RedirectToAction("GlobalError", "Error", new { exception = "e.Message" });
        }
    }
}