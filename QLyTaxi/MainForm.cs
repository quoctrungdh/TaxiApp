using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DTO;
using BUS;

namespace QL_TaXi
{
    public partial class MainForm : Form
    {
        public static int DK = 0;
        public static string maKH_CD = "";
        string tempMaTX;
        public MainForm()
        {
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
            if (DK == 0)
                Close();
            else
                InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataTX();
            LoadDataKH();
            LoadDataXe();
        }

        /// <summary>
        /// Phần code lập trình cho tab Tài Xế
        /// </summary>
        public void LoadDataTX()
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
                if(dgvTX.CurrentRow.Cells[4].Value.ToString()!="")
                {
                    int i = dgvTX.CurrentRow.Cells[4].Value.ToString().IndexOf(" ");
                    txtNgaySinh.Text = dgvTX.CurrentRow.Cells[4].Value.ToString().Substring(0, i);
                }
                else
                {
                    txtNgaySinh.Text = dgvTX.CurrentRow.Cells[4].Value.ToString();
                }
               
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
            LoadDataTX();
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
                                            if (TaiXe_BUS.KiemTraMaTX_CoTonTai(txtMaTX.Text.Trim()) == 1)
                                            {
                                                MessageBox.Show("Mã tài xế đã tồn tại", "Thông Tin Tài Xế Không Hợp Lệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                txtMaTX.Focus();
                                            }
                                            else
                                            {
                                                TaiXe_DTO TX = new TaiXe_DTO(txtMaTX.Text.Trim(), txtHoTX.Text.Trim(), txtTenTX.Text.Trim(), txtCMND.Text.Trim(), txtNgaySinh.Text.Trim(), txtDienThoai.Text.Trim());
                                                TaiXe_BUS.ThemTaiXeMoi(TX);
                                                LoadDataTX();
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
                    LoadDataTX();
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
                                        LoadDataTX();
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
            dgvXe.DataSource = TaiXe_BUS.LayDanhSachCacXeCuaTX(tempMaTX);
        }
        


        /// <summary>
        /// Phần code lập trình cho form Khách Hàng
        /// </summary>

        private void btnThoatKH_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void LoadDataKH()
        {
            txtTimKiemKH.Text = "";
            dgvKH.DataSource = KhachHang_BUS.LoadDanhSachTatCaKhachHang();
        }

        private void dgvKH_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvKH.CurrentRow != null)
            {
                maKH_CD = dgvKH.CurrentRow.Cells[0].Value.ToString();
                txtMaKH.Text = dgvKH.CurrentRow.Cells[0].Value.ToString();
                txtHoKH.Text = dgvKH.CurrentRow.Cells[1].Value.ToString();
                txtTenKH.Text = dgvKH.CurrentRow.Cells[2].Value.ToString();
                txtDienThoaiKH.Text= dgvKH.CurrentRow.Cells[3].Value.ToString();
                txtEmailKH.Text = dgvKH.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            if (txtTimKiemKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung cần tìm kiếm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimKiemKH.Focus();
            }
            else
            {
                string TX = txtTimKiemKH.Text.Trim();
                if (rdMaKH.Checked)
                {
                    if (KhachHang_BUS.KiemTraMaKH_CoTonTai(TX) == 0 || TX.Length > 5)
                    {
                        MessageBox.Show("Mã Khách Hàng không tồn tại.", "Kết Qủa Tìm Kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTimKiemKH.Focus();

                    }
                    else
                    {
                        dgvKH.DataSource = KhachHang_BUS.TimTheoMaKhachHang(TX);
                    }


                }
                else
                {
                    if (TX.Contains(" "))
                    {
                        if (KhachHang_BUS.KiemTraFullnameKH(TX) == 0)
                        {
                            MessageBox.Show("Tên Khách Hàng không tồn tại.", "Kết Qủa Tìm Kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTimKiemKH.Focus();
                        }
                        else
                        {
                            dgvKH.DataSource = KhachHang_BUS.TimKiemKH_Fullname(TX);
                        }
                    }
                    else
                    {
                        if (KhachHang_BUS.KiemTraTenKH_CoTonTai(TX) == 0)
                        {
                            MessageBox.Show("Tên Khách Hàng không tồn tại.", "Kết Qủa Tìm Kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTimKiemKH.Focus();
                        }
                        else
                        {
                            dgvKH.DataSource = KhachHang_BUS.TimTheoTenKhachHang(TX);
                        }
                    }

                }
            }
        }

        private void btnBoTimKH_Click(object sender, EventArgs e)
        {
            LoadDataKH();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã Khách Hàng", "Thiếu Thông Tin Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
            }
            else
            {
                if (txtHoKH.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập họ Khách Hàng", "Thiếu Thông Tin Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHoKH.Focus();
                }
                else
                {
                    if (txtTenKH.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tên Khách Hàng", "Thiếu Thông Tin Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenKH.Focus();
                    }
                    else
                    {
                        if (txtDienThoaiKH.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập số điện thoại Khách Hàng", "Thiếu Thông Tin Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDienThoaiKH.Focus();
                        }
                        else
                        {
                                    try
                                    {
                                        Convert.ToInt16(txtMaKH.Text.Substring(2));
                                        Convert.ToInt64(txtDienThoaiKH.Text);
                                        if (txtMaKH.Text.Substring(0, 2).ToString() != "KH")
                                        {
                                            MessageBox.Show("Mã khách hàng không hợp lệ. Bạn phải nhập là KHxxx. Ví dụ:KH000", "Sai Thông Tin Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            txtMaKH.Focus();
                                        }
                                        else
                                        {
                                            if (KhachHang_BUS.KiemTraMaKH_CoTonTai(txtMaKH.Text.Trim()) == 1)
                                            {
                                                MessageBox.Show("Mã Khách Hàng đã tồn tại", "Thông Tin Khách Hàng Không Hợp Lệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                txtMaKH.Focus();
                                            }
                                            else
                                            {
                                                KhachHang_DTO KH = new KhachHang_DTO(txtMaKH.Text.Trim(), txtHoKH.Text.Trim(), txtTenKH.Text.Trim(), txtDienThoaiKH.Text.Trim(), txtEmailKH.Text.Trim());
                                                KhachHang_BUS.ThemKhachHangMoi(KH);
                                                LoadDataKH();
                                            }
                                        }
                                    }
                                    catch (FormatException ex)
                                    {
                                        MessageBox.Show("Nhập thông tin Khách hàng sai kiểu dữ liệu", "Sai Thông Tin Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtMaKH.Focus();
                                    }
                        }
                    }
                }
            }//
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (KhachHang_BUS.KiemTraMaKH_CoTonTai(txtMaKH.Text) == 0)
            {
                MessageBox.Show("Mã Khách Hàng không tồn tại.", "Thông Báo Kết Qủa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
            }
            else
            {
                KhachHang_BUS.XoaKhachHang(txtMaKH.Text);
                LoadDataKH();
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (maKH_CD != txtMaKH.Text)
            {
                MessageBox.Show("Bạn không được thay đồi mã Khách Hàng khi thực hiện sữa thông tin Khách Hàng.", "Thông Báo Không Hợp Lệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                txtMaKH.Text = maKH_CD;
            }
            else
            {
                if (txtHoKH.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập họ khách hàng", "Thiếu Thông Tin Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHoKH.Focus();
                }
                else
                {
                    if (txtTenKH.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thiếu Thông Tin Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenKH.Focus();
                    }
                    else
                    {
                        if (txtDienThoaiKH.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập số điện thoại của khách hàng", "Thiếu Thông Tin Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDienThoaiKH.Focus();
                        }
                        else
                        {
                                    try
                                    {
                                        Convert.ToInt16(txtMaKH.Text.Substring(2));
                                        Convert.ToInt64(txtDienThoaiKH.Text);

                                        KhachHang_DTO KH = new KhachHang_DTO(txtMaKH.Text.Trim(), txtHoKH.Text.Trim(), txtTenKH.Text.Trim(), txtDienThoaiKH.Text.Trim(), txtEmailKH.Text.Trim());
                                        KhachHang_BUS.SuaKhachHang(KH);
                                        LoadDataKH();
                                    }
                                    catch (FormatException ex)
                                    {
                                        MessageBox.Show("Nhập thông tin Khách Hàng sai kiểu dữ liệu", "Sai Thông Tin Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtMaKH.Focus();
                                    }
                        }
                    }
                }
            }//
        }

        private void btnChuyenDiKH_Click(object sender, EventArgs e)
        {
            FormKH_CacChuyenDi frmKH_CacChuyenDi = new FormKH_CacChuyenDi();
            frmKH_CacChuyenDi.ShowDialog();
        }

        /// <summary>
        /// Phần code lập trình cho form Quan Ly xe
        /// </summary>
        /// 


        //public void LoadDataTX()
        //{
        //    txtTimKiem.Text = "";
        //    dgvTX.DataSource = TaiXe_BUS.LoadDanhSachTatCaTaiXe();
        //}

        public void LoadDataXe()
        {
            txtTimBangSo.Text = string.Empty;
            dgvXe.DataSource = Xe_BUS.LoadDanhSachTatCaXe();
        }

    }
}
