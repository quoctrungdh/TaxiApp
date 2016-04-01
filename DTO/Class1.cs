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

    public class KhachHang_DTO
    {
        private string _MaKH;

        public string MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }

        private string _HoKH;

        public string HoKH
        {
            get { return _HoKH; }
            set { _HoKH = value; }
        }

        private string _TenKH;

        public string TenKH
        {
            get { return _TenKH; }
            set { _TenKH = value; }
        }

        private string _DienThoai;

        public string DienThoai
        {
            get { return _DienThoai; }
            set { _DienThoai = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public KhachHang_DTO()
        {
            _MaKH = "";
            _HoKH = "";
            _TenKH = "";
            _DienThoai = "";
            _Email = "";
        }

        public KhachHang_DTO(string maKH,string hoKH, string tenKH, string dienthoai, string Email)
        {
            _MaKH = maKH;
            _HoKH = hoKH;
            _TenKH = tenKH;
            _DienThoai = dienthoai;
            _Email = Email;
        }
        
    }
}
