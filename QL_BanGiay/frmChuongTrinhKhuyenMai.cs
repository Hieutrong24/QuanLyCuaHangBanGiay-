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
    public partial class frmChuongTrinhKhuyenMai : UserControl
    {
        private ChuongTrinhKhuyenMaiBUS chuongTrinhKhuyenMaiBUS = new ChuongTrinhKhuyenMaiBUS();
        public frmChuongTrinhKhuyenMai()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
        }

        private void frmChuongTrinhKhuyenMai_Load(object sender, EventArgs e)
        {
            LoadChuongTrinhKhuyenMai();
        }

        private void LoadChuongTrinhKhuyenMai()
        {
            try
            {
                data_DSKM.Rows.Clear();

                var danhSachCTKM = chuongTrinhKhuyenMaiBUS.GetAllChuongTrinhKhuyenMai();

                if (danhSachCTKM == null || danhSachCTKM.Count == 0)
                    return;

                foreach (var km in danhSachCTKM)
                {
                    data_DSKM.Rows.Add(
                        km.MaCTKM,
                        km.TenCTKM,
                        km.LoaiCTKM,
                        km.DieuKien,
                        km.NgayBatDau.ToString("dd/MM/yyyy"),
                        km.NgayKetThuc.ToString("dd/MM/yyyy"),
                        km.MucGiamGia
                        
                    );

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách CTKM: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(txtTKM.Text) || string.IsNullOrWhiteSpace(MucGiam.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin chương trình khuyến mãi.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(MucGiam.Text, out decimal mucGiam))
                {
                    MessageBox.Show("Mức giảm giá phải là số hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo DTO
                ChuongTrinhKhuyenMaiDTO chuongTrinhKhuyenMaiDTO = new ChuongTrinhKhuyenMaiDTO
                {
                    TenCTKM = txtTKM.Text.Trim(),
                    LoaiCTKM = cboLCT.Text.Trim(),
                    DieuKien = cboDKAD.Text.Trim(),
                    NgayBatDau = pkNBD.Value,
                    NgayKetThuc = pkNKT.Value,
                    MucGiamGia = mucGiam
                };

                // Gọi BUS để thêm vào database
                bool result = chuongTrinhKhuyenMaiBUS.ThemChuongTrinhKhuyenMai(chuongTrinhKhuyenMaiDTO);

                if (result)
                {
                    MessageBox.Show("Thêm chương trình khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChuongTrinhKhuyenMai();  
                }
                else
                {
                    MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chương trình khuyến mãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (data_DSKM.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một chương trình khuyến mãi để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dữ liệu từ giao diện
                long maCTKM = Convert.ToInt64(data_DSKM.CurrentRow.Cells[0].Value);

                // Kiểm tra rỗng
                if (string.IsNullOrWhiteSpace(txtTKM.Text) || string.IsNullOrWhiteSpace(MucGiam.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo DTO
                ChuongTrinhKhuyenMaiDTO chuongTrinhKhuyenMaiDTO = new ChuongTrinhKhuyenMaiDTO
                {
                    MaCTKM = maCTKM,
                    TenCTKM = txtTKM.Text.Trim(),
                    LoaiCTKM = cboLCT.Text.Trim(),
                    DieuKien = cboDKAD.Text.Trim(),
                    NgayBatDau = pkNBD.Value,
                    NgayKetThuc = pkNKT.Value,
                    MucGiamGia = decimal.TryParse(MucGiam.Text, out decimal mucGiam) ? mucGiam : 0
                };

                // Gọi BUS để cập nhật
                bool result = chuongTrinhKhuyenMaiBUS.CapNhatChuongTrinhKhuyenMai(chuongTrinhKhuyenMaiDTO);

                if (result)
                {
                    MessageBox.Show("Cập nhật chương trình khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChuongTrinhKhuyenMai(); // Reload lại DataGridView
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.Enabled)
            {
                try
                {
                    if (data_DSKM.CurrentRow == null)
                    {
                        MessageBox.Show("Vui lòng chọn một chương trình khuyến mãi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    long maCTKM = Convert.ToInt64(data_DSKM.CurrentRow.Cells[0].Value);
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa chương trình khuyến mãi này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        bool result = chuongTrinhKhuyenMaiBUS.XoaChuongTrinhKhuyenMai(maCTKM);
                        if (result)
                        {
                            MessageBox.Show("Xóa chương trình khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadChuongTrinhKhuyenMai(); // Reload lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
