using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MERITOR.StockRoom.Web.Security
{
    public class SessionPerister
    {
        static string roles = "AssignedRoles";
        static string id = "Id";
        static string name = "Name";

        public static string ASSIGNEDROLES
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;

                var sessionvar = HttpContext.Current.Session[roles];
                if (sessionvar != null)
                    return sessionvar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[roles] = value;
            }
        }
        public static string ID
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;

                var sessionvar = HttpContext.Current.Session[id];
                if (sessionvar != null)
                    return sessionvar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[id] = value;
            }
        }
        public static string NAME
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;

                var sessionvar = HttpContext.Current.Session[name];
                if (sessionvar != null)
                    return sessionvar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[name] = value;
            }
        }

    }
}