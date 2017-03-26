using log4net;
using MERITOR.StockRoom.DataEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERITOR.StockRoom.DataAccess.Generic
{
    public class GenericRepository<T> : IDisposable where T : class
    {
        private readonly ILog logger;

        OracleDbEntities entities = new OracleDbEntities();

        public GenericRepository()
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        public List<T> add(List<T> add)
        {
            if (add != null)
            {
                foreach (var item in add)
                {
                    entities.Set<T>().Add(item);
                    entities.SaveChanges();
                }
                return add;
            }
            return null;
        }
        public List<T> edit(List<T> edit)
        {
            if (edit != null)
            {
                var entry = entities.Entry(edit);
                //entry.State = EntityState.Modified;
                entities.SaveChanges();
                return edit;
            }
            return null;
        }
        public List<T> delete(List<T> delete)
        {
            if (delete != null)
            {
                foreach (var item in delete)
                {
                    entities.Set<T>().Attach(item);
                    entities.Set<T>().Remove(item);
                    entities.SaveChanges();
                }
                return delete;
            }
            return null;
        }
        public List<T> selectNativeQuery(string query)
        {
            try
            {
                var result = entities.Database.SqlQuery<T>(query).ToList<T>();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<T> selectNativeQueryParameters(string query, List<SqlParameter> param)
        {
            var result = entities.Database.SqlQuery<T>(query, param.ToArray()).ToList<T>();
            return result;
        }
        public List<T> selectEF(List<T> select)
        {
            var resultlist = entities.Set<T>().ToList<T>();
            return resultlist;
        }
        public int insertNativeQueryParameters(string query, List<SqlParameter> param)
        {
            var result = entities.Database.ExecuteSqlCommand("BEGIN " + query + " END;", param.ToArray());
            return result;
        }
        void IDisposable.Dispose()
        {
            entities.Dispose();
        }
    }
}
