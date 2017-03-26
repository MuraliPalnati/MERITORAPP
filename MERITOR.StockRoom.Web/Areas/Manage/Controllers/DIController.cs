using log4net;
using MERITOR.StockRoom.DomainEntity;
using MERITOR.StockRoom.Web.Areas.Manage.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MERITOR.StockRoom.Web.Areas.Manage.Controllers
{
    public class DIController : Controller
    {
        private readonly ILog logger = null;
        private  IDIHandler handler;
        public DIController(IDIHandler hand)
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            handler = hand;
        }

        List<EMP> emp = new List<EMP>
        {
            new EMP { ID=6,NAME="v",PASSWORD="I" }
        };


        // GET: Manage/DI
        public ActionResult Index()
        {
            logger.Debug("Executing MERITOR.StockRoom.Web.Areas.Manage.Controllers.DIController.Index");
            return View();
        }
        public string Add()
        {
            try
            {
                logger.Debug("Executing MERITOR.StockRoom.Web.Areas.Manage.Controllers.DIController.Add");
                handler.Add(emp);
                logger.Debug("Executed  Response from Handler");
                return "Added";
            }
            catch (Exception e)
            {
                logger.Error("Error from MERITOR.StockRoom.Web.Areas.Manage.Controllers.DIController.Add " + e.Message);
                throw e;
            }
        }
        public string Delete()
        {
            return "Deleted";
        }

    }
}