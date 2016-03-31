using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DataProvider
    {
        private const string _cnstr = @"Server=.; Database=QLy_Taxi(Old); Integrated Security=true";
        private SqlConnection _cn;

        public SqlConnection CN
        {
            get { return _cn; }
            set { _cn = value; }
        }

        public DataProvider()
        {
            _cn = new SqlConnection(_cnstr);
        }

        public void Connect()
        {
            try
            {
                if (_cn != null && _cn.State == ConnectionState.Closed)
                    _cn.Open();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (_cn.State == ConnectionState.Open)
                    _cn.Close();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public int ExecuteQuery(string str)
        {
            SqlCommand cmd = new SqlCommand(str, _cn);
            return cmd.ExecuteNonQuery();
        }

        public int ExecuteQuery(SqlCommand sql)
        {
            sql.Connection = _cn;
            sql.CommandType = CommandType.StoredProcedure;
            return sql.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(string str)
        {
            SqlCommand cmd = new SqlCommand(str, _cn);
            return cmd.ExecuteReader();
        }                

        public SqlDataReader ExecuteReader(SqlCommand sql)
        {
            sql.Connection = _cn;
            sql.CommandType = CommandType.StoredProcedure;
            return sql.ExecuteReader();
        }

        public DataTable DataAdapterQuery(string sqlCmd)
        {
            try
            {
                SqlDataAdapter adpt = new SqlDataAdapter(new SqlCommand(sqlCmd, _cn));
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
