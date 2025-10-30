using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class frmKeToan : Form
    {
        string tennv = "";
        public frmKeToan(string tenNV)
        {
            tennv = tenNV;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
        }
        private UserControl currentControl = null;
        private void frmKeToan_Load(object sender, EventArgs e)
        {

            var parts = tennv.Trim().Split(' ');
            tennv = parts[parts.Length - 1];
            lblName.Text = "Hi, " + tennv;
            lblName.RectColor = System.Drawing.Color.White;
            OpenChildControl(new frmChuongTrinhKhuyenMai(), tpCTKM);
            txtSearch.Watermark = "Tìm kiếm sản phẩm...";
            txtSearch.WatermarkColor = Color.Gray;
        }
        private void tabKeToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabKeToan.SelectedIndex)
            {
                case 0:
                    OpenChildControl(new frmTyLeBH(), tpMH);
                    break;
                //case 1:
                //    OpenChildControl(new frmTonKho(), tpGT);
                //    break;
                case 2:
                    OpenChildControl(new QuanLyHoaDon(), tpBH);
                    break;
                case 3:
                    OpenChildControl(new frmChuongTrinhKhuyenMai(), tpCTKM);
                    break;
                case 4:
                    OpenChildControl(new drmAPDuungKM(), tpADKM);
                    break;
                case 5:
                    //OpenChildControl(new frmBaoCaoTheoDoi(), tpTD);
                    break;
                case 6:
                    OpenChildControl(new frmTinhLuong(), tpLuong);
                    break;
                case 7:
                    this.Close();
                    break;
            }
        }


        private void OpenChildControl(UserControl control, TabPage tabPage)
        {
            if (currentControl != null)
                currentControl.Dispose();

            currentControl = control;
            control.Dock = DockStyle.Fill;

            tabPage.Controls.Clear();
            tabPage.Controls.Add(control);
        }



    }
}
