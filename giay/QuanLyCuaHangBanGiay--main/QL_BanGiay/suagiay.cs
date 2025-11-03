using System;
using System.Data;
using System.Windows.Forms;
using BUS_QL_BanGiay;
using DAL_QL_BanGiay;
using DTO_QL_BanGiay;

namespace QL_BanGiay
{
    public partial class suagiay : Form
    {
        private GiayBUS giayBUS = new GiayBUS();
        private MauSacBUS mauSacBUS = new MauSacBUS();
        private ThuongHieuBUS thuongHieuBUS = new ThuongHieuBUS();
        private XuatXuBUS xuatXuBUS = new XuatXuBUS();
        private LoaiBUS loaiBUS = new LoaiBUS();
        private GiayDTO giayHienTai; 

        public suagiay(GiayDTO giayCanSua)
        {
            InitializeComponent();
            giayHienTai = giayCanSua;
        }

        private void suagiay_Load(object sender, EventArgs e)
        {
            cbDoiTuong.Items.AddRange(new string[] { "Nam", "Nữ", "Unisex" });
            var dsLoai = loaiBUS.LayDanhSachLoai();
            cbLoaiGiay.DataSource = dsLoai;
            cbLoaiGiay.DisplayMember = "TenLoai";
            cbLoaiGiay.ValueMember = "MaLoai";
            var dsMau = mauSacBUS.GetALL();
            cbMauSac.DataSource = dsMau;
            cbMauSac.DisplayMember = "TenMau";
            cbMauSac.ValueMember = "MaMau";
            var dsThuongHieu = thuongHieuBUS.LayDanhSachThuongHieu();
            cbThuongHieu.DataSource = dsThuongHieu;
            cbThuongHieu.DisplayMember = "TenThuongHieu";
            cbThuongHieu.ValueMember = "MaThuongHieu";
            var dsXuatXu = xuatXuBUS.GetAll();
            cbXuatXu.DataSource = dsXuatXu;
            cbXuatXu.DisplayMember = "TenXX";
            cbXuatXu.ValueMember = "MaXX";
            if (giayHienTai != null)
            {
                txtTenGiay.Text = giayHienTai.TenGiay;
                txtSoLuong.Text = giayHienTai.SoLuong.ToString();
                txtDonGia.Text = giayHienTai.DonGia.ToString();
                txtSize.Text = giayHienTai.Size.ToString();
                cbDoiTuong.SelectedItem = giayHienTai.DoiTuongSD ?? "Unisex";
                cbLoaiGiay.SelectedValue = giayHienTai.MaLoai;
                cbMauSac.SelectedValue = giayHienTai.MaMau;
                cbThuongHieu.SelectedValue = giayHienTai.MaThuongHieu;
                cbXuatXu.SelectedValue = giayHienTai.MaXX;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenGiay.Text))
            {
                MessageBox.Show("Vui lòng nhập tên giày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSize.Text, out int size))
            {
                MessageBox.Show("Size không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbLoaiGiay.SelectedValue == null || cbMauSac.SelectedValue == null ||
                cbThuongHieu.SelectedValue == null || cbXuatXu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại giày, màu sắc, thương hiệu và xuất xứ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            giayHienTai.TenGiay = txtTenGiay.Text.Trim();
            giayHienTai.SoLuong = soLuong;
            giayHienTai.DonGia = donGia;
            giayHienTai.Size = size;
            giayHienTai.DoiTuongSD = cbDoiTuong.SelectedItem?.ToString();
            giayHienTai.MaLoai = Convert.ToInt64(cbLoaiGiay.SelectedValue);
            giayHienTai.MaMau = Convert.ToInt64(cbMauSac.SelectedValue);
            giayHienTai.MaThuongHieu = Convert.ToInt64(cbThuongHieu.SelectedValue);
            giayHienTai.MaXX = Convert.ToInt64(cbXuatXu.SelectedValue);

            try
            {
                bool ketQua = giayBUS.CapNhatGiay(giayHienTai);

                if (ketQua)
                {
                    MessageBox.Show("Cập nhật giày thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không có thay đổi hoặc lỗi khi cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật giày: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
