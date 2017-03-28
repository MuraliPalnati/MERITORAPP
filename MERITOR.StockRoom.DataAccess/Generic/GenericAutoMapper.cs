using AutoMapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERITOR.StockRoom.DataAccess.Generic
{
    public sealed class GenericAutoMapper<T1, T2>
    {

        public static List<T2> listObjectMapper(List<T1> input)
        {
            try
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<T1, T2>();
                });
                var resp = AutoMapper.Mapper.Map<List<T1>, List<T2>>(input);
                return resp;

            }
            catch (Exception ex)
            {
                ILog logger = logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Error("Error from MERITOR.StockRoom.DataAccess.Generic.GenericAutoMapper.listObjectMapper" + ex.Message);
                throw new Exception("Error in AutoMapping of the Objects.Exception is " + ex.Message);
            }

        }
        public static T2 ObjectMapp(T1 input)
        {
            try
            {
                Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<T1, T2>();
            });
                var resp = AutoMapper.Mapper.Map<T1, T2>(input);
                return resp;
            }
            catch (Exception ex)
            {
                ILog logger = logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Error("Error from MERITOR.StockRoom.DataAccess.Generic.GenericAutoMapper.listObjectMapper" + ex.Message);
                throw new Exception("Error in AutoMapping of the Object.Exception is " + ex.Message);
            }
        }
    }
}
