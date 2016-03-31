using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAO
{
    public class Xe_DAO
    {
        private DataProvider dp;

        public Xe_DAO()
        {
            dp = new DataProvider();
        }

        public List<Xe> getListXe(string sql)
        {
            List<Xe> list = new List<Xe>();

            string tmpBienSo = string.Empty;
            string tmpMaTaiXe = string.Empty;
            string tmpMaLoaiXe = string.Empty;
            Xe tmpXe;
            try
            {
                dp.Connect();

                SqlDataReader dr = dp.ExecuteReader(sql);

                while (dr.Read())
                {
                    tmpBienSo = dr.GetString(0);
                    tmpMaLoaiXe = dr.GetString(1);
                    tmpMaTaiXe = dr.GetString(2);
                    tmpXe = new Xe(tmpBienSo, tmpMaTaiXe, tmpMaLoaiXe);
                    list.Add(tmpXe);
                }
                dp.Disconnect();
                return list;

            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataTable TimTheoBienSo(string sBienSo)
        {        
                try
                {
                    string sql = "SELECT * FROM XeSoHuu WHERE BienSoXe=" + sBienSo;
                    DataTable dt = dp.DataAdapterQuery(sql);
                    return dt;
                }
                catch (Exception ex)
                {                
                    throw ex;
                }              
        }
    }
}
