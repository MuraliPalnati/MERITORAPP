using log4net;
using MERITOR.StockRoom.DomainEntity;
using MERITOR.StockRoom.Util;
using MERITOR.StockRoom.Web.Areas.Manage.Handler;
using MERITOR.StockRoom.Web.GenericHandler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
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
        [ErrorHandler]
        public ActionResult select()
        {
            try
            {  
                logger.Debug("Executing MERITOR.StockRoom.Web.Areas.Manage.Controllers.DIController.select");
                var response = handler.select(null);
                logger.Debug("Executed  Response from Handler");
                string value= ResourceFileHandler.readResourceFile("message2");
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                logger.Error("Error from MERITOR.StockRoom.Web.Areas.Manage.Controllers.DIController.Add " + e.Message);
                throw e;
                //return RedirectToAction("GlobalError", "Error",new { exception = e.Message });
                //return RedirectToAction("Delete", "DI",new { name = e.Message });
            }

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
        public string Delete(string name)
        {
            return "Deleted";
        }

    }
}