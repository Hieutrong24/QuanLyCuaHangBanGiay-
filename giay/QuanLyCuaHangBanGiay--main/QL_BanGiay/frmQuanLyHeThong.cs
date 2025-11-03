using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using Krypton.Toolkit;
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
        string tennv = "";
        private readonly LogBUS logBus = new LogBUS();
        private int lastLogId = 0;
        private Timer timerCheck = new Timer();
        public frmQuanLyHeThong(string tenNV)
        {
            tennv = tenNV;
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            timerCheck.Interval = 5000;  
            timerCheck.Tick += TimerCheck_Tick;
            timerCheck.Start();
        }
        //Thong bao
        private void TimerCheck_Tick(object sender, EventArgs e)
        {
            LogDTO log = logBus.LayLogMoiNhat();
            if (log != null && log.LogID != lastLogId)
            {
                lastLogId = log.LogID;
                string message = $"🔔 {log.Username} {log.Action.ToLower()} - {log.Detail}";
                ShowPanelMessage(message);
            }
        }
        
        private void ShowPanelMessage(string message)
        {
            
            Panel msgPanel = new Panel
            {
                Size = new Size(720, 64),
                BackColor = Color.FromArgb(180, 255, 255, 255),
                Visible = true
            };

            // Làm bo góc nhẹ
            msgPanel.Paint += (s, e) =>
            {
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                int radius = 15;
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(msgPanel.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(msgPanel.Width - radius, msgPanel.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, msgPanel.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                msgPanel.Region = new Region(path);
            };

            Label lbl = new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Padding = new Padding(10),
                AutoEllipsis = true
            };
            msgPanel.Controls.Add(lbl);

            
            msgPanel.Left = Math.Max(0, (kryptonPanel3.Width - msgPanel.Width) / 2);
            msgPanel.Top = -msgPanel.Height;
            kryptonPanel3.Controls.Add(msgPanel);
            msgPanel.BringToFront();

            
            Timer animIn = new Timer { Interval = 12 };
            animIn.Tick += (s, e) =>
            {
                int targetTop = (kryptonPanel3.Height - msgPanel.Height) / 2;
                int step = 12;
                if (msgPanel.Top + step < targetTop)
                    msgPanel.Top += step;
                else
                {
                    msgPanel.Top = targetTop;
                    animIn.Stop();

                   
                    Timer stay = new Timer { Interval = 10000 };
                    stay.Tick += (s2, e2) =>
                    {
                        stay.Stop();

                         
                        Timer animOut = new Timer { Interval = 12 };
                        animOut.Tick += (s3, e3) =>
                        {
                            if (msgPanel.Top - step > -msgPanel.Height)
                                msgPanel.Top -= step;
                            else
                            {
                                animOut.Stop();
                                kryptonPanel3.Controls.Remove(msgPanel);
                                msgPanel.Dispose();
                            }
                        };
                        animOut.Start();
                    };
                    stay.Start();
                }
            };
            animIn.Start();
        }

        private void frmQuanLyHeThong_Load(object sender, EventArgs e)
        {
            var parts = tennv.Trim().Split(' ');
            tennv = parts[parts.Length - 1];   
            uiLabel1.Text = "Hi, "+ tennv;
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

            // Lấy text hiển thị của item hoặc node
            string clickedText = item?.Text ?? node?.Text;
            if (string.IsNullOrEmpty(clickedText))
                return;

            // Hàm nội bộ hiển thị UserControl trong panel
            void ShowUserControl(UserControl uc)
            {
                uc.Dock = DockStyle.Fill;
                pnTrangChu.Controls.Clear();
                pnTrangChu.Controls.Add(uc);
            }

            // Xử lý theo tên hoặc tag
            switch (clickedText)
            {
                case "Hồ sơ nhân viên":
                    
                    ShowUserControl(new frmDanhSachNhanVien());
                    return;

                case "Quản lý sản phẩm":
                    ShowUserControl(new frmQuanLySanPham());
                    return;

                case "Tính lương":
                    ShowUserControl(new frmTinhLuong());
                    return;

                case "Quản lý hóa đơn":
                    ShowUserControl(new QuanLyHoaDon());
                    return;

                case "Báo cáo nhân sự":
                    
                    ShowUserControl(new ucBaoCaoNhanSu());
                    return;
            }

            // Kiểm tra theo Tag nếu có
            string tag = item?.Tag?.ToString();
            switch (tag)
            {
                case "btnHSNV":
                     
                    ShowUserControl(new frmDanhSachNhanVien());
                    break;

                case "btnQLSP":
                
                    ShowUserControl(new frmQuanLySanPham());
                    break;

                case "btnTinhLuong":

                    ShowUserControl(new frmTinhLuong());
                    break;

                case "btnQLHD":
             
                    ShowUserControl(new QuanLyHoaDon());
                    break;

                case "btnBCNS":
          
                    ShowUserControl(new ucBaoCaoNhanSu());
                    break;
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
