using MERITOR.StockRoom.DomainEntity;
using MERITOR.StockRoom.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MERITOR.StockRoom.WebService
{
    /// <summary>
    /// Summary description for DIWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DIWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            DIBusiness business = new DIBusiness();
            List<EMP> emp = new List<EMP>
        {
            new EMP { ID=6,NAME="v",PASSWORD="I" }
        };
            business.add(emp);
            return "Added";
        }

        //[WebMethod]
        //public string AddService(List<EMP> e)
        //{
        //    DIBusiness business = new DIBusiness();
        //    business.add(e);
        //    return "Added";
        //}
    }
}
