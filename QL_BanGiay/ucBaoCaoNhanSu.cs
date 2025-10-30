using BUS_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class ucBaoCaoNhanSu : UserControl
    {
        NhanVienBUS nhanVienBUS = new NhanVienBUS();
        public ucBaoCaoNhanSu()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
        }

        private void ucBaoCaoNhanSu_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhanSu();
        }
        private void LoadDanhSachNhanSu()
        {
            try
            {
                DataTable dtNhanSu = nhanVienBUS.GetBaoCaoNhanVien();

                if (dtNhanSu == null || dtNhanSu.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu nhân sự để hiển thị.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    data_BaoCaoNS.DataSource = null;
                    return;
                }

                data_BaoCaoNS.DataSource = null;
                data_BaoCaoNS.Rows.Clear();
                data_BaoCaoNS.Columns.Clear();

                // ==== Cột ảnh đại diện ====
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "clmAvatar",
                    HeaderText = "Ảnh đại diện",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 120,
                    ValueType = typeof(Image),
                    DefaultCellStyle = { NullValue = null }
                };
                data_BaoCaoNS.Columns.Add(imgCol);
                data_BaoCaoNS.RowTemplate.Height = 120;

                // ==== Các cột còn lại ====
                string[] columnNames = { "Họ Tên", "Giới Tính", "Ngày Sinh", "Điện Thoại", "Email", "Địa Chỉ", "Chức vụ", "Trạng Thái", "Lương cơ bản" };
                foreach (string name in columnNames)
                {
                    data_BaoCaoNS.Columns.Add(name, name);
                }

                // ==== Load ảnh ====
                string basePath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                string imageFolder = Path.Combine(basePath, "Images");

                foreach (DataRow nv in dtNhanSu.Rows)
                {
                    int rowIndex = data_BaoCaoNS.Rows.Add();
                    DataGridViewRow row = data_BaoCaoNS.Rows[rowIndex];

                    // Load ảnh avatar
                    Image avatar = null;
                    if (nv["Avatar"] != DBNull.Value && !string.IsNullOrEmpty(nv["Avatar"].ToString()))
                    {
                        string imagePath = Path.Combine(imageFolder, nv["Avatar"].ToString());
                        if (File.Exists(imagePath))
                        {
                            try
                            {
                                using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                using (var img = Image.FromStream(fs))
                                {
                                    avatar = new Bitmap(img);
                                }
                            }
                            catch
                            {
                                avatar = null;
                            }
                        }
                    }
                    row.Cells["clmAvatar"].Value = avatar;

                    // Gán dữ liệu
                    row.Cells["Họ Tên"].Value = nv["HoTen"];
                    row.Cells["Giới Tính"].Value = nv["GioiTinh"];
                    row.Cells["Ngày Sinh"].Value = nv["NgaySinh"];
                    row.Cells["Điện Thoại"].Value = nv["DienThoai"];
                    row.Cells["Email"].Value = nv["Email"];
                    row.Cells["Địa Chỉ"].Value = nv["DiaChi"];
                    row.Cells["Chức vụ"].Value = nv["Role"];
                    row.Cells["Trạng Thái"].Value = nv["TrangThai"];
                    row.Cells["Lương cơ bản"].Value = nv["LuongCoBan"];
                }

                // ==== Cấu hình hiển thị ====
                data_BaoCaoNS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data_BaoCaoNS.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                data_BaoCaoNS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                data_BaoCaoNS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                data_BaoCaoNS.MultiSelect = false;
                data_BaoCaoNS.ReadOnly = true;
                data_BaoCaoNS.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân sự: {ex.Message}",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }



        private void uiPanel2_Click(object sender, EventArgs e)
        {

        }
    }


}
