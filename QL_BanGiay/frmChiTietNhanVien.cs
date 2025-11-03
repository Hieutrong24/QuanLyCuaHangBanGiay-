using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
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
    public partial class frmChiTietNhanVien : UserControl
    {
        private long maNV;

        public frmChiTietNhanVien(long maNV)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            this.maNV = maNV; 
            this.Load += frmChiTietNhanVien_Load; 
        }


        private void frmChiTietNhanVien_Load(object sender, EventArgs e)
        {
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            NhanVienDTO nv = nhanVienBUS.GetByMaNV(maNV);

            if (nv != null)
            {
                txtMNV.Text = nv.MaTK.ToString();
                txtTenNV.Text = nv.HoTen;
                txtEmail.Text = nv.Email;
                txtSDT.Text = nv.DienThoai;
                pkDT.Value = nv.NgaySinh ?? DateTime.Now;
                txtDC.Text = nv.DiaChi;
                cboVaiTro.SelectedItem = nv.Role;

                if (nv.GioiTinh == "Nam")
                    rdNam.Checked = true;
                else if (nv.GioiTinh == "Nữ")
                    rdNu.Checked = true;

                if (!string.IsNullOrEmpty(nv.ImagePath))
                {
                    try
                    {
                        string imagePath = System.IO.Path.Combine(Application.StartupPath, "Images", nv.ImagePath);
                        btnImages.BackgroundImage = Image.FromFile(imagePath);
                    }
                    catch
                    {
                        btnImages.BackgroundImage = null;
                    }
                }
                else
                {
                    btnImages.BackgroundImage = null;
                }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLabel2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiPanel2_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

       
        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
            
        }

        private void pnHienThi_Click(object sender, EventArgs e)
        {

        }
    }
}
