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
    public partial class GiaoDien : Form
    {
 
        private Dictionary<Control, Rectangle> controlOriginalRect = new Dictionary<Control, Rectangle>();
        private Size originalFormSize;
        public GiaoDien()
        {
            InitializeComponent();
            this.Load += GiaoDien_Load;
            this.Resize += FormMain_Resize;
        }
        private void GiaoDien_Load(object sender, EventArgs e)
        {
            ShowFormInPanel(new BanHangCuaNhanVien());
            originalFormSize = this.Size;
            SaveOriginalControls(this);
        }
        // Lưu vị trí & kích thước gốc của tất cả control
        private void SaveOriginalControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                controlOriginalRect[c] = new Rectangle(c.Location, c.Size);
                if (c.Controls.Count > 0)
                {
                    SaveOriginalControls(c);
                }
            }
        }

        // Hàm gọi lại khi resize
        private void FormMain_Resize(object sender, EventArgs e)
        {
            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            ResizeControls(this, xRatio, yRatio);
        }

        // Cập nhật kích thước control theo tỉ lệ
        private void ResizeControls(Control parent, float xRatio, float yRatio)
        {
            foreach (Control c in parent.Controls)
            {
                if (controlOriginalRect.ContainsKey(c))
                {
                    Rectangle r = controlOriginalRect[c];
                    int newX = (int)(r.X * xRatio);
                    int newY = (int)(r.Y * yRatio);
                    int newWidth = (int)(r.Width * xRatio);
                    int newHeight = (int)(r.Height * yRatio);
                    c.SetBounds(newX, newY, newWidth, newHeight);
                }

                if (c.Controls.Count > 0)
                {
                    ResizeControls(c, xRatio, yRatio);
                }
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            if (uiNavMenu1.Visible)
            {
                // Ẩn panel
                uiNavMenu1.Visible = false;

                // Đổi biểu tượng về "3 gạch" (icon menu)
                uiSymbolButton1.Symbol = 0xf0c9; // Unicode của icon menu (☰)
            }
            else
            {
                // Hiện panel
                uiNavMenu1.Visible = true;

                // Đổi biểu tượng về "dấu X" (close)
                uiSymbolButton1.Symbol = 0xf00d; // Unicode của icon close (✕)
            }
        }
        private void ShowFormInPanel(Form form)
        {
            // Xóa các control cũ trong panel (nếu muốn chỉ hiển thị 1 form tại 1 thời điểm)
            uiPanel2.Controls.Clear();

            // Thiết lập form con
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None; // ẩn viền form
            form.Dock = DockStyle.Fill; // chiếm toàn bộ panel

            // Thêm form vào panel và hiển thị
            uiPanel2.Controls.Add(form);
            form.Show();
        }
        private void uiNavMenu1_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            string nodeName = node.Text; // hoặc node.Name nếu bạn đặt tên riêng

            switch (nodeName)
            {
                case "Quản Lý Bán Hàng":
                    ShowFormInPanel(new BanHangCuaNhanVien());
                    break;
                case "Quản Lý Hoá Đơn":
                    ShowFormInPanel(new QuanLyHoaDon());
                    break;
                case "Thống Kê":
                    ShowFormInPanel(new ThongKe());
                    break;
                default:
                    break;
            }

        }

        private void uiNavMenu1_MenuItemClick_1(TreeNode node, NavMenuItem item, int pageIndex)
        {
            string nodeName = node.Text;
            switch (nodeName)
            {

                case "Đăng xuất":
                    this.Hide();
                    frmDangNhap frm = new frmDangNhap();
                    frm.ShowDialog();
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
