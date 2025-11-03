using Microsoft.Data.SqlClient;
using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using BUS_QL_BanGiay;
using Snowflake.Net;
using DTO_QL_BanGiay;
using BUS_QL_BanGiay;
using DAL_QL_BanGiay;
namespace QL_BanGiay
{

    public partial class HoaDon : Form
    {

        private KhachHangThanThietBUS khBUS = new KhachHangThanThietBUS();
        HoaDonBUS hoaDonBUS = new HoaDonBUS();
        List<CTHoaDonDTO> danhSachChiTiet = new List<CTHoaDonDTO>();
        CTHoaDonBUS cthdBUS = new CTHoaDonBUS();
        DataTable dt;
        private bool cotk = false;
        private decimal tongGiaTri = 0;
        public HoaDon(DataTable dt)
        {
            InitializeComponent();

            this.dt = dt;

        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            uiDataGridView1.DataSource = dt;
            TinhTongVaHienThi(uiDataGridView1, lblTongGia);
        }
        private void TinhTongVaHienThi(DataGridView dtgrv, Label lblTongGia)
        {

            string tenCotGia = "Giá";
            if (dtgrv.Rows.Count == 0)
            {
                lblTongGia.Text = "Tổng: 0";
                return;
            }
            for (int i = 0; i < dtgrv.Rows.Count; i++)
            {
                if (dtgrv.Rows[i].IsNewRow) continue;
                object cellValue = dtgrv.Rows[i].Cells[tenCotGia].Value;
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    decimal giaHienTai;
                    if (decimal.TryParse(cellValue.ToString(), out giaHienTai))
                    {
                        tongGiaTri += giaHienTai;
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi: Giá trị '{cellValue}' tại hàng {i + 1} không phải là số hợp lệ.", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            lblthue.Text = "Thuế (10% giá trị đơn hàng) : " + tongGiaTri * (decimal)0.1;
            lblTongGia.Text = "Tổng giá đơn hàng : " + $"{tongGiaTri + tongGiaTri * (decimal)0.1:N0} VNĐ";

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {

                lblHang.Text = "Hạng: ";
                lblTongDiem.Text = "Tổng Điểm";
                return;
            }
            long maKhachHang;
            if (!long.TryParse(txtMaKH.Text, out maKhachHang))
            {

                lblHang.Text = "";
                lblTongDiem.Text = "";
                return;
            }
            try
            {
                KhachHangThanThietDTO khachHang = khBUS.GetKhachHangByMaKH(maKhachHang);

                // 3. Xử lý kết quả
                if (khachHang != null)
                {
                    // Hiển thị Tổng Điểm và Hạng Thành Viên lên các Label
                    lblHang.Text = "Hạng: " + khachHang.HangThanhVien.ToString();
                    lblTongDiem.Text = "Tổng Điểm: " + khachHang.TongDiem;
                    cotk = true;

                }
                else
                {
                    cotk = false;
                    uiLabel5.Visible = true;
                    // Không tìm thấy khách hàng
                    lblHang.Text = "N/A";
                    lblTongDiem.Text = "N/A";


                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi kết nối hoặc truy vấn

                lblHang.Text = "";
                lblTongDiem.Text = "";
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Length > 0)
            {
                if (cotk == false)
                {
                    if (!long.TryParse(txtMaKH.Text, out long maKH))
                    {
                        MessageBox.Show("Mã khách hàng không hợp lệ (phải là số nguyên lớn).", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    KhachHangThanThietDTO kh = new KhachHangThanThietDTO();

                    kh.MaKH = long.Parse(txtMaKH.Text.Trim());
                    kh.NgayThamGia = DateTime.Now; ;
                    kh.TrangThai = 1;
                    kh.NgayCapNhat = DateTime.Now;
                    khBUS.InsertKhachHangThanThiet(kh);


                }


                var worker = new IdWorker(1, 1);
                long newId = worker.NextId();
                int maNV = 1;
                DateTime ngayThamGia = DateTime.Now;
                decimal tongTien = tongGiaTri + (tongGiaTri * 0.1M);
                decimal thue = 0.1M;

                HoaDonDTO hoaDon = new HoaDonDTO
                {
                    MaHD = newId,
                    MaKH = long.Parse(txtMaKH.Text),
                    MaNV = 1,
                    NgayBan = DateTime.Now,
                    TongTien = tongGiaTri + (tongGiaTri * 0.1M),
                    Thue = 0.1M
                };

                hoaDonBUS.ThemHoaDon(hoaDon);

                foreach (DataGridViewRow row in uiDataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells[0].Value == null || row.Cells[2].Value == null || row.Cells[4].Value == null)
                        continue;

                    long maGiay = Convert.ToInt64(row.Cells[0].Value);
                    int soLuong = Convert.ToInt32(row.Cells[2].Value);
                    decimal giaBan = Convert.ToDecimal(row.Cells[4].Value);

                    danhSachChiTiet.Add(new CTHoaDonDTO(newId, maGiay, soLuong, giaBan));
                }

                try
                {
                    cthdBUS.ThemDanhSachChiTiet(danhSachChiTiet);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message, "Lỗi CSDL");
                }
                try
                {
                    int maKH = Convert.ToInt32(txtMaKH.Text);
                    int diemCong = 100;

                    KhachHangThanThietBUS khBUS = new KhachHangThanThietBUS();
                    khBUS.CongDiemChoKhach(maKH, diemCong);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật điểm: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Đơn hàng đã được tạo thành công!");
                this.Close();

            }



        }
    }
}
