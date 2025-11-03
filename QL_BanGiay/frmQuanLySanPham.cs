using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_BanGiay
{
    public partial class frmQuanLySanPham : UserControl
    {
        private SanPhamBUS sanPhamBUS = new SanPhamBUS();
        private ThuongHieuBUS thuongHieuBUS = new ThuongHieuBUS();
        private MauSacBUS mauSacBUS = new MauSacBUS();
        public frmQuanLySanPham()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            //data_SP.CellContentClick += data_SP_CellContentClick;


            TongLoaiSP();
            tongTonKho();
            SanPhamSapHet();
            TongGTTK();
            ThemDanhMucLocSanPham();
            MucDangXuat();
 

            uiPanel_TongSP.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            uiPanel_TonKho.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            uiPanel_SPHetHang.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            uiPanel_GiaTriHangTon.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            uiPanel_TongVonTon.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Resize += frmQuanLySanPham_Resize;

            txtSearch.CueHint.CueHintText = "Tìm kiếm sản phẩm...";

        }
        private void frmQuanLySanPham_Resize(object sender, EventArgs e)
        {
            int spacing1 = 10; // khoảng cách giữa các panel
            int totalSpacing = spacing1 * 4;
            int panelWidth = (this.ClientSize.Width - totalSpacing) / 5;

            uiPanel_TongSP.Width = panelWidth;
            uiPanel_TonKho.Width = panelWidth;
            uiPanel_SPHetHang.Width = panelWidth;
            uiPanel_GiaTriHangTon.Width = panelWidth;
            uiPanel_TongVonTon.Width = panelWidth;

            uiPanel_TongSP.Left = 0;
            uiPanel_TonKho.Left = uiPanel_TongSP.Right + spacing1;
            uiPanel_SPHetHang.Left = uiPanel_TonKho.Right + spacing1;
            uiPanel_GiaTriHangTon.Left = uiPanel_SPHetHang.Right + spacing1;
            uiPanel_TongVonTon.Left = uiPanel_GiaTriHangTon.Right + spacing1;


            

        }

        private void data_SP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && data_SP.Columns[e.ColumnIndex].Name == "checkbox")
            //{
            //    // Cập nhật giá trị checkbox (toggle)
            //    data_SP.CommitEdit(DataGridViewDataErrorContexts.Commit);

            //    bool isChecked = Convert.ToBoolean(data_SP.Rows[e.RowIndex].Cells["checkbox"].Value);

            //    if (isChecked)
            //    {
            //        // Hiện form thông báo cập nhật
            //        frmThongBaoCapNhat frm = new frmThongBaoCapNhat();
            //        frm.StartPosition = FormStartPosition.CenterParent;
            //        frm.ShowDialog();
            //    }
            //}
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LoadSanPham()
        {
            var list = sanPhamBUS.GetALL(); // giả sử GetALL trả List<SanPhamDTO>
            LoadSanPham(list);
        }


        private void LoadSanPham(IEnumerable<SanPhamDTO> list)
        {
            try
            {
                // Xóa DataSource và dữ liệu cũ
                data_SP.DataSource = null;
                data_SP.AutoGenerateColumns = false;
                data_SP.Rows.Clear();

                // Xoá checkbox cũ (nếu có) để tránh chồng cột
                if (data_SP.Columns.Contains("checkbox"))
                    data_SP.Columns.Remove("checkbox");

                // Thêm cột checkbox (ở vị trí đầu)
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn
                {
                    Name = "checkbox",
                    HeaderText = "",
                    Width = 40,
                    TrueValue = true,
                    FalseValue = false,
                    ThreeState = false,
                    ReadOnly = false,
                    FlatStyle = FlatStyle.Standard
                };
                data_SP.Columns.Insert(0, chk);

                // Thêm cột ảnh nếu chưa có
                if (!data_SP.Columns.Contains("clmAnh"))
                {
                    DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                    {
                        Name = "clmAnh",
                        HeaderText = "Ảnh",
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
                        Width = 250,
                        ValueType = typeof(Image),
                        DefaultCellStyle = { NullValue = null }
                    };

                    data_SP.Columns.Insert(0, imgCol);
                    data_SP.RowTemplate.Height = 180;
                }

                // Tạo các cột dữ liệu cần thiết (nếu chưa có)
                string[] requiredColumns = { "clmMaSP", "clmTenSP", "clmNH", "clmGV", "clmGB", "clmTK", "CLMTT" };
                foreach (string colName in requiredColumns)
                {
                    if (!data_SP.Columns.Contains(colName))
                    {
                        data_SP.Columns.Add(colName, colName);
                    }
                }

                // Đường dẫn thư mục ảnh trong project
                string basePath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                string imageFolder = Path.Combine(basePath, "Images");

                // Duyệt danh sách sản phẩm
                foreach (var sp in list)
                {
                    int rowIndex = data_SP.Rows.Add();
                    DataGridViewRow row = data_SP.Rows[rowIndex];

                    // Load ảnh an toàn (tránh khoá file)
                    if (!string.IsNullOrEmpty(sp.HinhAnh))
                    {
                        string imagePath = Path.Combine(imageFolder, sp.HinhAnh);
                        if (File.Exists(imagePath))
                        {
                            try
                            {
                                using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                using (var img = Image.FromStream(fs))
                                {
                                    row.Cells["clmAnh"].Value = new Bitmap(img);
                                }
                            }
                            catch
                            {
                                row.Cells["clmAnh"].Value = null;
                            }
                        }
                        else
                        {
                            row.Cells["clmAnh"].Value = null;
                        }
                    }
                    else
                    {
                        row.Cells["clmAnh"].Value = null;
                    }

                    // Gán dữ liệu cho từng cột
                    row.Cells["checkbox"].Value = false;
                    row.Cells["clmMaSP"].Value = sp.MaGiay;
                    row.Cells["clmTenSP"].Value = sp.TenGiay;
                    row.Cells["clmNH"].Value = sp.MaThuongHieu;
                    row.Cells["clmGV"].Value = sp.DonGia;
                    row.Cells["clmGB"].Value = sp.DonGia;
                    row.Cells["clmTK"].Value = sp.SoLuong;
                    row.Cells["CLMTT"].Value = sp.TrangThai;
                }

                // Cấu hình hiển thị
                data_SP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data_SP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                data_SP.MultiSelect = false;
                data_SP.ReadOnly = false;

                // Chỉ cho phép chọn checkbox
                foreach (DataGridViewColumn col in data_SP.Columns)
                {
                    col.ReadOnly = col.Name != "checkbox";
                }

                ((Krypton.Toolkit.KryptonDataGridView)data_SP).Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu sản phẩm: " + ex.Message);
            }
        }


        //Tao danh muc con
        private void ThemDanhMucLocSanPham()
        {
             
            KryptonContextMenu kcm = new KryptonContextMenu();
            KryptonContextMenuItems items = new KryptonContextMenuItems();

            
            var locTheoHang = new KryptonContextMenuItem("Lọc theo hãng");

            try
            {
                var dsThuongHieu = thuongHieuBUS.LayDanhSachThuongHieu();  
                foreach (var th in dsThuongHieu)
                {
                    var itemHang = new KryptonContextMenuItem(th.TenThuongHieu, OnLocTheoHangClick)
                    {
                        Tag = th.MaThuongHieu  
                    };
                    locTheoHang.Items.Add(itemHang);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách thương hiệu: " + ex.Message);
            }

            
            var locTheoMau = new KryptonContextMenuItem("Lọc theo màu sắc");

            try
            {
                var dsMauSac = mauSacBUS.GetALL();  
                foreach (var mau in dsMauSac)
                {
                    var itemMau = new KryptonContextMenuItem(mau.TenMau, OnLocTheoMauClick)
                    {
                        Tag = mau.MaMau  
                    };
                    locTheoMau.Items.Add(itemMau);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách màu sắc: " + ex.Message);
            }

     
            var locTheoGia = new KryptonContextMenuItem("Lọc theo giá");

            var giaCaoThap = new KryptonContextMenuItem("Giá từ cao → thấp", OnLocGiaCaoThapClick);
            var giaThapCao = new KryptonContextMenuItem("Giá từ thấp → cao", OnLocGiaThapCaoClick);

            locTheoGia.Items.Add(giaCaoThap);
            locTheoGia.Items.Add(giaThapCao);

       
            items.Items.Add(locTheoHang);
            items.Items.Add(locTheoMau);
            items.Items.Add(locTheoGia);

             
            kcm.Items.Add(items);

           
            btndrpLoc.KryptonContextMenu = kcm;
        }



 
        private void OnLocTheoHangClick(object sender, EventArgs e)
        {
            if (sender is KryptonContextMenuItem item && item.Tag is long maTH)
            {
                var list = sanPhamBUS.LocTheoHang(maTH);
                LoadSanPham(list); 
            }
        }

        private void OnLocTheoMauClick(object sender, EventArgs e)
        {
            if (sender is KryptonContextMenuItem item && item.Tag is long maMau)
            {
                var list = sanPhamBUS.LocTheoMau(maMau);
                LoadSanPham(list);  
            }
        }
 


        
        private void OnLocGiaThapCaoClick(object sender, EventArgs e)
        {
            var list = sanPhamBUS.LocTheoGia("ASC");  
            LoadSanPham(list);
        }
        private void OnLocGiaCaoThapClick(object sender, EventArgs e)
        {
            var list = sanPhamBUS.LocTheoGia("DESC");
            LoadSanPham(list);
        }




        private void OnDanhMuc1Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã chọn Danh mục 1");
        }

        private void OnDanhMuc2Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã chọn Danh mục 2");
        }

        private void OnDanhMuc3Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã chọn Danh mục 3");
        }
        //Dang xuat
        private void MucDangXuat()
        {
            KryptonContextMenu kcm = new KryptonContextMenu();
            KryptonContextMenuItems items = new KryptonContextMenuItems();
            items.Items.Add(new KryptonContextMenuItem("Đăng xuất", OnDangXuatClick));
            kcm.Items.Add(items);
            btndrpLogout.KryptonContextMenu = kcm;
        }
        private void OnDangXuatClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return;
            }
        }

        private void TongLoaiSP()
        {
            lblTSP.Text = sanPhamBUS.SoLuongLoaiSP().ToString();
        }
        private void tongTonKho()
        {
            lblTK.Text = sanPhamBUS.TongTonKho().ToString();
        }
        private void SanPhamSapHet()
        {
            lblSPHH.Text = sanPhamBUS.SoSanPhamSapHet().ToString();
        }
        private void TongGTTK()
        {
            lblGTHT.Text = sanPhamBUS.TongGiaTriTonKho().ToString();
        }
        private void kryptonLabel5_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            ThemSanPham themSPForm = new ThemSanPham();
            themSPForm.FormClosed += (s, args) => LoadSanPham(); // Tải lại dữ liệu khi form đóng
            themSPForm.ShowDialog();

        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                List<long> ids = new List<long>();

                // 🔹 Duyệt tất cả các dòng để lấy ID đã tick
                foreach (DataGridViewRow row in data_SP.Rows)
                {
                    bool isChecked = row.Cells["checkbox"].Value != null && Convert.ToBoolean(row.Cells["checkbox"].Value);
                    if (isChecked && row.Cells["clmMaSP"].Value != null)
                    {
                        ids.Add(Convert.ToInt64(row.Cells["clmMaSP"].Value));
                    }
                }

                // 🔹 Nếu có tick chọn nhiều
                if (ids.Count > 0)
                {
                    DialogResult confirm = MessageBox.Show(
                        $"Bạn có chắc muốn xoá {ids.Count} sản phẩm đã chọn không?",
                        "Xác nhận xoá",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        int deleted = 0;

                        foreach (long id in ids)
                        {
                            if (sanPhamBUS.XoaSP(id))
                                deleted++;
                        }

                        MessageBox.Show($"Đã xoá {deleted}/{ids.Count} sản phẩm thành công!");
                        LoadSanPham();
                    }

                    return;
                }

                // 🔹 Nếu không tick mà chỉ chọn 1 dòng
                if (data_SP.SelectedRows.Count > 0)
                {
                    long maSP = Convert.ToInt64(data_SP.SelectedRows[0].Cells["clmMaSP"].Value);

                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc muốn xoá sản phẩm này không?",
                        "Xác nhận xoá",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        bool success = sanPhamBUS.XoaSP(maSP);
                        if (success)
                        {
                            MessageBox.Show("Đã xoá sản phẩm thành công!");
                            LoadSanPham();
                        }
                        else
                        {
                            MessageBox.Show("Xoá sản phẩm thất bại!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xoá!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá sản phẩm: " + ex.Message);
            }
        }

        private void btndrpLoc_Click(object sender, EventArgs e)
        {

        }

        private void lblTSP_Click(object sender, EventArgs e)
        {

        }

        private void lblTK_Click(object sender, EventArgs e)
        {

        }

        private void lblSPHH_Click(object sender, EventArgs e)
        {

        }

        private void lblGTHT_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel_TongVonTon_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLabel7_Click(object sender, EventArgs e)
        {

        }
    }
}
