using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;


namespace BUS
{
    public class Xe_BUS
    {
        public List<Xe> LoadDanhSachXe()
        {
            string sql = "SELECT * FROM XeSoHuu";
            List<Xe> list = new Xe_DAO().getListXe(sql);            
            return list;
        }

        public List<Xe> TimTheoBienSo(string sBienSo)
        {
            string sql = "SELECT * FROM XeSoHuu WHERE BienSoXe=" + "'" + sBienSo + "'";
            List<Xe> list = new Xe_DAO().getListXe(sql);
            return list;
        }

        
    }
}
