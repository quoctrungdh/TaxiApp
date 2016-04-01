using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QL_TaXi
{
    public partial class FormKH_CacChuyenDi : Form
    {
        public FormKH_CacChuyenDi()
        {
            InitializeComponent();
        }

        private void FormKH_CacChuyenDi_Load(object sender, EventArgs e)
        {
            LoadDataChuyenDi_KH();
        }

        public void LoadDataChuyenDi_KH()
        {
            try
            {
                dgvKh_ChuyenDi.DataSource = KhachHang_BUS.LayDanhSachCacChuyenDi_KH(Form1.maKH_CD);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
