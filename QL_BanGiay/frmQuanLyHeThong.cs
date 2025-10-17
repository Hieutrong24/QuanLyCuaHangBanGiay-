using Sunny.UI;
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
    public partial class frmQuanLyHeThong : Form
    {
        public frmQuanLyHeThong()
        {
            InitializeComponent();
        }
        
        private void frmQuanLyHeThong_Load(object sender, EventArgs e)
        {
             
            lblGio.Font = new Font("Microsoft Sans Serif", 72, FontStyle.Bold);
 

            timerGio.Start();
            this.Resize += frmQuanLySanPham_Resize;

        }


        private void uiSplitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click_1(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void uiPieChart1_Click(object sender, EventArgs e)
        {

        }

        private void uiBarChart1_Click(object sender, EventArgs e)
        {

        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmQuanLySanPham_Resize(object sender, EventArgs e)
        {
            int spacing1 = 10; 
            int totalSpacing = spacing1 * 4;
            int panelWidth = (this.ClientSize.Width - totalSpacing) / 5;

             
        }

        private void uiNavMenu1_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
             
            if (pnTrangChu == null)
            {
                MessageBox.Show("Panel hiển thị chưa tồn tại (pnTrangChu == null).");
                return;
            }

            
            string clickedText = null;
            if (item != null)
            {
                clickedText = item.Text;
            }
            else if (node != null)
            {
                clickedText = node.Text;
            }
            else
            {
                
                return;
            }

           
            if (clickedText == "Hồ sơ nhân viên")
            {
                 
                var uc = new frmDanhSachNhanVien();  
                uc.Dock = DockStyle.Fill;
                pnTrangChu.Controls.Clear();
                pnTrangChu.Controls.Add(uc);
                return;
            }

            
            if (item?.Tag != null && item.Tag.ToString() == "btnHSNV")
            {
                var uc = new frmDanhSachNhanVien();
                uc.Dock = DockStyle.Fill;
                pnTrangChu.Controls.Clear();
                pnTrangChu.Controls.Add(uc);
            }
            if (clickedText == "Quản lý sản phẩm")
            {
                var uc = new frmQuanLySanPham();
                uc.Dock = DockStyle.Fill;
                pnTrangChu.Controls.Clear();
                pnTrangChu.Controls.Add(uc);
                return;
            }
            if(item?.Tag != null && item.Tag.ToString() == "btnQLSP")
            {
                var uc = new frmQuanLySanPham();
                uc.Dock = DockStyle.Fill;
                pnTrangChu.Controls.Clear();
                pnTrangChu.Controls.Add(uc);
            }

            if (clickedText == "Tính lương")
            {
                var uc = new frmTinhLuong();
                uc.Dock = DockStyle.Fill;
                pnTrangChu.Controls.Clear();
                pnTrangChu.Controls.Add(uc);
                return;
            }
            if (item?.Tag != null && item.Tag.ToString() == "btnTinhLuong")
            {
                var uc = new frmTinhLuong();
                uc.Dock = DockStyle.Fill;
                pnTrangChu.Controls.Clear();
                pnTrangChu.Controls.Add(uc);
            }
        }

        private void timerGio_Tick(object sender, EventArgs e)
        {
            lblGio.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void lblGio_Click(object sender, EventArgs e)
        {

        }
    }
}
