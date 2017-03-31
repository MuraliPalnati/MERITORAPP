using System.Collections.Generic;
using System.Data.SqlClient;

namespace MERITOR.StockRoom.DataAccess.Generic
{
    public interface IGenericDataAccess<T> where T : class
    {
        List<T> add(List<T> add);
        List<T> delete(List<T> delete);
        List<T> edit(List<T> edit);
        int insertNativeQueryParameters(string query, List<SqlParameter> param);
        List<T> selectEF(List<T> select);
        List<T> selectNativeQuery(string query);
        List<T> selectNativeQueryParameters(string query, List<SqlParameter> param);
    }
}