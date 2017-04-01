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
        public void getUserRoles(string id)
        {
            string[] roles = new string[] { "Admin", "view" };

            Roles = "view";
        }


        public override void OnAuthorization(AuthorizationContext actionContext)
        {
            getUserRoles("10");

            
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.StatusCode = 401;
                filterContext.HttpContext.Response.End();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Error", Action = "GlobalError" }));
            }

            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}