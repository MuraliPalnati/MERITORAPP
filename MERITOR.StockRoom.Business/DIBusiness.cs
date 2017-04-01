using MERITOR.StockRoom.BusinessInterface;
using System;
using System.Collections.Generic;
using MERITOR.StockRoom.DomainEntity;
using log4net;
using MERITOR.StockRoom.DataAccessInterface;
using Microsoft.Practices.Unity;
using MERITOR.StockRoom.Util;
using System.Linq;

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
                 throw new Exception(ex.Message);
            }

        }

        public List<EMP> select(EMP e)
        {
            try
            {
                logger.Info("Executing MERITOR.StockRoom.Business.DIBusiness with request : " + e);
                EMP employee = new EMP();
                employee.ErrorMessage = new Dictionary<string, string>();
                employee.ErrorMessage.Clear();
                logger.Info("Executing MERITOR.StockRoom.Business.DIBusiness with request : " + e);
                if (e != null)
                {
                    employee.ErrorMessage.Add("message1", "Object is null");
                }
                else
                {
                    employee.ErrorMessage.Add("message2", "Object is not null");
                    ResourceFileHandler.writeResourceFile("message2", "Object is not null");
                }
                var response = repo.select(e);

                var firstItem = response.First<EMP>();
                firstItem.ErrorMessage = employee.ErrorMessage;
                logger.Info("Response received from MERITOR.StockRoom.Business.DIBusiness " + response);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error("Error from MERITOR.StockRoom.Rest.Areas.Manage.Controllers.DIServiceController.select " + ex.Message);
                 throw new Exception(ex.Message);
            }
        }
    }
}
