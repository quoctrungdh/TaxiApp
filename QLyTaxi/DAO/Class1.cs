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
  
       //Loat danh sach tat ca Tai Xe:
        public static DataTable LoadDanhSachTatCaTX()
        {
            
            try
            {
                SqlConnection cnn = SQLconnectionData.HamKetNoi();
                SqlCommand cmd = new SqlCommand("LayDanhSachTatCaTaiXe", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter apdt = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                apdt.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        //Them mot Tai Xe moi
        public static void ThemMotTaiXeMoi(TaiXe_DTO TaiXe)
        {
            try
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
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //Xoa mot Tai Xe
        public static void XoaMotTaiXe(string maTX)
        {
            try
            {
                SqlConnection cnn = SQLconnectionData.HamKetNoi();
                SqlCommand cmd = new SqlCommand("Xoa_TX", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTX", maTX);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //Tim theo ma Tai Xe
        public static DataTable TimTheoMaTaiXe(string maTX)
        {
            

            try
            {
                SqlConnection cnn = SQLconnectionData.HamKetNoi();
                SqlCommand cmd = new SqlCommand("LayDanhSachTaiXeTheoMa", cnn);
                cmd.Parameters.AddWithValue("@MaTX", maTX);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter apdt = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                apdt.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Tim theo ten Tai Xe
        public static DataTable TimTheoTenTaiXe(string TenTX)
        {
           

            try
            {
                SqlConnection cnn = SQLconnectionData.HamKetNoi();
                SqlCommand cmd = new SqlCommand("LayDanhSachTaiXeTheoTen", cnn);
                cmd.Parameters.AddWithValue("@tenTX", TenTX);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter apdt = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                apdt.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Tim Kiem Tai Xe Fullname
        public static DataTable TimKiemTX_Fullname(string fullname)
        {
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            SqlCommand cmd = new SqlCommand("TimKiemTX_Fullname", cnn);
            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter apdt = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            apdt.Fill(table);
            return table;
        }

        //Kiem Tra Fullname Tai Xe Co Ton Tai
        public static int KiemTraFullnameTX(string fullname)
        {
            SqlConnection cnn = SQLconnectionData.HamKetNoi();
            SqlCommand cmd = new SqlCommand("KiemTraFullnameTX", cnn);
            cmd.Parameters.AddWithValue("@fullname", fullname);
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

        //Kiem tra su ton tai cua ma Tai Xe
        public static int KiemTraMaTX_CoTonTai(string maTX)
        {
            int KQ;
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
                KQ = Convert.ToInt16(output.Value.ToString());
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return KQ;
        }

        //Kiem tra su ton tai cua ten Tai Xe
        public static int KiemTraTenTX_CoTonTai(string tenTX)
        {
            try
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Kiem tra su rang buoc du lieu giua Tai Xe va Xe
        public static int KiemTraTX_CoXe(string maTX)
        {
            try
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Sua Tai Xe
        public static void SuaTaiXe(TaiXe_DTO TaiXe)
        {
            try
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
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }

}
