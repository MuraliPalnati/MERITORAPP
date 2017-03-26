using System.Web;
using System.Web.Mvc;

namespace MERITOR.StockRoom.Rest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
