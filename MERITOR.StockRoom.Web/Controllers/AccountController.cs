using MERITOR.StockRoom.DomainEntity;
using MERITOR.StockRoom.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MERITOR.StockRoom.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            ViewBag.ErrorMessage = TempData["ExMessage"];
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            List<Login> log = new List<Login>()
            {
                new Login {Id=1, UserName = "teja" , Password = "teja",Roles="Admin" },
                new Login {Id=2, UserName = "tej" , Password = "tej",Roles="View" },
                new Login {Id=3, UserName = "te" , Password = "te",Roles="View" },
                new Login {Id=4, UserName = "t" , Password = "t",Roles="Admin" },
            };
            var response = log.Where(x => (x.UserName == login.UserName && x.Password == login.Password)).FirstOrDefault<Login>();
            if (response != null)
            {
                SessionPerister.ASSIGNEDROLES = response.Roles;
                SessionPerister.ID = response.Id.ToString();
                SessionPerister.NAME = response.UserName;

                return RedirectToAction("Index","DI",new { area = "Manage"});
            }
            else
            {
                return RedirectToAction("Login", "Account",TempData["ExMessage"]= "Invaid User Please Login Again");
            }
            
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return View();
        }


        [HttpGet]

        public JsonResult Teja()
        {
            return Json("teja", JsonRequestBehavior.AllowGet);
        }
    }
}