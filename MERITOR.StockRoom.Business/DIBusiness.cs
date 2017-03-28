using MERITOR.StockRoom.Business;
using MERITOR.StockRoom.BusinessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MERITOR.StockRoom.DomainEntity;
using log4net;
using MERITOR.StockRoom.DataAccessInterface;
using MERITOR.StockRoom.DataAccess;
using Microsoft.Practices.Unity;
using System.Resources;
using MERITOR.StockRoom.Web.GenericHandler;

namespace MERITOR.StockRoom.Business
{
    public class DIBusiness : IDIBusiness
    {
        private readonly ILog logger = null;
        private readonly IDIDataAccess repo;
        public DIBusiness()
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            IUnityContainer cont = Program.DependcyInjection();
            repo = cont.Resolve<IDIDataAccess>();
        }
        public List<EMP> add(List<EMP> e)
        {
            try
            {
                logger.Info("Executing MERITOR.StockRoom.Business.DIBusiness with request : " + e);
                if (e != null)
                {
                    var response = repo.Add(e);
                    logger.Info("Response received from MERITOR.StockRoom.Business.DIBusiness " + response);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                logger.Error("Error from MERITOR.StockRoom.Rest.Areas.Manage.Controllers.DIServiceController.Add " + ex.Message);
                throw;
            }

        }

        public List<EMP> select(EMP e)
        {
            try
            {
                logger.Info("Executing MERITOR.StockRoom.Business.DIBusiness with request : " + e);
                //if (e != null)
                //{
                if (e != null)
                {
                    //e.ErrorMessage.Add("message1", "Object is null");
                }
                else
                {
                    //e = new EMP();
                    //e.ErrorMessage.Add("message2", "Object is not null");
                    ResourceFileHandlerBusiness.writeResourceFile("message2", "Object is not null");
                }
                var response = repo.select(e);
                logger.Info("Response received from MERITOR.StockRoom.Business.DIBusiness " + response);
                return response;
                //}
                //return null;
            }
            catch (Exception ex)
            {
                logger.Error("Error from MERITOR.StockRoom.Rest.Areas.Manage.Controllers.DIServiceController.select " + ex.Message);
                throw;
            }
        }
    }
}
