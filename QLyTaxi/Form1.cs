using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;

namespace QL_TaXi
{
    public partial class Form1 : Form
    {
        public static int DK = 0;
        string tempMaTX;
        public Form1()
        {
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
            if (DK == 0)
                Close();
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDSXe();
        }

        public void LoadData()
        {
            txtTimKiem.Text = "";
           dgvTX.DataSource = TaiXe_BUS.LoadDanhSachTatCaTaiXe();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void dgvTX_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvTX.CurrentRow!=null)
            {
                tempMaTX = dgvTX.CurrentRow.Cells[0].Value.ToString();
                txtMaTX.Text = dgvTX.CurrentRow.Cells[0].Value.ToString();
                txtHoTX.Text = dgvTX.CurrentRow.Cells[1].Value.ToString();
                txtTenTX.Text = dgvTX.CurrentRow.Cells[2].Value.ToString();
                txtCMND.Text = dgvTX.CurrentRow.Cells[3].Value.ToString();
                txtDienThoai.Text = dgvTX.CurrentRow.Cells[5].Value.ToString();
                int i = dgvTX.CurrentRow.Cells[4].Value.ToString().IndexOf(" ");
                txtNgaySinh.Text = dgvTX.CurrentRow.Cells[4].Value.ToString().Substring(0,i);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập nội dung cần tìm kiếm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimKiem.Focus();
            }
            else
            {
                string TX = txtTimKiem.Text.Trim();
                if (rdMaNV.Checked)
                {
                    if (TaiXe_BUS.KiemTraMaTX_CoTonTai(TX) == 0 || TX.Length > 5)
                    {
                        MessageBox.Show("Mã Tài Xế không tồn tại.", "Kết Qủa Tìm Kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTimKiem.Focus();
                       
                    }
                    else
                    {
                        dgvTX.DataSource = TaiXe_BUS.TimTheoMaTaiXe(TX);
                    }
                       

                }
                else
                {
                    if (TX.Contains(" "))
                        {
                            if (TaiXe_BUS.KiemTraFullnameTX(TX) == 0)
                            {
                                MessageBox.Show("Tên Tài Xế không tồn tại.", "Kết Qủa Tìm Kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtTimKiem.Focus();
                            }
                            else
                            {
                                dgvTX.DataSource = TaiXe_BUS.TimKiemTX_Fullname(TX);
                            }
                        }
                        else
                        {
                            if (TaiXe_BUS.KiemTraTenTX_CoTonTai(TX) == 0)
                            {
                                MessageBox.Show("Tên Tài Xế không tồn tại.", "Kết Qủa Tìm Kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtTimKiem.Focus();
                            }
                            else
                            {
                                dgvTX.DataSource = TaiXe_BUS.TimTheoTenTaiXe(TX);
                            }
                        }
                       
                }
            }
           
        }

        private void btnBoTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaTX.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập mã tài xế", "Thiếu Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTX.Focus();
            }
            else
            {
                if(txtHoTX.Text=="")
                {
                    MessageBox.Show("Bạn chưa nhập họ tài xế", "Thiếu Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHoTX.Focus();
                }
                else
                {
                    if(txtTenTX.Text=="")
                    {
                        MessageBox.Show("Bạn chưa nhập tên tài xế", "Thiếu Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenTX.Focus();
                    }
                    else
                    {
                        if(txtCMND.Text=="")
                        {
                            MessageBox.Show("Bạn chưa nhập CMND tài xế", "Thiếu Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCMND.Focus();
                        }
                        else
                        {
                            if(txtNgaySinh.Text=="")
                            {
                                MessageBox.Show("Bạn chưa nhập ngày sinh tài xế", "Thiếu Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNgaySinh.Focus();
                            }
                            else
                            {
                                if(txtDienThoai.Text=="")
                                {
                                    MessageBox.Show("Bạn chưa nhập số điện thoại của tài xế", "Thiếu Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtDienThoai.Focus();
                                }
                                else
                                {
                                    try
                                    {
                                        Convert.ToInt16(txtMaTX.Text.Substring(2));
                                        Convert.ToInt64(txtCMND.Text);
                                        Convert.ToDateTime(txtNgaySinh.Text);
                                        Convert.ToInt64(txtDienThoai.Text);
                                        if (txtMaTX.Text.Substring(0, 2).ToString() != "TX")
                                        {
                                            MessageBox.Show("Mã tài xế không hợp lệ. Bạn phải nhập là TXxxx. Ví dụ:TX000", "Sai Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            txtMaTX.Focus();
                                        }
                                        else
                                        {
                                            if (TaiXe_BUS.KiemTraMaTX_CoTonTai(txtMaTX.Text) == 1)
                                            {
                                                MessageBox.Show("Mã tài xế đã tồn tại", "Thông Tin Tài Xế Không Hợp Lệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                txtMaTX.Focus();
                                            }
                                            else
                                            {
                                                TaiXe_DTO TX = new TaiXe_DTO(txtMaTX.Text.Trim(), txtHoTX.Text.Trim(), txtTenTX.Text.Trim(), txtCMND.Text.Trim(), txtNgaySinh.Text.Trim(), txtDienThoai.Text.Trim());
                                                TaiXe_BUS.ThemTaiXeMoi(TX);
                                                LoadData();
                                            }
                                        }
                                    }
                                    catch(FormatException ex)
                                    {
                                        MessageBox.Show("Nhập thông tin Tài xế sai kiểu dữ liệu", "Sai Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtMaTX.Focus();
                                    }
                                  
                                }
                            }
                        }
                    }
                }
            }//

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(TaiXe_BUS.KiemTraMaTX_CoTonTai(txtMaTX.Text)==0)
            {
                MessageBox.Show("Mã Tài Xế không tồn tại.", "Thông Báo Kết Qủa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTX.Focus();
            }
            else
            {
                if(TaiXe_BUS.KiemTraTX_CoXe(txtMaTX.Text)==1)
                {
                    MessageBox.Show("Không thể xóa Tài Xế này do có ràng buộc dữ liệu giữa Tài Xế và Xe.", "Thông Báo Kết Qủa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaTX.Focus();
                }
                else
                {
                    TaiXe_BUS.XoaTaiXe(txtMaTX.Text);
                    LoadData();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tempMaTX != txtMaTX.Text)
            {
                MessageBox.Show("Bạn không được thay đồi mã Tài Xế khi thực hiện sữa thông tin Tài Xế.", "Thông Báo Không Hợp Lệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTX.Focus();
                txtMaTX.Text = tempMaTX;
            }
            else
            {
                if (txtHoTX.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập họ tài xế", "Thiếu Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHoTX.Focus();
                }
                else
                {
                    if (txtTenTX.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tên tài xế", "Thiếu Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenTX.Focus();
                    }
                    else
                    {
                        if (txtCMND.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập CMND tài xế", "Thiếu Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCMND.Focus();
                        }
                        else
                        {
                            if (txtNgaySinh.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập ngày sinh tài xế", "Thiếu Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNgaySinh.Focus();
                            }
                            else
                            {
                                if (txtDienThoai.Text == "")
                                {
                                    MessageBox.Show("Bạn chưa nhập số điện thoại của tài xế", "Thiếu Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtDienThoai.Focus();
                                }
                                else
                                {
                                    try
                                    {
                                        Convert.ToInt16(txtMaTX.Text.Substring(2));
                                        Convert.ToInt64(txtCMND.Text);
                                        Convert.ToDateTime(txtNgaySinh.Text);
                                        Convert.ToInt64(txtDienThoai.Text);

                                        TaiXe_DTO TX = new TaiXe_DTO(txtMaTX.Text.Trim(), txtHoTX.Text.Trim(), txtTenTX.Text.Trim(), txtCMND.Text.Trim(), txtNgaySinh.Text.Trim(), txtDienThoai.Text.Trim());
                                        TaiXe_BUS.SuaTaiXe(TX);
                                        LoadData();
                                    }
                                    catch (FormatException ex)
                                    {
                                         MessageBox.Show("Nhập thông tin Tài xế sai kiểu dữ liệu", "Sai Thông Tin Tài Xế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                         txtMaTX.Focus();
                                    }

                                }
                            }
                        }
                    }
                }
            }//
        }

        private void btnXeTX_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_xe;
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tp_xe_Click(object sender, EventArgs e)
        {

        }

        private void LoadDSXe()
        {
            List<Xe> list = new Xe_BUS().LoadDanhSachXe();
            dgvDsXe.DataSource = list;
        }

        private void dgvDsXe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDsXe.CurrentRow != null)
            {
                txtBienSo.Text = dgvDsXe.CurrentRow.Cells[0].Value.ToString();
                txtMaTaiXe.Text = dgvDsXe.CurrentRow.Cells[1].Value.ToString();
                txtMaLoaiXe.Text = dgvDsXe.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void btTimBS_Click(object sender, EventArgs e)
        {
            txtBienSo.Text = string.Empty;
            txtMaLoaiXe.Text = string.Empty;
            txtMaTaiXe.Text = string.Empty;
            if (txtTimBS.Text == "")
            {
                MessageBox.Show("Vui long nhap noi dung can tim!", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimBS.Focus();
            }
            else 
            {
                string bSoXe = txtTimBS.Text.Trim();
                List<Xe> list = new Xe_BUS().TimTheoBienSo(bSoXe);
                dgvDsXe.DataSource = list;
            }
        }

    }
}
