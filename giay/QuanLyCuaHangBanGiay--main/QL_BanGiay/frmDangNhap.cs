using BUS_QL_BanGiay;
using Microsoft.IdentityModel.Logging;
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
        public string tenNV = "";
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
                tenNV = txtUsername.Text.Trim();
                this.Hide();
                frmQuanLyHeThong frm = new frmQuanLyHeThong(tenNV);
                 
                frm.ShowDialog();
               
               
            }

            else if (role == "banhang")
            {
                tenNV = txtUsername.Text.Trim();
                LogBUS logBUS = new LogBUS();
                logBUS.WriteLog(tenNV, "Đăng nhập", $"Nhân viên đăng nhập với vai trò {role}");
                this.Hide();
                GiaoDien frm = new GiaoDien(tenNV);
                frm.Show();
               
            }
            else if (role == "thukho")
            {
                tenNV = txtUsername.Text.Trim();
                LogBUS logBUS = new LogBUS();
                logBUS.WriteLog(tenNV, "Đăng nhập", $"Nhân viên đăng nhập với vai trò {role}");
                this.Hide();
                QLYKho qLYKho = new QLYKho();
                qLYKho.Show();
               
            }
            else if(role == "ketoan")
            {
                tenNV = txtUsername.Text.Trim();
                LogBUS logBUS = new LogBUS();
                logBUS.WriteLog(tenNV, "Đăng nhập", $"Nhân viên đăng nhập với vai trò {role}");
                this.Hide();
                frmKeToan frm = new frmKeToan(tenNV);
                frm.Show();
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
