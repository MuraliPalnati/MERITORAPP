using MERITOR.StockRoom.DomainEntity;
using MERITOR.StockRoom.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        [CustomAuthorize]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var log = UserList();
                var response = log.Where(x => (x.UserName == login.UserName && x.Password == login.Password)).FirstOrDefault<Login>();
                if (response != null)
                {
                    SessionPerister.ASSIGNEDROLES = response.Roles;
                    SessionPerister.ID = response.Id.ToString();
                    SessionPerister.NAME = response.UserName;
                    string id = SessionPerister.ID;
                    //FormsAuthentication.SetAuthCookie(id, false);
                    //HttpContext.Request.IsAuthenticated { true};
                    return RedirectToAction("Index", "DI", new { area = "Manage" });
                }
                else
                {
                    return RedirectToAction("Login", "Account", TempData["ExMessage"] = "Invaid User Please Login Again");
                }
            }
            else
            {
                ModelState.AddModelError("ErrorMessage", "Invalid login attempt.");
                return View(login);
            }
        }

        [HttpPost]
        //[CustomAuthorize]
        public bool IsValidUser(Login login)
        {
            var log = UserList();
            bool response = log.Where(x => (x.UserName == login.UserName)).Count()>0?true:false;
            return response;
        }

        public List<Login> UserList()
        {
            List<Login> log = new List<Login>()
            {
                new Login {Id=1, UserName = "teja" , Password = "teja",Roles="Admin" },
                new Login {Id=2, UserName = "tej" , Password = "tej",Roles="View" },
                new Login {Id=3, UserName = "te" , Password = "te",Roles="View" },
                new Login {Id=4, UserName = "t" , Password = "t",Roles="Admin" },
            };
            return log;
        }
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            Session.Abandon();
            return View();
        }
    }
}