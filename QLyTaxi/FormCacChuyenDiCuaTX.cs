using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QL_TaXi
{
    public partial class FormCacChuyenDiCuaTX : Form
    {
        public FormCacChuyenDiCuaTX()
        {
            InitializeComponent();
        }

        private void FormCacChuyenDiCuaTX_Load(object sender, EventArgs e)
        {
            try
            {
                dgvChuyenDiTX.DataSource = TaiXe_BUS.LayDanhSachChuyenXeTX(MainForm.tempMaTX);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
