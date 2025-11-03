using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QL_BanGiay;
using DTO_QL_BanGiay;

namespace QL_BanGiay
{
    public partial class themgiay : Form
    {
        private GiayBUS giayBUS = new GiayBUS();
        private MauSacBUS mauSacBUS = new MauSacBUS();
        private ThuongHieuBUS thuongHieuBUS = new ThuongHieuBUS();
        private XuatXuBUS xuatXuBUS = new XuatXuBUS();
        private LoaiBUS loaiBUS = new LoaiBUS();
        public event Action OnProductAdded;

        public themgiay()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cbLoaiGiay.SelectedValue == null || cbMauSac.SelectedValue == null ||
                cbThuongHieu.SelectedValue == null || cbXuatXu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại, màu, thương hiệu và xuất xứ.");
                return;
            }

            long maLoai = Convert.ToInt64(cbLoaiGiay.SelectedValue);
            long maMau = Convert.ToInt64(cbMauSac.SelectedValue);
            long maTH = Convert.ToInt64(cbThuongHieu.SelectedValue);
            long maXX = Convert.ToInt64(cbXuatXu.SelectedValue);

            if (!int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ!"); return;
            }
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!"); return;
            }
            if (!int.TryParse(txtSize.Text, out int size))
            {
                MessageBox.Show("Size không hợp lệ!"); return;
            }

            GiayDTO g = new GiayDTO
            {
                TenGiay = txtTenGiay.Text,
                SoLuong = soLuong,
                DonGia = donGia,
                Size = size,
                DoiTuongSD = cbDoiTuong.SelectedItem?.ToString(),
                MaLoai = maLoai,
                MaXX = maXX,
                MaThuongHieu = maTH,
                MaMau = maMau
            };

            try
            {
                giayBUS.ThemGiayVaChiTietPhieuNhap(g);
                OnProductAdded?.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm giày: " + ex.Message);
            }
        }

        private void themgiay_Load(object sender, EventArgs e)
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
            cbDoiTuong.SelectedIndex = 0;
            if (cbLoaiGiay.Items.Count > 0) cbLoaiGiay.SelectedIndex = 0;
            if (cbMauSac.Items.Count > 0) cbMauSac.SelectedIndex = 0;
            if (cbThuongHieu.Items.Count > 0) cbThuongHieu.SelectedIndex = 0;
            if (cbXuatXu.Items.Count > 0) cbXuatXu.SelectedIndex = 0;
        }
    }
}
