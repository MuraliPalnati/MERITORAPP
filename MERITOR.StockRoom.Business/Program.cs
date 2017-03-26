using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERITOR.StockRoom.Business
{
    public sealed class Program
    {
        public static IUnityContainer DependcyInjection()
        {
            IUnityContainer container = new UnityContainer();

            //var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = @"F:\MERITORAPP\MERITOR.StockRoom.Business\App.config" };
            //System.Configuration.Configuration configuration =
            //    ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            //var unitySection = (UnityConfigurationSection)configuration.GetSection("unityDb");
            //container.LoadConfiguration(unitySection);


            //var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unityDb");
            //section.Configure(container);

            //container.LoadConfiguration("DataBaseInjection");
            //container.LoadConfiguration();
            container.RegisterType<MERITOR.StockRoom.DataAccessInterface.IDIDataAccess, MERITOR.StockRoom.DataAccess.SqlServerDataAccess>();

            //var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = @"F:\MERITORAPP\MERITOR.StockRoom.Web\App.config" };
            //System.Configuration.Configuration config =
            //    ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            //config.AppSettings.Settings.Add("ModificationDate1", DateTime.Now.ToLongTimeString() + " ");
            //// Save the changes in App.config file.
            //config.Save(ConfigurationSaveMode.Modified);
            //var value = ConfigurationManager.AppSettings["Setting2"];

            return container;
        }
    }
}
