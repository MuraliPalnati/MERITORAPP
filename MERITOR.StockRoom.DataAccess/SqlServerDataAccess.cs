using MERITOR.StockRoom.DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MERITOR.StockRoom.DomainEntity;
using MERITOR.StockRoom.DataEntity;
using AutoMapper;
using MERITOR.StockRoom.DataAccess.Generic;
using System.Net;

namespace MERITOR.StockRoom.DataAccess
{
    public class SqlServerDataAccess : IDIDataAccess
    {

        //SqlServerDbEntities entities = new SqlServerDbEntities();

        OracleDbEntities oracle = new OracleDbEntities();
        public List<EMP> Add(List<EMP> es)
        {
            return es;
        }

        public List<EMP> select(EMP es)
        {
            try
            {

                //var response = entities.EMPLOYEEs.ToList<EMPLOYEE>();
                //var response = oracle.EMPLOYEEs.ToList<EMPLOYEE>();

                //var resp = oracle.Database.SqlQuery<EMP>("SELECT * FROM EMPLOYEE").ToList<EMP>();
                //return mapper;
                /*string query = "SELECT* FROM EMPLOYEE";
                GenericRepository<EMPLOYEE> a = new GenericRepository<EMPLOYEE>();
                var resp = a.selectNativeQuery(query);*/


                //if (es == null)
                //{
                    throw new Exception("HI Teja");
                //}
                //return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
