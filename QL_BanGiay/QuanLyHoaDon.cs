using BUS_QL_BanGiay;
using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using Microsoft.Data.SqlClient;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;
//using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
namespace QL_BanGiay
{
    public partial class QuanLyHoaDon : Form
    {
    
        HoaDonBUS hdBUS = new HoaDonBUS();
        CTHoaDonBUS ctBUS = new CTHoaDonBUS();
        public QuanLyHoaDon()
        {
            InitializeComponent();
           
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            var listHoaDon = hdBUS.GetAllHoaDon();
            LoadData(listHoaDon);
        }
        private void LoadData(IEnumerable<HoaDonDTO> list)
        {
            btnback.Visible = false;

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

                // ----------------------------------------------------
                // PHẦN 4: THÊM CỘT BUTTON
                // ----------------------------------------------------



                // Cột Xóa
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.Name = "DeleteColumn";
                deleteButtonColumn.HeaderText = "Xóa";
                deleteButtonColumn.Text = "Xóa";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                dgview.Columns.Add(deleteButtonColumn);

            }
            catch (Exception ex)
            {
                // Hiển thị lỗi từ tầng BUS/DAL
                MessageBox.Show("Lỗi khi tải dữ liệu Hóa đơn: " + ex.Message, "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Không cần khối finally vì không có conn.Open() ở đây
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
        private void LoadDataCT(string ma)
        {
            // Khởi tạo BUS (Giả sử ctBUS đã được định nghĩa ở cấp độ lớp hoặc Form)
            

            // Kích thước ảnh cố định cho DGV (Nên chọn kích thước nhỏ, ví dụ 80x80)
            const int IMAGE_WIDTH = 80;
            const int IMAGE_HEIGHT = 80;

            try
            {
                // 1. Xóa hàng cũ
                uiDataGridView1.Rows.Clear();

                // 2. Lấy dữ liệu từ BUS
                var listctHoaDon = ctBUS.GetChiTietByMaHD(ma);


                foreach (var hd in listctHoaDon)
                {
                    int rowIndex = uiDataGridView1.Rows.Add();
                    DataGridViewRow row = uiDataGridView1.Rows[rowIndex];

                    // ----------------------------------------------------
                    // LOGIC LOAD VÀ GÁN ẢNH (Sử dụng hàm ResizeImage đã cho)
                    // ----------------------------------------------------
                    string fp = hd.MaAnh;
                    string imgPath = Path.Combine(Application.StartupPath, "Images", fp);

                    // Tăng chiều cao hàng (thêm khoảng đệm 5px)
                    row.Height = IMAGE_HEIGHT + 5;

                    if (File.Exists(imgPath))
                    {
                        try
                        {
                            // Đảm bảo file stream được đóng ngay sau khi đọc
                            using (var fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
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


        private void uiPanel3_Click_1(object sender, EventArgs e)
        {

        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

        private void dgview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0)
            {
                return;
            }


            DataGridViewRow row = dgview.Rows[e.RowIndex];
            if (dgview.Columns.Contains("MaHD"))
            {
                // Lấy giá trị MaHD từ ô tại cột "MaHD" của hàng được click
                string Mahd = row.Cells["MaHD"].Value.ToString();
                LoadDataCT(Mahd);

            }


            // Lấy tên của cột được click
            string columnName = dgview.Columns[e.ColumnIndex].Name;

            // 🔥 SỬA ĐỔI: Lấy giá trị từ cột có tên là "MaHD"
            // Đảm bảo rằng DataGridView của bạn có một cột tên là "MaHD"
            object maHDValue = dgview.Rows[e.RowIndex].Cells["MaHD"].Value;

            // Chuyển đổi giá trị MaHD sang string để sử dụng trong thông báo hoặc hàm
            string maHD = maHDValue != null ? maHDValue.ToString() : string.Empty;


            // Kiểm tra xem Cell có phải là DataGridViewButtonCell không (biện pháp đề phòng)
            if (dgview.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                switch (columnName)
                {
                    case "ActionColumn":

                        break;
                    case "DeleteColumn":
                        if (MessageBox.Show($"Bạn có chắc chắn muốn XÓA Hóa đơn Mã: {maHD}?",
                                        "Xác nhận Xóa",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            // THỰC HIỆN: Gọi hàm xóa dữ liệu khỏi Database, truyền vào biến 'maHD'
                            // DeleteInvoice(maHD);
                            MessageBox.Show($"Đã thực hiện XÓA Hóa đơn Mã: {maHD}");
                        }
                        break;








                }

            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            var listHoaDon = hdBUS.GetAllHoaDon();
            LoadData(listHoaDon);
        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QuanLyHoaDon_Load_1(object sender, EventArgs e)
        {

        }
    }
}
