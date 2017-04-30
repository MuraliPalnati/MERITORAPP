using MERITOR.StockRoom.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MERITOR.StockRoom.Web.Controllers
{

    [CustomAuthorize]
    public class TejaController : Controller
    {
        // GET: Teja
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kanu()
        {
            return View();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ravi()
        {
            return View();
        }
    }
}