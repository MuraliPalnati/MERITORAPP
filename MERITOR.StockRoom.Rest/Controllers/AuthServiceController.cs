using MERITOR.StockRoom.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MERITOR.StockRoom.Rest.Controllers
{
    public class AuthServiceController : ApiController
    {
        /*public HttpResponseMessage Login(Login login)
        {
            if (ModelState.IsValid)
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

        }*/
    }
}
