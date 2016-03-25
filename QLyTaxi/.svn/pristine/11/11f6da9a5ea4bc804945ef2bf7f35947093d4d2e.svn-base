using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class SQLconnectionData
    {
        public static SqlConnection HamKetNoi()
        {
            SqlConnection cn = new SqlConnection("Server=.;Database=QLy_Taxi(Old);Integrated Security=true;");
            return cn;
        }
       
    }
    public class TaiXe_DAO
    {
        public static void OpenConnection()
        {
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void CloseConnection()
        {
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            try
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

         
       //Loat danh sach tat ca Tai Xe:
        public static DataTable LoadDanhSachTatCaTX()
        {
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            SqlCommand cmd = new SqlCommand("LayDanhSachTatCaTaiXe", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter apdt = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            apdt.Fill(table);
            return table;

            //try
            //{
              
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
           
        }

        //Them mot Tai Xe moi
        public static void ThemMotTaiXeMoi(TaiXe_DTO TaiXe)
        {
        
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            SqlCommand cmd = new SqlCommand("ThemTX", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaTX", TaiXe.MaTaiXe);
            cmd.Parameters.AddWithValue("@HoTX", TaiXe.hoTX);
            cmd.Parameters.AddWithValue("@TenTX", TaiXe.TenTX);
            cmd.Parameters.AddWithValue("@CMND", TaiXe.CMND);
            cmd.Parameters.AddWithValue("@NgaySinh", TaiXe.NgaySinh);
            cmd.Parameters.AddWithValue("@DienThoai", TaiXe.Dienthoai);
            cnn.Open(); // OpenConnection();
            cmd.ExecuteNonQuery();
            cnn.Close(); // CloseConnection();
        }

        //Xoa mot Tai Xe
        public static void XoaMotTaiXe(string maTX)
        {
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            SqlCommand cmd = new SqlCommand("Xoa_TX", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaTX", maTX);
            cnn.Open();// OpenConnection();
            cmd.ExecuteNonQuery();
            cnn.Close(); // CloseConnection();
        }

        //Tim theo ma Tai Xe
        public static DataTable TimTheoMaTaiXe(string maTX)
        {
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            SqlCommand cmd = new SqlCommand("LayDanhSachTaiXeTheoMa", cnn);
            cmd.Parameters.AddWithValue("@MaTX", maTX);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter apdt = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            apdt.Fill(table);
            return table;

            //try
            //{
               
            //}
            //catch(Exception ex)
            //{
            //    throw ex;
            //}
        }

        //Tim theo ten Tai Xe
        public static DataTable TimTheoTenTaiXe(string TenTX)
        {
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            SqlCommand cmd = new SqlCommand("LayDanhSachTaiXeTheoTen", cnn);
            cmd.Parameters.AddWithValue("@tenTX", TenTX);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter apdt = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            apdt.Fill(table);
            return table;

            //try
            //{
               
            //}
            //catch(Exception ex)
            //{
            //    throw ex;
            //}
        }

        //Kiem tra su ton tai cua ma Tai Xe
        public static int KiemTraMaTX_CoTonTai(string maTX)
        {
            try
            {
                SqlConnection cnn = SQLconnectionData.HamKetNoi();
                SqlCommand cmd = new SqlCommand("KiemTraMaTX", cnn);
                cmd.Parameters.AddWithValue("@MaTX", maTX);
                SqlParameter output = new SqlParameter("@KQ", SqlDbType.Int);
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                cmd.ExecuteNonQuery();
                int KQ = Convert.ToInt16(output.Value.ToString());
                cnn.Close();
                return KQ;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Kiem tra su ton tai cua ten Tai Xe
        public static int KiemTraTenTX_CoTonTai(string tenTX)
        {
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            SqlCommand cmd = new SqlCommand("KiemTraTenTX", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenTX", tenTX);
            SqlParameter output = new SqlParameter("@KQ", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(output);
            cnn.Open();
            cmd.ExecuteNonQuery();
            int KQ = Convert.ToInt16(output.Value.ToString());
            cnn.Close();
            return KQ;

            //try
            //{
               
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        //Kiem tra su rang buoc du lieu giua Tai Xe va Xe
        public static int KiemTraTX_CoXe(string maTX)
        {
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            SqlCommand cmd = new SqlCommand("TX_Co_Xe", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaTX", maTX);
            SqlParameter output = new SqlParameter("@KQ", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(output);
            cnn.Open();
            cmd.ExecuteNonQuery();
            int KQ = Convert.ToInt16(output.Value.ToString());
            cnn.Close();
            return KQ;

            //try
            //{
               
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        //Sua Tai Xe
        public static void SuaTaiXe(TaiXe_DTO TaiXe)
        {
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            SqlCommand cmd = new SqlCommand("Sua_TX", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaTX", TaiXe.MaTaiXe);
            cmd.Parameters.AddWithValue("@HoTX", TaiXe.hoTX);
            cmd.Parameters.AddWithValue("@TenTX", TaiXe.TenTX);
            cmd.Parameters.AddWithValue("@CMND", TaiXe.CMND);
            cmd.Parameters.AddWithValue("@NgaySinh", TaiXe.NgaySinh);
            cmd.Parameters.AddWithValue("@DienThoai", TaiXe.Dienthoai);
            cnn.Open(); // OpenConnection();
            cmd.ExecuteNonQuery();
            cnn.Close(); // CloseConnection();
        }
    }

}
