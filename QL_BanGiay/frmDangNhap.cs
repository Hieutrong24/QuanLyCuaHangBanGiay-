using BUS_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
        }

        private void kryptonLabel2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtUsername.CueHint.CueHintText = "Nhập tên đăng nhập";
            txtPassword.CueHint.CueHintText = "Nhập mật khẩu";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tenDN = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            TaiKhoanBUS tkBUS = new TaiKhoanBUS();
            var taiKhoan = tkBUS.DangNhap(tenDN, matKhau);

            if (taiKhoan == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string role = taiKhoan.Role.ToLower();


            if (role == "admin")
            {
                this.Hide();
                frmQuanLyHeThong frm = new frmQuanLyHeThong();
                 
                frm.ShowDialog();
               
               
            }

            else if (role == "banhang")
            {
                this.Hide();
                GiaoDien frm = new GiaoDien();
                frm.Show();
               
            }
            else if (role == "thukho")
            {
                this.Hide();
                QLYKho qLYKho = new QLYKho();
                qLYKho.Show();
               
            }
            else
            {
                MessageBox.Show("Tài khoản không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;


            }
            //this.Close();
        }

    }
}
