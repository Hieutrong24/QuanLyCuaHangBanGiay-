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
    public partial class CardGiay : UserControl
    {
        public string TenGiay
        {
            get => lbTenGiay.Text;
            set => lbTenGiay.Text = value;

        }
        public decimal PhanTramGiam { get; set; }
        public decimal GiaSauUuDai { get; set; }
        public long IdGiay { get; set; }
        public string TenMau { get; set; }
        public string SizeGiay { get; set; }
        public decimal DonGia
        { get; set; }
        public void UpdateCardDisplay()
        {
            // Cập nhật giá chính (txtGia) và hiển thị khuyến mãi
            if (PhanTramGiam > 0)
            {
                // 1. Hiển thị phần trăm giảm giá (lbgiam)
                lbgiam.Text = $"-{PhanTramGiam:N0}%";
                lbgiam.Visible = true;
                lbgiam.BackColor = Color.Red; // Tùy chỉnh màu sắc để nổi bật

                // 2. Hiển thị giá gốc bị gạch ngang (lbGia)
                lbGia.Text = $"{DonGia:N0}đ"; // DonGia là giá gốc

                // Thiết lập font gạch ngang (Strikeout) cho giá gốc
                // Giữ nguyên các thuộc tính font khác, chỉ thêm Strikeout
                Font currentFont = lbGia.Font;
                lbGia.Font = new Font(currentFont, currentFont.Style | FontStyle.Strikeout);
                lbGia.ForeColor = Color.Gray; // Màu xám cho giá cũ
                lbGia.Visible = true; // Hiển thị giá gốc gạch ngang

                // 3. Hiển thị giá sau ưu đãi (Giá mới) trong txtGia
                txtGia.Text = GiaSauUuDai.ToString("N0") + "đ";
                txtGia.ForeColor = Color.Red;
                txtGia.Font = new Font(txtGia.Font, FontStyle.Bold); // In đậm giá mới
            }
            else
            {
                // Không có khuyến mãi: Sử dụng logic mặc định
                lbgiam.Visible = false;
                lbGia.Visible = false;

                // Reset lại giá trị và kiểu chữ của txtGia về giá gốc
                txtGia.Text = DonGia.ToString("N0") + "đ";
                txtGia.ForeColor = Color.Black;
                txtGia.Font = new Font(txtGia.Font, FontStyle.Regular);
            }

            // Đảm bảo các thuộc tính khác được cập nhật
            if (Anh != null)
            {
                pnAnh.BackgroundImage = Anh;
            }
        }
        public Image Anh
        {
            get => pnAnh.BackgroundImage;
            set => pnAnh.BackgroundImage = value;
        }
        public string TonKho
        {
            get => lbtonkho.Text;
            set => lbtonkho.Text = "SL tồn: " + value;
        }
        public event EventHandler OnSelect;
        public CardGiay()
        {
            InitializeComponent();
            txtGia.Click += TxtGia_Click;

        }

        private void TxtGia_Click(object sender, EventArgs e)
        {
            txtGia.BackColor = Color.LightYellow; // đổi màu nền
            txtGia.ForeColor = Color.Red;         // đổi màu chữ
        }
        private void txtGia_Click_1(object sender, EventArgs e)
        {
            if (OnSelect != null)
                OnSelect(this, e);
        }

        private void CardGiay_Load(object sender, EventArgs e)
        {
            UpdateCardDisplay();
        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
