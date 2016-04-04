using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_TaXi
{
    public partial class FormLogin : Form
    {
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text=="")
            {
                MessageBox.Show("Chưa nhập Username", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
            }
            else
            {
                if(txtPassword.Text=="")
                {
                    MessageBox.Show("Chưa nhập Password", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Focus();
                }
                else
                {
                    if (txtUsername.Text == "abc" && txtPassword.Text == "abc")
                    {
                        MainForm.DK = 1;
                        Close();
                    }
                    else
                    {
                        if (txtUsername.Text != "abc")
                        {
                            MessageBox.Show("Tên đăng nhập không đúng", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsername.Focus();
                        }

                        else
                        {
                            MessageBox.Show("Password không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPassword.Focus();
                        }

                    }
                }
            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                FormQuenPassword frm1 = new FormQuenPassword();
                frm1.ShowDialog();
            }
            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MainForm.DK==0)
            {
                if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    e.Cancel = true;
            }
        }



    }
}
