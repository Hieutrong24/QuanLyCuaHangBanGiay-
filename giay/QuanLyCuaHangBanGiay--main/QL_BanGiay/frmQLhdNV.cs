using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class frmQLhdNV : Form
    {
        public frmQLhdNV()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Resize += Form1_Resize;
        }
        HoaDonBUS hdBUS = new HoaDonBUS();
        CTHoaDonBUS ctBUS = new CTHoaDonBUS();
        private void dgview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgview.Rows[e.RowIndex];
            if (dgview.Columns.Contains("MaHD"))
            {

                string Mahd = row.Cells["MaHD"].Value.ToString();
                LoadDataCT(Mahd);
                txtmahd.Text = Mahd;
            }
            string columnName = dgview.Columns[e.ColumnIndex].Name;
            object maHDValue = dgview.Rows[e.RowIndex].Cells["MaHD"].Value;

            // Chuyển đổi giá trị MaHD sang string để sử dụng trong thông báo hoặc hàm
            string maHD = maHDValue != null ? maHDValue.ToString() : string.Empty;
        }
        private void LoadDataCT(string ma)
        {

            const int IMAGE_WIDTH = 80;
            const int IMAGE_HEIGHT = 80;

            try
            {

                uiDataGridView1.Rows.Clear();

                // 2. Lấy dữ liệu từ BUS
                var listctHoaDon = ctBUS.GetChiTietByMaHD(ma);


                foreach (var hd in listctHoaDon)
                {
                    int rowIndex = uiDataGridView1.Rows.Add();
                    DataGridViewRow row = uiDataGridView1.Rows[rowIndex];
                    string basePath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                    string imageFolder = Path.Combine(basePath, "Images");
                    string imagePath = Path.Combine(imageFolder, hd.Images);
                    string fp = hd.Images;


                    // Tăng chiều cao hàng (thêm khoảng đệm 5px)
                    row.Height = IMAGE_HEIGHT + 5;

                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            // Đảm bảo file stream được đóng ngay sau khi đọc
                            using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                            {
                                using (var tempImage = Image.FromStream(fs))
                                {
                                    // 3. 🔥 GỌI HÀM RESIZE CỦA BẠN 🔥
                                    using (Image finalImage = ResizeImage(tempImage, IMAGE_WIDTH, IMAGE_HEIGHT))
                                    {
                                        // 4. Gán Bitmap mới để tránh khóa file ảnh gốc
                                        row.Cells["Anh"].Value = new Bitmap(finalImage);
                                    }
                                }
                            }
                        }
                        catch (Exception exImage)
                        {
                            // Xử lý lỗi load ảnh: file bị hỏng, lỗi GDI+, v.v.
                            Console.WriteLine($"Lỗi khi tải ảnh {fp}: {exImage.Message}");
                            row.Cells["Anh"].Value = null;
                        }
                    }
                    else
                    {
                        // Gán null hoặc ảnh mặc định nếu file không tồn tại
                        row.Cells["Anh"].Value = null;
                    }
                    // ----------------------------------------------------

                    // Gán các giá trị Text/Number khác
                    row.Cells["MaGiay"].Value = hd.MaGiay;
                    row.Cells["TenGiay"].Value = hd.TenGiay;
                    row.Cells["SoLuong"].Value = hd.SoLuong;
                    row.Cells["Gia"].Value = hd.GiaBan;
                }
            }

            catch (Exception ex)
            {
                // Hiển thị lỗi từ tầng BUS/DAL
                MessageBox.Show("Lỗi khi tải dữ liệu chi tiết Hóa đơn: " + ex.Message, "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Image ResizeImage(Image image, int width, int height)
        {
            // Tạo Bitmap mới với kích thước mong muốn
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            // Thiết lập chất lượng vẽ để ảnh resize nhìn tốt hơn
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic; // Chất lượng cao
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        private void LoadData(IEnumerable<HoaDonDTO> list)
        {
            dgview.Rows.Clear();

            try
            {
                foreach (var hd in list)
                {
                    int rowIndex = dgview.Rows.Add();
                    DataGridViewRow row = dgview.Rows[rowIndex];

                    row.Cells["MaHD"].Value = hd.MaHD;
                    row.Cells["TenNV"].Value = hd.TenNV;
                    row.Cells["NgayBan"].Value = hd.NgayBan;
                    row.Cells["Tong"].Value = hd.TongTien;



                }
             

            }
            catch (Exception ex)
            {
                // Hiển thị lỗi từ tầng BUS/DAL
                MessageBox.Show("Lỗi khi tải dữ liệu Hóa đơn: " + ex.Message, "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Không cần khối finally vì không có conn.Open() ở đây
        }
        private Dictionary<Control, Rectangle> controlOriginalRect = new Dictionary<Control, Rectangle>();
        private Size originalFormSize;
        private void Form1_Resize(object sender, EventArgs e)
        {

            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            ResizeControls(this, xRatio, yRatio);
        }
        private void frmQLhdNV_Load(object sender, EventArgs e)
        {
            var listHoaDon = hdBUS.GetAllHoaDon();
            LoadData(listHoaDon);
        }
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
        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = uiComboBox1.SelectedIndex;
            switch (uiComboBox1.SelectedIndex)
            {
                case 0:
                    var listHoaDon1 = hdBUS.GetAllHoaDon_MoiNhat();
                    LoadData(listHoaDon1);
                    break;

                case 1:
                    var listHoaDon2 = hdBUS.GetAllHoaDon_CuNhat();
                    LoadData(listHoaDon2);
                    break;

                case 2:
                    var listHoaDon3 = hdBUS.GetAllHoaDon_TongTienTang();
                    LoadData(listHoaDon3);
                    break;
                case 3:
                    var listHoaDon4 = hdBUS.GetAllHoaDon_TongTienGiam();
                    LoadData(listHoaDon4);
                    break;
            }
        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = uiDataGridView1.Rows[e.RowIndex];

                // Gán giá trị từ cột lên TextBox
                txtmagiay.Text = row.Cells["MaGiay"].Value.ToString();
                txtsoluong.Text = row.Cells["SoLuong"].Value.ToString();
            }
        }

        private void btnxoahd_Click(object sender, EventArgs e)
        {
            long mahd = Convert.ToInt64(txtmahd.Text);
            hdBUS.DeleteHoaDon(mahd);
            var listHoaDon = hdBUS.GetAllHoaDon();
            LoadData(listHoaDon);
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            long mahd = Convert.ToInt64(txtmahd.Text);
            long magiay = Convert.ToInt64(txtmagiay.Text);
            ctBUS.DeleteChiTietHoaDon(mahd, magiay);
            var listHoaDon = hdBUS.GetAllHoaDon();
            LoadData(listHoaDon);
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            long mahd = Convert.ToInt64(txtmahd.Text);
            long magiay = Convert.ToInt64(txtmagiay.Text);
            int sl= Convert.ToInt32(txtsoluong.Text);
            ctBUS.UpdateSoLuong(mahd, magiay,sl);
            hdBUS.CapNhatTongTienHoaDon(mahd);
            var listHoaDon = hdBUS.GetAllHoaDon();
            
            LoadData(listHoaDon);
        }
    }
}
