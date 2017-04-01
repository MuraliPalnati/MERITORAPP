using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MERITOR.StockRoom.Web.Security
{
    public class CustomAuthorize : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPerister.ID))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Account", Action = "Logout" }));
            else
            {
                Roles = SessionPerister.ASSIGNEDROLES;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Logout" }));

            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.StatusCode = 401;
                filterContext.HttpContext.Response.End();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Error", Action = "Unauthorized" }));
            }

            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}