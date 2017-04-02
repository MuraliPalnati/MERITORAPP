using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace MERITOR.StockRoom.Web.Security
{
    public class CustomAuthorize : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //if (filterContext.HttpContext.Request.IsAuthenticated)
            //{

            //}
            if (string.IsNullOrEmpty(SessionPerister.ID))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Account", Action = "Login", area = "" }));
            else
            {
                CustomPrincipal mp = new CustomPrincipal(SessionPerister.ID);
                Roles = SessionPerister.ASSIGNEDROLES;
                Users = SessionPerister.NAME;
                //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Logout" }));
                try
                {
                    var cookie = filterContext.HttpContext.Request.Cookies[AntiForgeryConfig.CookieName];
                    var ajaxToken = filterContext.HttpContext.Request.Headers["__RequestVerificationToken"];
                    var formToken = ((System.Web.HttpRequestWrapper)((System.Web.Mvc.Controller)filterContext.Controller).Request).Form["__RequestVerificationToken"];

                    var tok = ajaxToken != null ? ajaxToken : formToken;

                    AntiForgery.Validate(cookie != null ? cookie.Value : null, tok);
                }
                catch (Exception e)
                {
                    throw new Exception("CSRF ERROR " + e.Message);
                }

            }
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }
            else
            {
                return true;
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