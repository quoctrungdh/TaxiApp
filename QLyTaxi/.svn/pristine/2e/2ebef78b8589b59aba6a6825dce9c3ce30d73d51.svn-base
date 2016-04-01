using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class TaiXe_BUS
    {
        //Load danh sach tat ca Tai Xe
        public static DataTable LoadDanhSachTatCaTaiXe()
        {
            return TaiXe_DAO.LoadDanhSachTatCaTX();
        }

        //Them mot Tai Xe moi
        public static void ThemTaiXeMoi(TaiXe_DTO taixe)
        {
            TaiXe_DAO.ThemMotTaiXeMoi(taixe);
        }

        //Xoa mot Tai Xe
        public static void XoaTaiXe(string mataixe)
        {
            TaiXe_DAO.XoaMotTaiXe(mataixe);
        }

        //Tim theo ma Tai Xe
        public static DataTable TimTheoMaTaiXe(string mataixe)
        {
            try
            {
                return TaiXe_DAO.TimTheoMaTaiXe(mataixe);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //Tim theo ten Tai Xe
        public static DataTable TimTheoTenTaiXe(string tentaixe)
        {
            return TaiXe_DAO.TimTheoTenTaiXe(tentaixe);
        }

        //Kiem tra su ton tai cua ma tai xe
        public static int KiemTraMaTX_CoTonTai(string mataixe)
        {
            return TaiXe_DAO.KiemTraMaTX_CoTonTai(mataixe);
        }

        //Kiem tra su ton tai cua ten tai xe
        public static int KiemTraTenTX_CoTonTai(string TenTX)
        {
            return TaiXe_DAO.KiemTraTenTX_CoTonTai(TenTX);
        }

        //Kiem tra su rang buoc du lieu giua Tai Xe va Xe
        public static int KiemTraTX_CoXe(string mataixe)
        {
            return TaiXe_DAO.KiemTraTX_CoXe(mataixe);
        }

        //Sua Tai Xe
        public static void SuaTaiXe(TaiXe_DTO taixe)
        {
            TaiXe_DAO.SuaTaiXe(taixe);
        }
    }
}
