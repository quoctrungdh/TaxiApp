using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiXe_DTO
    {
        private string _MaTaiXe;
    

        public string MaTaiXe
        {
              get { return _MaTaiXe; }
             set { _MaTaiXe = value; }
        }

        private string _HoTX;

        public string hoTX
        {
            get { return _HoTX; }
            set { _HoTX = value; }
        }

        private string _TenTX;

        public string TenTX
        {
            get { return _TenTX; }
            set { _TenTX = value; }
        }

        private string _CMND;

        public string CMND
        {
            get { return _CMND; }
            set { _CMND = value; }
        }

        private string _NgaySinh;

        public string NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }

        private string _DienThoai;

        public string Dienthoai
        {
            get { return _DienThoai; }
            set { _DienThoai = value; }
        }

        public TaiXe_DTO()
        {
            _MaTaiXe = "";
            _HoTX = "";
            _TenTX = "";
            _CMND = "";
            _NgaySinh = "";
            _DienThoai = "";
        }
        
        public TaiXe_DTO(string mataixe,string hoTX,string tenTX,string cmnd,string ngaysinh,string dienthoai)
        {
            _MaTaiXe = mataixe;
            _HoTX = hoTX;
            _TenTX = tenTX;
            _CMND = cmnd;
            _NgaySinh = ngaysinh;
            _DienThoai = dienthoai;
        }
        
        
    }
}
