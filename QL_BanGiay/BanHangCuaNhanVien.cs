using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using Microsoft.Data.SqlClient;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QL_BanGiay
{

    public partial class BanHangCuaNhanVien : Form
    {

        private Dictionary<Control, Rectangle> controlOriginalRect = new Dictionary<Control, Rectangle>();
        private Size originalFormSize;


        public BanHangCuaNhanVien()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Resize += Form1_Resize;




        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            ResizeControls(this, xRatio, yRatio);
        }
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                uiComboBox1_SelectedIndexChanged(sender, e);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {


            originalFormSize = this.ClientSize;
            SaveOriginalControls(this); // Lưu tất cả control (bao gồm cả trong Panel, GroupBox...)
            LoadGiay();

        }
        /// <summary>
        /// Lưu lại vị trí và kích thước ban đầu của tất cả control (bao gồm control con)
        /// </summary>
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


        // Mỗi trang hiển thị 6 sản phẩm
        private List<CardGiay> allCards = new List<CardGiay>();
        int pageSize = 6;
        int currentPage = 1;
        int totalPages = 1;
        private Image ResizeImageSafe(Image img, int maxWidth, int maxHeight)
        {
            try
            {
                if (img == null) return null;

                if (img.Width <= maxWidth && img.Height <= maxHeight)
                    return new Bitmap(img);

                float ratioX = (float)maxWidth / img.Width;
                float ratioY = (float)maxHeight / img.Height;
                float ratio = Math.Min(ratioX, ratioY);

                int newWidth = (int)(img.Width * ratio);
                int newHeight = (int)(img.Height * ratio);

                Bitmap result = new Bitmap(newWidth, newHeight);
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.DrawImage(img, 0, 0, newWidth, newHeight);
                }

                return result;
            }
            catch
            {
                return new Bitmap(100, 100); // fallback an toàn
            }
        }


        GiayBUS _giayBUS = new GiayBUS();
        private void LoadGiay()
        {
            allCards.Clear();

            // Khởi tạo BUS (Giả định đã có)
            // _giayBUS = new GiayBUS(connStr); 

            List<GiayDTO> danhSachGiay = _giayBUS.LoadGiayVaApDungKhuyenMai();

            foreach (var giayDTO in danhSachGiay)
            {
                // *** LOGIC XỬ LÝ ẢNH ĐƯỢC CHUYỂN VỀ ĐÂY ***
                Image anhGiay = null;
                string imgPath = Path.Combine(Application.StartupPath, "Images", giayDTO.Images);

                if (File.Exists(imgPath))
                {
                    try
                    {
                        using (var fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                        using (var temp = Image.FromStream(fs, false, false))
                        {
                            // Hàm ResizeImageSafe phải nằm trong Form này (hoặc lớp tiện ích)
                            anhGiay = ResizeImageSafe(temp, 1000, 1000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ảnh lỗi {giayDTO.Images}: {ex.Message}");
                    }
                }
                // **********************************************

                CardGiay card = new CardGiay
                {
                    IdGiay = giayDTO.IdGiay,
                    TenGiay = giayDTO.TenGiay,
                    DonGia = giayDTO.DonGia,
                    TonKho = giayDTO.TonKho,
                    TenMau = giayDTO.TenMau,

                    // Gán đối tượng Image đã xử lý
                    Anh = anhGiay,

                    // Gán thông tin khuyến mãi
                    PhanTramGiam = giayDTO.PhanTramGiam,
                    GiaSauUuDai = giayDTO.GiaSauUuDai
                };

                card.UpdateCardDisplay();
       
                card.OnSelect += Card_OnSelect;
                allCards.Add(card);
            }
            // ...
            currentPage = 1;
            HienThiTrang();
        }

        private void HienThiTrang()
        {
            try
            {
                // Cấu hình lại TableLayoutPanel chỉ 1 lần
                uiTableLayoutPanel1.SuspendLayout();
                uiTableLayoutPanel1.Controls.Clear();

                uiTableLayoutPanel1.AutoScroll = false;
                uiTableLayoutPanel1.Padding = new Padding(10);
                uiTableLayoutPanel1.Margin = new Padding(20);
                uiTableLayoutPanel1.ColumnCount = 2; // 3 cột sản phẩm
                uiTableLayoutPanel1.RowCount = 3;    // 2 hàng = 6 sản phẩm/trang
                uiTableLayoutPanel1.RowStyles.Clear();
                uiTableLayoutPanel1.ColumnStyles.Clear();

                for (int i = 0; i < uiTableLayoutPanel1.ColumnCount; i++)
                    uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / uiTableLayoutPanel1.ColumnCount));

                for (int i = 0; i < uiTableLayoutPanel1.RowCount; i++)
                    uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / uiTableLayoutPanel1.RowCount));

                // Nếu không có sản phẩm
                if (allCards == null || allCards.Count == 0)
                {
                    lblPageInfo.Text = "Không có sản phẩm nào để hiển thị";
                    btnPrev.Enabled = false;
                    btnNext.Enabled = false;
                    uiTableLayoutPanel1.ResumeLayout();
                    return;
                }

                // Tính tổng số trang
                int itemsPerPage = uiTableLayoutPanel1.RowCount * uiTableLayoutPanel1.ColumnCount;
                totalPages = (int)Math.Ceiling((double)allCards.Count / itemsPerPage);

                // Giới hạn currentPage
                if (currentPage < 1) currentPage = 1;
                if (currentPage > totalPages) currentPage = totalPages;

                // Tính chỉ số bắt đầu
                int start = (currentPage - 1) * itemsPerPage;

                // Thêm card vào TableLayoutPanel
                for (int i = 0; i < itemsPerPage && (start + i) < allCards.Count; i++)
                {
                    int row = i / uiTableLayoutPanel1.ColumnCount;
                    int col = i % uiTableLayoutPanel1.ColumnCount;

                    CardGiay card = allCards[start + i];
                    uiTableLayoutPanel1.Controls.Add(card, col, row);
                }

                lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";
                btnPrev.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;

                uiTableLayoutPanel1.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị trang: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TinhTongVaHienThi(DataGridView dtgrv, Label lblTongGia)
        {
            // 1. Khai báo biến tích lũy tổng, sử dụng decimal để có độ chính xác cao
            decimal tongGiaTri = 0;

            // Tên cột cần tính tổng (Ví dụ: "GiaBan")
            string tenCotGia = "Gia";

            // Kiểm tra xem DataGridView có hàng nào không
            if (dtgrv.Rows.Count == 0)
            {
                lblTongGia.Text = "Tổng: 0";
                return;
            }

            // 2. Vòng lặp duyệt qua từng hàng
            // rows.Count - 1 để loại bỏ hàng mới (New Row) ở cuối (nếu AllowUserToAddRows là True)
            for (int i = 0; i < dtgrv.Rows.Count; i++)
            {
                // Kiểm tra xem đây có phải là hàng rỗng/hàng mới không
                if (dtgrv.Rows[i].IsNewRow) continue;

                // 3. Lấy giá trị của ô (Cell) trong cột cần tính
                // Thử lấy giá trị từ Cell tại vị trí cột đã xác định
                object cellValue = dtgrv.Rows[i].Cells[tenCotGia].Value;

                // 4. Kiểm tra và chuyển đổi giá trị sang kiểu số (decimal)
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    decimal giaHienTai;

                    // Cố gắng chuyển đổi giá trị thành số decimal
                    if (decimal.TryParse(cellValue.ToString(), out giaHienTai))
                    {
                        // Cộng dồn vào tổng
                        tongGiaTri += giaHienTai;
                    }
                    else
                    {
                        // Xử lý trường hợp không phải là số (tùy chọn)
                        MessageBox.Show($"Lỗi: Giá trị '{cellValue}' tại hàng {i + 1} không phải là số hợp lệ.", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Có thể break hoặc continue tùy thuộc vào yêu cầu
                    }
                }
            }

            // 5. Hiển thị kết quả lên Label
            // Sử dụng định dạng tiền tệ (ví dụ: "N0" không có số thập phân)
            lblTongGia.Text = $"{tongGiaTri:N0} VNĐ";
        }



        private void Card_OnSelect(object sender, EventArgs e)
        {
            CardGiay selectedCard = sender as CardGiay;
            if (selectedCard != null)
            {
                // Ví dụ: Thêm vào DataGridView
                int newRowIndex = uiDataGridView1.Rows.Add(selectedCard.IdGiay,
                                                          selectedCard.TenGiay,
                                                          1,
                                                          selectedCard.TenMau,
                                                          selectedCard.GiaSauUuDai);

                DataGridViewRow newRow = uiDataGridView1.Rows[newRowIndex];

                // *** GỌI HÀM TỪ BUS - GỌN GÀNG VÀ ĐÚNG CẤU TRÚC ***
                DataTable dataTable = _giayBUS.GetSizesByTenGiay(selectedCard.TenGiay);

                DataGridViewComboBoxCell sizeCell = newRow.Cells["SizeGiay"] as DataGridViewComboBoxCell;

                // Kiểm tra xem có dữ liệu trả về không
                if (sizeCell != null && dataTable != null && dataTable.Rows.Count > 0)
                {
                    sizeCell.DataSource = dataTable;      // Gán nguồn dữ liệu
                    sizeCell.DisplayMember = "Size";      // Tên cột hiển thị
                    sizeCell.ValueMember = "Size";        // Giá trị thực tế
                    sizeCell.Value = dataTable.Rows[0]["Size"]; // Chọn giá trị đầu tiên mặc định
                }

                TinhTongVaHienThi(uiDataGridView1, lbgia);
            }
        }
        private bool isCollapsed = true;


        private void TimGiay_Click(object sender, EventArgs e, string q)
        {
            string keyword = SearchBox.Text.Trim();
            allCards.Clear();
            if (keyword.Length > 0)
            {
                List<GiayDTO> danhSachGiay = _giayBUS.LoadGiayVaApDungKhuyenMaiTheoTen(keyword);
                foreach (var giayDTO in danhSachGiay)
                {
                    Image anhGiay = null;
                    string imgPath = Path.Combine(Application.StartupPath, "Images", giayDTO.Images);

                    if (File.Exists(imgPath))
                    {
                        try
                        {
                            using (var fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                            using (var temp = Image.FromStream(fs, false, false))
                            {
                                // Hàm ResizeImageSafe phải nằm trong Form này (hoặc lớp tiện ích)
                                anhGiay = ResizeImageSafe(temp, 300, 300);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ảnh lỗi {giayDTO.Images}: {ex.Message}");
                        }
                    }
                    CardGiay card = new CardGiay
                    {
                        IdGiay = giayDTO.IdGiay,
                        TenGiay = giayDTO.TenGiay,
                        DonGia = giayDTO.DonGia,
                        TonKho = giayDTO.TonKho,
                        TenMau = giayDTO.TenMau,

                        // Gán đối tượng Image đã xử lý
                        Anh = anhGiay,

                        // Gán thông tin khuyến mãi
                        PhanTramGiam = giayDTO.PhanTramGiam,
                        GiaSauUuDai = giayDTO.GiaSauUuDai
                    };

                    card.UpdateCardDisplay();

                    card.OnSelect += Card_OnSelect;
                    allCards.Add(card);
                }
                currentPage = 1;
                HienThiTrang();
            }
            else
            {
                List<GiayDTO> danhSachGiay = _giayBUS.LoadGiayVaApDungKhuyenMai();
                foreach (var giayDTO in danhSachGiay)
                {
                    Image anhGiay = null;
                    string imgPath = Path.Combine(Application.StartupPath, "Images", giayDTO.Images);

                    if (File.Exists(imgPath))
                    {
                        try
                        {
                            using (var fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                            using (var temp = Image.FromStream(fs, false, false))
                            {
                                // Hàm ResizeImageSafe phải nằm trong Form này (hoặc lớp tiện ích)
                                anhGiay = ResizeImageSafe(temp, 300, 300);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ảnh lỗi {giayDTO.Images}: {ex.Message}");
                        }
                    }
                    CardGiay card = new CardGiay
                    {
                        IdGiay = giayDTO.IdGiay,
                        TenGiay = giayDTO.TenGiay,
                        DonGia = giayDTO.DonGia,
                        TonKho = giayDTO.TonKho,
                        TenMau = giayDTO.TenMau,

                        // Gán đối tượng Image đã xử lý
                        Anh = anhGiay,

                        // Gán thông tin khuyến mãi
                        PhanTramGiam = giayDTO.PhanTramGiam,
                        GiaSauUuDai = giayDTO.GiaSauUuDai
                    };

                    card.UpdateCardDisplay();

                    card.OnSelect += Card_OnSelect;
                    allCards.Add(card);
                }
                currentPage = 1;
                HienThiTrang();
            }
        }







        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                HienThiTrang();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                HienThiTrang();
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            uiDataGridView1.ClearRows();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            // 2. Tạo các cột trong DataTable dựa trên các cột trong DataGridView
            foreach (DataGridViewColumn column in uiDataGridView1.Columns)
            {
                // Thêm cột vào DataTable. 
                // Lấy tên cột từ HeaderText hoặc Name của DataGridViewColumn.
                // Bạn có thể cần xử lý thêm để xác định đúng kiểu dữ liệu (Type)
                dt.Columns.Add(column.HeaderText, typeof(string));
            }

            // 3. Lặp qua các hàng của DataGridView và thêm vào DataTable
            foreach (DataGridViewRow row in uiDataGridView1.Rows)
            {
                // Bỏ qua hàng thêm mới (new row) nếu DataGridView cho phép nhập liệu
                if (row.IsNewRow) continue;

                // Tạo một Row mới cho DataTable
                DataRow dr = dt.NewRow();

                // Lặp qua các ô trong hàng
                for (int i = 0; i < uiDataGridView1.Columns.Count; i++)
                {
                    // Lấy giá trị của ô và gán vào DataRow.
                    // .Value có thể là null, cần kiểm tra hoặc chuyển đổi sang chuỗi.
                    object cellValue = row.Cells[i].Value;
                    dr[i] = (cellValue == null) ? (object)DBNull.Value : cellValue.ToString();
                }

                // Thêm DataRow đã điền vào DataTable
                dt.Rows.Add(dr);
            }
            HoaDon formMoi = new HoaDon(dt);
            formMoi.Show();

        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = uiComboBox1.SelectedIndex;
            string query = "";
            switch (index)
            {
                case 0:
                    query = "ORDER BY DonGia";
                    break;
                case 1:
                    query = "ORDER BY DonGia DESC";
                    break;
                case 2:
                    break;

            }
            TimGiay_Click(sender, e, query);
        }

        private void uiPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
