using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using Microsoft.Data.SqlClient;
using Sunny.UI;
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
using Microsoft.VisualBasic;
using DAL_QL_BanGiay;

namespace QL_BanGiay

{
    public partial class QLYKho : Form
    {

        DataTable dt;
        private List<Control> savedPanelControls;
        private ComboBox cboMaLoai;
        private string tenGiayInput;
        private string soLuongInput;
        private string donGiaInput;
        private string sizeInput;
        private string doiTuongInput;
        private string chatLieuInput;
        private GiayBUS giayBUS = new GiayBUS();
        private LoaiBUS loaiBUS = new LoaiBUS();
        public QLYKho()
        {
            InitializeComponent();
            this.Load += QLYKho_Load;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void QLYKho_Load(object sender, EventArgs e)
        {
            savedPanelControls = panel1.Controls.Cast<Control>().ToList();
            LoadData();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RefreshLoaiGiayNodes();
            guna2TextBox1.KeyDown += guna2TextBox1_KeyDown;
            this.uiNavMenu1.MenuItemClick += new Sunny.UI.UINavMenu.OnMenuItemClick(uiNavMenu1_MenuItemClick);
            cboMaLoai = new ComboBox();
            cboMaLoai.Visible = false;
            cboMaLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaLoai.Location = new Point(150, 100);
            cboMaLoai.Width = 200;
            this.Controls.Add(cboMaLoai);
            cboMaLoai.SelectionChangeCommitted += cboMaLoai_SelectionChangeCommitted;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            button5.FlatAppearance.MouseDownBackColor = Color.LightGray;
            guna2TextBox1.Clear();
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            button6.FlatAppearance.MouseDownBackColor = Color.LightGray;
        }
        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
        }

        private void uiSplitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiAvatar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }
        private void LoadData()
        {
            dataGridView1.DataSource = giayBUS.LayDanhSachGiay();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            if (!dataGridView1.Columns.Contains("HinhAnh"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "HinhAnh";
                imgCol.HeaderText = "Hình ảnh";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.Columns.Insert(1, imgCol);
            }
            DoiCotMaMauThanhTen();
            DoiCotMaThuongHieuThanhTen();
            DoiCotMaXuatXuThanhTen();
            DoiCotMaLoaiThanhTen();
            GanHinhChoGiay();
        }

        private void DoiCotMaMauThanhTen()
        {
            try
            {
                // Kiểm tra tồn tại cột MaMau
                if (!dataGridView1.Columns.Contains("MaMau"))
                    return;

                MauSacBUS mauSacBUS = new MauSacBUS();
                var dsMau = mauSacBUS.GetALL();
                var dictMau = dsMau.ToDictionary(m => m.MaMau, m => m.TenMau);

                // Thêm cột hiển thị tên màu nếu chưa có
                if (!dataGridView1.Columns.Contains("TenMau"))
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = "TenMau";
                    col.HeaderText = "Tên Màu";
                    dataGridView1.Columns.Add(col);
                }

                // Gán dữ liệu tên màu
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    var cellValue = row.Cells["MaMau"].Value;
                    if (cellValue == null || cellValue == DBNull.Value) continue;

                    if (long.TryParse(cellValue.ToString(), out long maMau) && dictMau.ContainsKey(maMau))
                        row.Cells["TenMau"].Value = dictMau[maMau];
                }

                dataGridView1.Columns["MaMau"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị tên màu: " + ex.Message);
            }
        }

        private void DoiCotMaThuongHieuThanhTen()
        {
            try
            {
                if (!dataGridView1.Columns.Contains("MaThuongHieu"))
                    return;

                ThuongHieuBUS thuongHieuBUS = new ThuongHieuBUS();
                var dsTH = thuongHieuBUS.LayDanhSachThuongHieu();
                var dictTH = dsTH.ToDictionary(th => th.MaThuongHieu, th => th.TenThuongHieu);

                if (!dataGridView1.Columns.Contains("TenThuongHieu"))
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = "TenThuongHieu";
                    col.HeaderText = "Thương Hiệu";
                    dataGridView1.Columns.Add(col);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    var cellValue = row.Cells["MaThuongHieu"].Value;
                    if (cellValue == null || cellValue == DBNull.Value) continue;

                    if (long.TryParse(cellValue.ToString(), out long maTH) && dictTH.ContainsKey(maTH))
                        row.Cells["TenThuongHieu"].Value = dictTH[maTH];
                }

                dataGridView1.Columns["MaThuongHieu"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị tên thương hiệu: " + ex.Message);
            }
        }

        private void DoiCotMaXuatXuThanhTen()
        {
            try
            {
                if (!dataGridView1.Columns.Contains("MaXX"))
                    return;

                XuatXuBUS xuatXuBUS = new XuatXuBUS();
                var dsXuatXu = xuatXuBUS.GetAll();
                var dictXX = dsXuatXu.ToDictionary(x => x.MaXX, x => x.TenXX);

                if (!dataGridView1.Columns.Contains("TenXX"))
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = "TenXX";
                    col.HeaderText = "Xuất Xứ";
                    dataGridView1.Columns.Add(col);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    var cellValue = row.Cells["MaXX"].Value;
                    if (cellValue == null || cellValue == DBNull.Value) continue;

                    if (long.TryParse(cellValue.ToString(), out long maXX))
                    {
                        if (dictXX.TryGetValue(maXX, out string tenXX))
                            row.Cells["TenXX"].Value = tenXX;
                        else
                            row.Cells["TenXX"].Value = "Không rõ";
                    }
                }

                dataGridView1.Columns["MaXX"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị xuất xứ: " + ex.Message);
            }
        }

        private void DoiCotMaLoaiThanhTen()
        {
            try
            {
                if (!dataGridView1.Columns.Contains("MaLoai"))
                    return;

                LoaiBUS loaiBUS = new LoaiBUS();
                var dsLoai = loaiBUS.LayDanhSachLoai();
                var dictLoai = dsLoai.ToDictionary(l => l.MaLoai, l => l.TenLoai);

                if (!dataGridView1.Columns.Contains("TenLoai"))
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = "TenLoai";
                    col.HeaderText = "Loại Giày";
                    dataGridView1.Columns.Add(col);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    var cellValue = row.Cells["MaLoai"].Value;
                    if (cellValue == null || cellValue == DBNull.Value) continue;

                    if (long.TryParse(cellValue.ToString(), out long maLoai) && dictLoai.ContainsKey(maLoai))
                        row.Cells["TenLoai"].Value = dictLoai[maLoai];
                }

                dataGridView1.Columns["MaLoai"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị loại giày: " + ex.Message);
            }
        }


        private void TimKiemSanPham()
        {
            string keyword = guna2TextBox1.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Nhập từ khóa!");
                return;
            }
            dataGridView1.DataSource = giayBUS.TimGiayTheoTen(keyword);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void GanHinhChoGiay()
        {
            string basePath = Path.Combine(Application.StartupPath, @"..\..\..\Images");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["MaGiay"].Value == null) continue;

                long maGiay = Convert.ToInt64(row.Cells["MaGiay"].Value);
                string tenGiay = row.Cells["TenGiay"].Value?.ToString() ?? "";
                string imgPath = "";
                string[] possibleFiles = Directory.GetFiles(basePath, $"{maGiay}_*.jpg");
                if (possibleFiles.Length > 0)
                {
                    imgPath = possibleFiles[0];
                }
                else
                {
                    string lower = tenGiay.ToLower();
                    if (lower.Contains("ultraboost"))
                        imgPath = basePath + "adidas.jpg";
                    else if (lower.Contains("superstar"))
                        imgPath = basePath + "superstar.jpg";
                    else if (lower.Contains("air force"))
                        imgPath = basePath + "airforce.jpg";
                    else if (lower.Contains("pegasus"))
                        imgPath = basePath + "pegasus.jpg";
                }

                if (File.Exists(imgPath))
                {
                    using (var imgTemp = Image.FromFile(imgPath))
                    {
                        row.Cells["HinhAnh"].Value = new Bitmap(imgTemp);
                    }
                }
                else
                {
                    row.Cells["HinhAnh"].Value = null;
                }
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            TimKiemSanPham();
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox1.BorderRadius = 20;
            guna2TextBox1.PlaceholderText = "Tìm kiếm...";
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                guna2TextBox1.Clear();
                LoadData();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimKiemSanPham();
                e.SuppressKeyPress = true;
            }
        }
        private void LoadDataByLoai(string tenLoai)
        {
            try
            {
                // Gọi BUS để lấy dữ liệu (thay vì thao tác SQL trực tiếp)
                DataTable dt = giayBUS.LayGiayTheoLoai(tenLoai);

                // Gán dữ liệu lên DataGridView
                dataGridView1.DataSource = dt;
                DoiCotMaMauThanhTen();
                DoiCotMaThuongHieuThanhTen();
                DoiCotMaXuatXuThanhTen();
                DoiCotMaLoaiThanhTen();
                GanHinhChoGiay();
                // Cấu hình hiển thị
                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.DefaultCellStyle.BackColor = Color.White;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                // Thêm cột hình ảnh nếu chưa có
                if (!dataGridView1.Columns.Contains("HinhAnh"))
                {
                    DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                    imgCol.Name = "HinhAnh";
                    imgCol.HeaderText = "Hình Ảnh";
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dataGridView1.Columns.Insert(1, imgCol);
                }

                // Gọi hàm gán hình ảnh (nếu bạn đã định nghĩa)
                GanHinhChoGiay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giày theo loại: " + ex.Message);
            }
        }

        public void HienThiTheoLoai(string tenLoai)
        {
            if (string.IsNullOrEmpty(tenLoai))
                LoadData();
            else
                LoadDataByLoai(tenLoai);
        }
        private Form currentForm = null;
        private QLYKho formQLYKho = null;
        private void ShowFormInPanel(Form form)
        {
            panel1.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel1.Controls.Add(form);
            form.Show();

            currentForm = form;
        }
        private void LoadLoaiGiayNodes(TreeNode nodeCha)
        {
            try
            {
                List<LoaiDTO> dsLoai = LoaiBUS.LayTatCaLoai();
                nodeCha.Nodes.Clear();

                foreach (var loai in dsLoai)
                {
                    TreeNode nodeCon = new TreeNode(loai.TenLoai)
                    {
                        Tag = loai.MaLoai
                    };
                    nodeCha.Nodes.Add(nodeCon);
                }

                nodeCha.Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load loại giày: " + ex.Message);
            }
        }
        private void RefreshLoaiGiayNodes()
        {
            TreeNode nodeKho = null;
            foreach (TreeNode n in uiNavMenu1.Nodes)
            {
                if (n != null && n.Text != null && n.Text.Trim() == "Quản Lý Kho")
                {
                    nodeKho = n;
                    break;
                }
            }

            if (nodeKho == null) return;

            nodeKho.Nodes.Clear();
            LoadLoaiGiayNodes(nodeKho);
        }



        private void ShowLoaiGiayTable()
        {
            panel1.Controls.Clear();
            DataGridView dgvLoai = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White
            };

            try
            {
                dgvLoai.DataSource = loaiBUS.LayDanhSachLoai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load bảng Loại: " + ex.Message);
            }
            FlowLayoutPanel flpButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 70,
                Padding = new Padding(15),
                BackColor = Color.FromArgb(245, 247, 250),
                FlowDirection = FlowDirection.LeftToRight
            };

            string iconPath = Path.Combine(Application.StartupPath, @"..\..\..\Images\Icons\");
            iconPath = Path.GetFullPath(iconPath);

            Button btnThem = TaoNut(Path.Combine(iconPath, "add.png"), "Thêm Loại", 120, 40);
            Button btnSua = TaoNut(Path.Combine(iconPath, "edit.png"), "Sửa", 100, 40);
            Button btnXoa = TaoNut(Path.Combine(iconPath, "delete.png"), "Xóa", 100, 40);

            void StyleButton(Button btn)
            {
                btn.BackColor = Color.WhiteSmoke;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.ForeColor = Color.Black;
                btn.MouseEnter += (s, e) => btn.BackColor = Color.Gainsboro;
                btn.MouseLeave += (s, e) => btn.BackColor = Color.WhiteSmoke;
            }

            StyleButton(btnThem);
            StyleButton(btnSua);
            StyleButton(btnXoa);

            flpButtons.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa });
            Panel container = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            container.Controls.Add(dgvLoai);
            container.Controls.Add(flpButtons);

            panel1.Controls.Clear();
            panel1.Controls.Add(container);

            btnThem.Click += (s, e) =>
            {
                string tenMoi = Interaction.InputBox("Nhập tên loại giày mới:", "Thêm loại giày", "").Trim();

                if (string.IsNullOrWhiteSpace(tenMoi))
                {
                    MessageBox.Show("Tên loại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Kiểm tra trùng tên loại trước khi thêm
                    var dsLoai = loaiBUS.LayDanhSachLoai();
                    if (dsLoai.Any(l => l.TenLoai.Equals(tenMoi, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Tên loại này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Gọi BUS để thêm
                    bool kq = loaiBUS.ThemLoai(tenMoi);

                    if (kq)
                    {
                        MessageBox.Show(" Thêm loại giày thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowLoaiGiayTable();  
                        RefreshLoaiGiayNodes();  
                    }
                    else
                    {
                        MessageBox.Show(" Thêm loại thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm loại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            btnXoa.Click += (s, e) =>
            {
                if (dgvLoai.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn loại giày cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                long maLoai = Convert.ToInt64(dgvLoai.CurrentRow.Cells["MaLoai"].Value);
                string tenLoai = dgvLoai.CurrentRow.Cells["TenLoai"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa loại '{tenLoai}' không?",
                                    "Xác nhận xóa",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                    return;

                string error;
                bool kq = loaiBUS.XoaLoai(maLoai, out error);

                if (kq)
                {
                    MessageBox.Show(" Xóa loại giày và dữ liệu liên quan thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowLoaiGiayTable();
                    RefreshLoaiGiayNodes();
                }
                else
                {
                    MessageBox.Show($"❌ Không thể xóa loại này!\n\nChi tiết: {error}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnSua.Click += (s, e) =>
            {
                if (dgvLoai.SelectedRows.Count == 0) return;

                long id = Convert.ToInt64(dgvLoai.SelectedRows[0].Cells["MaLoai"].Value);
                string tenCu = dgvLoai.SelectedRows[0].Cells["TenLoai"].Value.ToString();
                string tenMoi = Interaction.InputBox("Nhập tên mới:", "Sửa loại", tenCu);

                if (string.IsNullOrWhiteSpace(tenMoi)) return;

                try
                {
                    loaiBUS.SuaLoai(id, tenMoi);
                    MessageBox.Show("Cập nhật loại thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa loại: " + ex.Message);
                }

                ShowLoaiGiayTable();
                RefreshLoaiGiayNodes();
            };
        }

        private void uiNavMenu1_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            string nodeName = node.Text.Trim();

            switch (nodeName)
            {
                case "Quản Lý Kho":
                    RestoreMainProductView();
                    break;
                case "Chỉnh Sửa Thể Loại Giày":
                    ShowLoaiGiayTable();
                    break;
                case "Nhập hàng":
                    RestoreMainProductView();
                    ShowNhapHangView();
                    break;
                case "Giày Thể Thao":
                    HienThiTheoLoai("Giày Thể Thao");
                    break;
                case "Giày Thường Ngày":
                    HienThiTheoLoai("Giày Thường Ngày");
                    break;

                case "Giày Thời Trang":
                    HienThiTheoLoai("Giày Thời Trang");
                    break;
                default:
                    HienThiTheoLoai(nodeName);
                    break;
            }
        }
        private void RestoreMainProductView()
        {
            panel1.Controls.Clear();

            if (savedPanelControls != null && savedPanelControls.Count > 0)
            {
                foreach (Control c in savedPanelControls)
                {
                    panel1.Controls.Add(c);
                }
            }
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message);
            }
        }
        private Button TaoNut(string iconFile, string text, int width = 110, int height = 40)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.TextAlign = ContentAlignment.MiddleRight;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Width = width;
            btn.Height = height;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(240, 240, 240);
            btn.ForeColor = Color.Black;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            if (!string.IsNullOrEmpty(iconFile) && File.Exists(iconFile))
            {
                using (var img = Image.FromFile(iconFile))
                {
                    btn.Image = new Bitmap(img);
                }
                btn.ImageAlign = ContentAlignment.MiddleLeft;
            }
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Padding = new Padding(6, 0, 6, 0);
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(220, 220, 220);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(240, 240, 240);
            return btn;
        }


        private void ThemNutQuanLyGiay()
        {
            FlowLayoutPanel flpButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(0, 10, 0, 10),
                BackColor = Color.FromArgb(245, 247, 250),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false
            };

            string iconPath = Path.Combine(Application.StartupPath, @"..\..\..\Images\Icons\");
            iconPath = Path.GetFullPath(iconPath);

            Button btnThemGiay = TaoNut(Path.Combine(iconPath, "add.png"), "Thêm", 110, 40);
            Button btnSuaGiay = TaoNut(Path.Combine(iconPath, "edit.png"), "Sửa", 110, 40);
            Button btnXoaGiay = TaoNut(Path.Combine(iconPath, "delete.png"), "Xóa", 110, 40);
            Button btnThemAnh = TaoNut(Path.Combine(iconPath, "image.png"), "Thêm Ảnh", 130, 40);

            void StyleButton(Button btn)
            {
                btn.BackColor = Color.WhiteSmoke;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.ForeColor = Color.Black;
                btn.MouseEnter += (s, e) => btn.BackColor = Color.Gainsboro;
                btn.MouseLeave += (s, e) => btn.BackColor = Color.WhiteSmoke;
            }

            StyleButton(btnThemGiay);
            StyleButton(btnSuaGiay);
            StyleButton(btnXoaGiay);
            StyleButton(btnThemAnh);

            flpButtons.Controls.Add(btnThemGiay);
            flpButtons.Controls.Add(btnSuaGiay);
            flpButtons.Controls.Add(btnXoaGiay);
            flpButtons.Controls.Add(btnThemAnh);

            panel1.Controls.Add(flpButtons);

            btnThemGiay.Click += (s, e) =>
            {
                using (themgiay formThem = new themgiay())
                {
                    if (formThem.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            };

            // 2. Sửa giày
            btnSuaGiay.Click += (s, e) =>
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn giày cần sửa!");
                    return;
                }
                DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
                if (row == null)
                {
                    MessageBox.Show("Không thể lấy dữ liệu giày từ dòng được chọn!");
                    return;
                }
                GiayDTO selectedGiay = new GiayDTO
                {
                    IdGiay = Convert.ToInt64(row["MaGiay"]),
                    TenGiay = row["TenGiay"].ToString(),
                    DonGia = Convert.ToDecimal(row["DonGia"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    Size = row.Row.Table.Columns.Contains("Size") && row["Size"] != DBNull.Value ? Convert.ToInt32(row["Size"]) : 0,
                    MaLoai = row.Row.Table.Columns.Contains("MaLoai") && row["MaLoai"] != DBNull.Value ? Convert.ToInt64(row["MaLoai"]) : 0,
                    MaMau = row.Row.Table.Columns.Contains("MaMau") && row["MaMau"] != DBNull.Value ? Convert.ToInt64(row["MaMau"]) : 0,
                    MaThuongHieu = row.Row.Table.Columns.Contains("MaThuongHieu") && row["MaThuongHieu"] != DBNull.Value ? Convert.ToInt64(row["MaThuongHieu"]) : 0,
                    MaXX = row.Row.Table.Columns.Contains("MaXX") && row["MaXX"] != DBNull.Value ? Convert.ToInt64(row["MaXX"]) : 0,
                    DoiTuongSD = row.Row.Table.Columns.Contains("DoiTuongSD") ? row["DoiTuongSD"].ToString() : "",
                    Images = row.Row.Table.Columns.Contains("Images") ? row["Images"].ToString() : ""
                };
                using (suagiay formSua = new suagiay(selectedGiay))
                {
                    if (formSua.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            };



            // 3. Xóa giày
            btnXoaGiay.Click += (s, e) =>
            {
                if (dataGridView1.SelectedRows.Count == 0) return;
                long maGiay = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["MaGiay"].Value);

                if (MessageBox.Show("Xóa giày?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    giayBUS.XoaGiay(maGiay);
                    LoadData();
                }
            };

            // 4. Thêm ảnh
            btnThemAnh.Click += (s, e) =>
            {
                if (dataGridView1.SelectedRows.Count == 0) return;
                long maGiay = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["MaGiay"].Value);
                string tenGiay = dataGridView1.SelectedRows[0].Cells["TenGiay"].Value.ToString();

                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string folderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\Images"));
                        if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                        string fileExt = Path.GetExtension(ofd.FileName);
                        string safeTenGiay = string.Join("_", tenGiay.Split(Path.GetInvalidFileNameChars()));
                        string destFile = Path.Combine(folderPath, $"{maGiay}_{safeTenGiay}{fileExt}");
                        File.Copy(ofd.FileName, destFile, true);

                        giayBUS.CapNhatAnh(maGiay, Path.GetFileName(destFile));

                        using (var img = Image.FromFile(destFile))
                        {
                            dataGridView1.SelectedRows[0].Cells["HinhAnh"].Value = new Bitmap(img);
                        }
                        MessageBox.Show("Thêm ảnh thành công!");
                    }
                }
            };
        }

        private readonly PhieuNhapBUS phieuNhapBUS = new PhieuNhapBUS();

        private void ShowPhieuNhap()
        {
            panel1.Controls.Clear();

            Label lbl = new Label
            {
                Text = "📦 DANH SÁCH PHIẾU NHẬP",
                Dock = DockStyle.Top,
                Height = 50,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            panel1.Controls.Add(dgv);
            panel1.Controls.Add(lbl);

            try
            {
                List<PhieuNhapDTO> ds = phieuNhapBUS.LayDanhSachPhieuNhap();

                // Chuyển danh sách sang dạng bảng để hiển thị
                dgv.DataSource = ds.Select(p => new
                {
                    Mã_Phiếu_Nhập = p.MaPN,
                    Mã_NCC = p.MaNCC,
                    Mã_NV = p.MaNV,
                    Ngày_Nhập = p.NgayNhap.ToString("dd/MM/yyyy"),
                    Tổng_Tiền = p.TongTien.ToString("N0")
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải Phiếu Nhập: " + ex.Message);
            }
        }
        private ChiTietPhieuNhapBUS chiTietPhieuNhapBUS = new ChiTietPhieuNhapBUS();

        private void ShowChiTietPhieuNhap()
        {
            panel1.Controls.Clear();

            Label lbl = new Label
            {
                Text = "📋 CHI TIẾT PHIẾU NHẬP HÀNG",
                Dock = DockStyle.Top,
                Height = 50,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            panel1.Controls.Add(dgv);
            panel1.Controls.Add(lbl);

            try
            {
                List<ChiTietPhieuNhapDTO> ds = chiTietPhieuNhapBUS.LayDanhSachChiTietPhieuNhap();

                dgv.DataSource = ds.Select(ct => new
                {
                    Mã_Phiếu_Nhập = ct.MaPN,
                    Mã_Giày = ct.MaGiay,
                    Tên_Giày = ct.TenGiay,
                    Số_Lượng = ct.SoLuong,
                    Giá_Nhập = ct.GiaNhap.ToString("N0"),
                    Thành_Tiền = ct.ThanhTien.ToString("N0")
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải Chi Tiết Phiếu Nhập: " + ex.Message);
            }
        }


        private void LoadLoaiToComboBox()
        {
            try
            {
                List<LoaiDTO> dsLoai = loaiBUS.LayDanhSachLoai();

                cboMaLoai.DataSource = dsLoai;
                cboMaLoai.DisplayMember = "TenLoai";
                cboMaLoai.ValueMember = "MaLoai";
                cboMaLoai.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại: " + ex.Message);
            }
        }
        private void CboMaLoai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMaLoai.SelectedValue != null)
            {
                string maloai = cboMaLoai.SelectedValue.ToString();
                cboMaLoai.Visible = false;
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            ShowPhieuNhap();
        }

        private void btnKiemKeKho_Click(object sender, EventArgs e)
        {
            ShowChiTietPhieuNhap();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                GiayDTO giay = new GiayDTO
                {
                    TenGiay = tenGiayInput,
                    SoLuong = int.Parse(soLuongInput),
                    DonGia = decimal.Parse(donGiaInput),
                    Size = int.Parse(sizeInput),
                    DoiTuongSD = doiTuongInput,
                    ChatLieu = chatLieuInput,
                    MaLoai = long.Parse(cboMaLoai.SelectedValue.ToString())
                };

                GiayBUS bus = new GiayBUS();
                bus.ThemGiay(giay);

                MessageBox.Show(" Thêm giày thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Lỗi: " + ex.Message);
            }
        }


        private void cboMaLoai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMaLoai.SelectedValue != null)
            {
                string maloai = cboMaLoai.SelectedValue.ToString();
                cboMaLoai.Visible = false;
            }
        }
        private void uiNavMenu1_MenuItemClick_1(TreeNode node, NavMenuItem item, int pageIndex)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            frm.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ShowNhapHangView()
        {
            panel1.Controls.Clear();
            DataGridView dgvNhapHang = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true
            };
            dataGridView1 = dgvNhapHang;
            panel1.Controls.Add(dgvNhapHang);
            LoadData();
            ThemNutQuanLyGiay();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QLYKho_Load_1(object sender, EventArgs e)
        {
            
        }

    }
}


