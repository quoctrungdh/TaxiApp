using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Xe
    {
        private string _bienSo;

        public string BienSo    
        {
            get { return _bienSo; }
            set { _bienSo = value; }
        }


        private string _maTaiXe;

        public string MaTaiXe
        {
            get { return _maTaiXe; }
            set { _maTaiXe = value; }
        }

        private string _maLoaiXe;

        public string MaLoaiXe
        {
            get { return _maLoaiXe; }
            set { _maLoaiXe = value; }
        }

        public Xe(string bienSo, string maTaiXe, string maLoaiXe)
        {
            _bienSo = bienSo;
            _maTaiXe = maTaiXe;
            _maLoaiXe = maLoaiXe;
        }
        
    }
}
