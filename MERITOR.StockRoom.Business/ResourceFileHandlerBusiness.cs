using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;

namespace MERITOR.StockRoom.Web.GenericHandler
{
    public class ResourceFileHandlerBusiness
    {
        public static void writeResourceFile(string keyInput, string valueInput)
        {
            try
            {
                using (ResXResourceWriter resx = new ResXResourceWriter(@"D:\Desktop\Meritor\Project\MERITORAPP\MERITOR.StockRoom.Web\App_GlobalResources\ErrorMessages.resx"))
                {
                    resx.AddResource(keyInput, valueInput);
                }
            }
            catch (Exception ex)
            {
                ILog logger = logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Error("Error from MERITOR.StockRoom.Web.GenericHandler.ResourceFileHandler.writeResourceFile" + ex.Message);
                throw new Exception("Error in Writing to the resource File." + ex.Message);
            }
        }
        public static string readResourceFile(string keyInput)
        {
            try
            {
                string returnvalue = string.Empty;
                using (ResXResourceReader resxReader = new ResXResourceReader(@"~\App_GlobalResources\ErrorMessages.resx"))
                {
                    foreach (DictionaryEntry entry in resxReader)
                    {
                        if (((string)entry.Key).StartsWith(keyInput))
                        {
                            returnvalue = (string)entry.Value;
                        }
                    }
                }
                return returnvalue;
            }
            catch (Exception ex)
            {
                ILog logger = logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Error("Error from MERITOR.StockRoom.Web.GenericHandler.ResourceFileHandler.readResourceFile" + ex.Message);
                throw new Exception("Error in Reading to the resource File." + ex.Message);
            }
        }
    }
}