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
    public partial class ThongKe : Form
    {
         

        public ThongKe()
        {
            InitializeComponent();
        }
        public ThongKeBUS tkBUS = new ThongKeBUS();
        public BaoCaoBUS bcBUS = new BaoCaoBUS();
        private void LoadDataChiTietGiay(IEnumerable<BaoCaoSoLuongGiayDTO> list)
        {


            dgvGiay.Rows.Clear();
            foreach (var item in list)
            {
                int rowIndex = dgvGiay.Rows.Add();
                DataGridViewRow row = dgvGiay.Rows[rowIndex];

                row.Cells["MaGiay"].Value = item.MaGiay;
                row.Cells["TenGiay"].Value = item.TenGiay;
                row.Cells["SoLuong"].Value = item.TongSoLuongBan;

                row.Cells["DonGia"].Value = item.DonGia;
            }
        }
        private void dgviewThongKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra để đảm bảo người dùng click vào một hàng hợp lệ (không phải header)
            if (e.RowIndex < 0 || e.RowIndex >= dgvthongke.Rows.Count - 1)
            {
                return;
            }

            try
            {
    
                string ngayLapString = dgvthongke.Rows[e.RowIndex].Cells["NgayLap"].Value.ToString();


                DateTime ngayChon;
                if (DateTime.TryParse(ngayLapString, out ngayChon))
                {

                    var listChiTietGiay = bcBUS.XemBaoCaoGiayTheoNgay(ngayChon);
                    LoadDataChiTietGiay(listChiTietGiay);
                }
                else
                {
                    MessageBox.Show("Không thể chuyển đổi ngày lập hóa đơn.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lấy chi tiết thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            // 1. Lấy danh sách thống kê từ BUS
            var listThongKe = tkBUS.LayDanhSachThongKe();

            // 2. Gọi hàm nạp dữ liệu
            LoadDataThongKe(listThongKe);
        }
        private void LoadDataThongKe(IEnumerable<ThongKeDTO> list)
        {
          
            dgvthongke.Rows.Clear();
            try
            {
         

                foreach (var tk in list)
                {
                    int rowIndex = dgvthongke.Rows.Add();
                    DataGridViewRow row = dgvthongke.Rows[rowIndex];

                    row.Cells["MaThongKe"].Value = tk.MaThongKe;
                    // Định dạng ngày cho dễ đọc
                    row.Cells["NgayLap"].Value = tk.NgayLap;
                    row.Cells["SoLuongGiayBan"].Value = tk.SoLuongBan;
                    // Định dạng tiền tệ cho dễ đọc (ví dụ: VNĐ)
                    row.Cells["DoanhThu"].Value = tk.DoanhThu.ToString("N0") + " VNĐ";
                }

            }
            catch (Exception ex)
            {
                // Hiển thị lỗi
                MessageBox.Show("Lỗi khi tải dữ liệu Thống Kê: " + ex.Message, "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvthongke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ThongKe_Load_1(object sender, EventArgs e)
        {

        }
    }
}
