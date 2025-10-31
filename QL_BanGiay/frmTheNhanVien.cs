using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class frmTheNhanVien : UserControl
    {
        public frmTheNhanVien()
        {
            InitializeComponent();
             
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Padding = new Padding(10);
            this.Margin = new Padding(20);
             

        }
        private NhanVienDTO nhanVien;
        public void SetData(NhanVienDTO nv)
        {
            nhanVien = nv;

            lblTennhanvien.Text = nv.HoTen;
            lblMa.Text = nv.MaTK.ToString();
            lblGT.Text = nv.GioiTinh;
            lblNS.Text = nv.NgaySinh?.ToString("dd/MM/yyyy");

            // Avatar
            if (!string.IsNullOrEmpty(nv.ImagePath))
            {
                string path = Path.Combine(Application.StartupPath, "Images", nv.ImagePath);
                if (File.Exists(path))
                    imgBtnAvatar.Image = Image.FromFile(path);
            }

            // Gọi hàm hiển thị mã QR
            HienThiQRCode();
        }


        private void frmTheNhanVien_Load(object sender, EventArgs e)
        {
            // Bo góc avatar (như bạn đã làm)
            if (imgBtnAvatar != null && imgBtnAvatar.Width > 0 && imgBtnAvatar.Height > 0)
            {
                using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int radius = imgBtnAvatar.Width / 2;
                    gp.AddEllipse(new Rectangle(0, 0, imgBtnAvatar.Width - 1, imgBtnAvatar.Height - 1));
                    imgBtnAvatar.Region = new Region(gp);
                }
            }

            // Gọi hàm hiển thị mã QR
            HienThiQRCode();
            HienThiAvatar();
        }

        private void HienThiQRCode()
        {
            try
            {
                if (imgBtnQR.Image != null)
                    imgBtnQR.Image.Dispose();

                if (nhanVien?.QRCode != null && nhanVien.QRCode.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(nhanVien.QRCode))
                    {
                        imgBtnQR.Image = Image.FromStream(ms);
                        imgBtnQR.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    imgBtnQR.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị mã QR: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HienThiAvatar()
        {
            try
            {
                // Giải phóng ảnh cũ nếu có
                if (imgBtnAvatar.Image != null)
                {
                    imgBtnAvatar.Image.Dispose();
                    imgBtnAvatar.Image = null;
                }

                if (!string.IsNullOrEmpty(nhanVien.ImagePath))
                {
                    // Lấy đường dẫn gốc của project (lùi lại từ bin/Debug/... lên)
                    string basePath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                    string imageFolder = Path.Combine(basePath, "Images");

                    // Kết hợp với tên file ảnh trong DTO
                    string fullPath = Path.Combine(imageFolder, nhanVien.ImagePath);

                    // Kiểm tra ảnh có tồn tại không
                    if (File.Exists(fullPath))
                    {
                        imgBtnAvatar.Image = Image.FromFile(fullPath);
                        imgBtnAvatar.SizeMode = PictureBoxSizeMode.StretchImage;

                        // Bo tròn avatar
                        using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
                        {
                            gp.AddEllipse(new Rectangle(0, 0, imgBtnAvatar.Width - 1, imgBtnAvatar.Height - 1));
                            imgBtnAvatar.Region = new Region(gp);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy file ảnh: " + fullPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    imgBtnAvatar.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonLabel1_Click(object sender, EventArgs e)
        {

        }
    }

}
