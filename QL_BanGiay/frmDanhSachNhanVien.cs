using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using Krypton.Toolkit;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class frmDanhSachNhanVien : UserControl
    {
        public frmDanhSachNhanVien()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();

        }
        private async void frmDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            
            this.Show();
            Application.DoEvents();

            cachedList = await Task.Run(() => nhanVienBUS.GetAll());
            LoadDanhSachNhanVien();

           
            LoadDanhSachPhanQuyen(cachedList);

            data_DSNV.EnableHeadersVisualStyles = false;
            data_DSNV.AllowUserToAddRows = false;

            data_DSNV.RowTemplate.Height = 50;
            data_DSNV.CellContentClick += data_DSNV_CellContentClick;



        }
        private string MaNV = "";
        private void data_DSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0 && data_DSNV.Columns[e.ColumnIndex].Name == "clmCheckBox")
            {
                data_DSNV.EndEdit();  

                bool isChecked = Convert.ToBoolean(data_DSNV.Rows[e.RowIndex].Cells["clmCheckBox"].Value);
                string maNV = data_DSNV.Rows[e.RowIndex].Cells["clmMaNV"].Value?.ToString();

                if (isChecked)
                {
                    MaNV = maNV;
                    MessageBox.Show($"Bạn vừa chọn nhân viên có mã: {maNV}");
                }
            }
        }


        //private void LoadTheNhanVien()
        //{
        //    tbThe.SuspendLayout();
        //    tbThe.Controls.Clear();

        //    var list = nhanVienBUS.GetAll();
        //    int columns = tbThe.ColumnCount;
        //    int rows = (int)Math.Ceiling((double)list.Count / columns);

        //    tbThe.RowCount = rows;
        //    tbThe.RowStyles.Clear();
        //    for (int i = 0; i < rows; i++)
        //        tbThe.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        int r = i / columns;
        //        int c = i % columns;

        //        var card = new frmTheNhanVien();
        //        card.Dock = DockStyle.Fill;
        //        card.Margin = new Padding(25);
        //        card.SetData(list[i]);


        //        int index = i;


        //        card.Click += (s, e) =>
        //        {
        //            MessageBox.Show($"Bạn đã click vào thẻ số {index + 1}\nMã NV: {list[index].MaTK}",
        //                            "Thông báo",
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Information);
        //        };


        //        foreach (Control ctrl in card.Controls)
        //        {
        //            ctrl.Click += (s, e) => card_Click(card, e);

        //        }

        //        tbThe.Controls.Add(card, c, r);
        //    }

        //    tbThe.ResumeLayout();
        //}

        private NhanVienDTO nvDangChon = null; // Nhân viên được chọn

        private void LoadTheNhanVien()
        {
            tbThe.SuspendLayout();
            tbThe.Controls.Clear();

            var list = nhanVienBUS.GetAll();
            int columns = tbThe.ColumnCount;
            int rows = (int)Math.Ceiling((double)list.Count / columns);

            tbThe.RowCount = rows;
            tbThe.RowStyles.Clear();
            for (int i = 0; i < rows; i++)
                tbThe.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            for (int i = 0; i < list.Count; i++)
            {
                int index = i;  
                var card = new frmTheNhanVien();
                card.Dock = DockStyle.Fill;
                card.Margin = new Padding(25);
                card.SetData(list[i]);

               
                card.Click += (s, e) =>
                {
                    nvDangChon = list[index];
                    MessageBox.Show($"Đã chọn nhân viên: {nvDangChon.HoTen}");
                    btnInThe.Enabled = true;
                };
                 
                foreach (Control ctrl in card.Controls)
                {
                    ctrl.Click += (s, e) =>
                    {
                        nvDangChon = list[index];
                        MessageBox.Show($"Đã chọn nhân viên: {nvDangChon.HoTen}");
                        btnInThe.Enabled = true;
                    };
                }

                tbThe.Controls.Add(card, i % tbThe.ColumnCount, i / tbThe.ColumnCount);
            }


            tbThe.ResumeLayout();
        }


        private void card_Click(frmTheNhanVien card, EventArgs e)
        {
            card.Focus();
            card.PerformLayout();  

          
            MessageBox.Show("Bạn đã click vào thẻ của nhân viên: " );
        }


        

        private async void uiTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tab hiện tại
            var tabName = uiTabControl1.SelectedTab.Text;

            if (tabName.Contains("Phân quyền") && !phanQuyenLoaded)
            {

                LoadDanhSachPhanQuyen(cachedList);
                phanQuyenLoaded = true;
            }
            else if (tabName.Contains("Nhóm quyền") && !nhomQuyenLoaded)
            {
                //// Load khi người dùng mở tab Nhóm quyền
                //Loa(cachedList);
                //nhomQuyenLoaded = true;
            }
            else if (tabName.Contains("thẻ nhân") && !theNhanVienLoaded)
            {
                // Load khi mở tab thẻ nhân viên
                LoadTheNhanVien();
                theNhanVienLoaded = true;
            }
        }

        private readonly NhanVienBUS nhanVienBUS = new NhanVienBUS();



        public void LoadDanhSachNhanVien()
        {
            data_DSNV.Rows.Clear();
            data_DSNV.Controls.Clear();

            data_DSNV.AllowUserToAddRows = false;
            data_DSNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_DSNV.RowTemplate.Height = 65;
            data_DSNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            data_DSNV.MultiSelect = false;
            data_DSNV.RowHeadersVisible = false;
            data_DSNV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data_DSNV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data_DSNV.EditMode = DataGridViewEditMode.EditOnEnter;
            data_DSNV.ReadOnly = false;
            if (data_DSNV.Columns.Count == 0)
            {
                // Cột STT
                data_DSNV.Columns.Add("clmSTT", "STT");

                // Cột Checkbox
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "clmCheckBox";
                chk.HeaderText = "Chọn";
                chk.Width = 50;
                chk.ReadOnly = false;
                chk.TrueValue = true;
                chk.FalseValue = false;
                chk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                chk.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                data_DSNV.Columns.Add(chk);
                 

                
                data_DSNV.Columns.Add("clmMaNV", "Mã NV");
                data_DSNV.Columns.Add("clmTen", "Họ tên");
                data_DSNV.Columns.Add("clmDT", "Điện thoại");
                data_DSNV.Columns.Add("clmRole", "Chức vụ");

                data_DSNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data_DSNV.AllowUserToAddRows = false;
                data_DSNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

            data_DSNV.Columns["clmSTT"].Width = 50;
            data_DSNV.Columns["clmCheckBox"].Width = 50;
            data_DSNV.Columns["clmTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            data_DSNV.Columns["clmDT"].Width = 150;
            data_DSNV.Columns["clmRole"].Width = 150;
            data_DSNV.Columns["clmSTT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data_DSNV.Columns["clmMaNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data_DSNV.Columns["clmDT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data_DSNV.Columns["clmRole"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data_DSNV.Columns["clmTen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            data_DSNV.Columns["clmTen"].HeaderCell.Style.Padding = new Padding(10, 0, 0, 0);
            data_DSNV.Columns["clmTen"].HeaderCell.Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            data_DSNV.Columns["clmDT"].HeaderCell.Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            data_DSNV.Columns["clmRole"].HeaderCell.Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

 
            data_DSNV.ColumnHeadersHeight = 40;
            data_DSNV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            data_DSNV.GridColor = Color.LightGray;
            data_DSNV.BackgroundColor = Color.White;
            data_DSNV.BorderStyle = BorderStyle.None;
            data_DSNV.EnableHeadersVisualStyles = false;
            data_DSNV.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 255);
            data_DSNV.DefaultCellStyle.SelectionForeColor = Color.Black;
            data_DSNV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);

            int stt = 1;
            foreach (var nv in cachedList)
            {
                int rowIndex = data_DSNV.Rows.Add();
                DataGridViewRow row = data_DSNV.Rows[rowIndex];
                row.Cells["clmSTT"].Value = stt++;
                row.Cells["clmCheckBox"].Value = false;
                row.Cells["clmMaNV"].Value = nv.MaTK;
                row.Cells["clmTen"].Value = nv.HoTen;
                row.Cells["clmDT"].Value = nv.DienThoai;
                row.Cells["clmRole"].Value = nv.Role;
                row.Tag = nv;
            }
        }

 
     
        private void SuaNhanVien(NhanVienDTO emp)
        {
            var frm = new frmThemNhanVien(emp);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (nhanVienBUS.Update(emp))
                {
                    MessageBox.Show("✅ Cập nhật nhân viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("❌ Cập nhật thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void XoaNhanVien(NhanVienDTO emp)
        {
            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhân viên {emp.HoTen} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                if (nhanVienBUS.Delete(emp.MaTK))
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show(" Xóa thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }







        private void kryptonLabel1_Click(object sender, EventArgs e)
        {

        }


        private List<NhanVienDTO> cachedList;
        private bool dsNhanVienLoaded = false;
        private bool phanQuyenLoaded = false;
        private bool nhomQuyenLoaded = false;
        private bool theNhanVienLoaded = false;


       
        

         
        private void LoadDanhSachPhanQuyen(IEnumerable<NhanVienDTO> list)
        {
            try
            {
                data_PQNV.Rows.Clear();
                data_PQNV.Controls.Clear();

                int stt = 1;
                string[] roles = { "Admin", "BanHang", "ThuKho", "KeToan", "BaoHanh" };

                foreach (var nv in list)
                {
                    int rowIndex = data_PQNV.Rows.Add();
                    DataGridViewRow row = data_PQNV.Rows[rowIndex];

                    row.Cells["clmSoThuTu"].Value = stt++;
                    row.Cells["clmTenNhanVien"].Value = nv.HoTen;
                    row.Tag = nv;
                    row.Height = 55;
                }

                data_PQNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data_PQNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                data_PQNV.RowTemplate.Height = 50;

                // ⚡ Gắn control trong CellPainting (ổn định khi cuộn)
                data_PQNV.CellPainting += (s, e) =>
                {
                    if (e.RowIndex < 0) return;
                    var nv = data_PQNV.Rows[e.RowIndex].Tag as NhanVienDTO;
                    if (nv == null) return;

                    // ====== Radio phân quyền ======
                    foreach (string role in roles)
                    {
                        string colName = "clm" + role;
                        if (e.ColumnIndex == data_PQNV.Columns[colName].Index)
                        {
                            Rectangle rect = data_PQNV.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                            string radioKey = $"radio_{role}_{e.RowIndex}";
                            if (!data_PQNV.Controls.ContainsKey(radioKey))
                            {
                                UIRadioButton r = new UIRadioButton
                                {
                                    Name = radioKey,
                                    Width = 22,
                                    Height = 22,
                                    Location = new Point(
                                        rect.X + (rect.Width - 22) / 2,
                                        rect.Y + (rect.Height - 22) / 2
                                    ),
                                    Checked = nv.Role == role,
                                    Tag = new { NhanVien = nv, Quyen = role },
                                    Style = UIStyle.Custom
                                };

                                // Khi click chọn quyền
                                r.CheckedChanged += (sender, ev) =>
                                {
                                    var radio = sender as UIRadioButton;
                                    if (radio.Checked)
                                    {
                                        dynamic tag = radio.Tag;
                                        var emp = tag.NhanVien as NhanVienDTO;
                                        string q = tag.Quyen;

                                        emp.Role = q;
                                        new NhanVienBUS().UpdateTrangThai(emp);

                                        // Bỏ chọn radio khác trong cùng hàng
                                        foreach (string otherRole in roles)
                                        {
                                            if (otherRole == q) continue;
                                            var other = data_PQNV.Controls[$"radio_{otherRole}_{e.RowIndex}"] as UIRadioButton;
                                            if (other != null) other.Checked = false;
                                        }
                                    }
                                };

                                data_PQNV.Controls.Add(r);
                            }
                        }
                    }

                    // ====== Switch trạng thái ======
                    if (e.ColumnIndex == data_PQNV.Columns["clmTrangThai"].Index)
                    {
                        Rectangle rect = data_PQNV.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        string swKey = $"switch_{e.RowIndex}";
                        if (!data_PQNV.Controls.ContainsKey(swKey))
                        {
                            UISwitch sw = new UISwitch
                            {
                                Name = swKey,
                                Size = new Size(50, 25),
                                Location = new Point(
                                    rect.X + (rect.Width - 50) / 2,
                                    rect.Y + (rect.Height - 25) / 2
                                ),
                                Active = nv.TrangThai,
                                ActiveColor = Color.MediumSeaGreen,
                                InActiveColor = Color.LightGray,
                                Style = UIStyle.Custom,
                                Tag = nv,
                                ActiveText = "",
                                InActiveText = ""
                            };

                            sw.ActiveChanged += (sender, ev) =>
                            {
                                var swh = sender as UISwitch;
                                var emp = swh?.Tag as NhanVienDTO;
                                if (emp != null)
                                {
                                    emp.TrangThai = swh.Active;
                                    new NhanVienBUS().UpdateTrangThai(emp);
                                }
                            };

                            data_PQNV.Controls.Add(sw);
                        }
                    }
                };

                // Khi cuộn hoặc resize
                data_PQNV.Scroll += (s, e) => data_PQNV.Invalidate();
                data_PQNV.Resize += (s, e) => data_PQNV.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phân quyền: " + ex.Message);
            }
        }


        private void tbpDSNV_Click(object sender, EventArgs e)
        {

        }

        
        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }

        private void pnHienThiChiTiet_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

        private void data_PQNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            frmThemNhanVien frm = new frmThemNhanVien(this);
            frm.Show();
                
        }

         

        private void tbThe_Paint(object sender, PaintEventArgs e)
        {
            
        }
 
        private void btnChiTiet_Click_1(object sender, EventArgs e)
        {
            if(MaNV==null) 
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pnHienThiChiTiet.Controls.Clear();
            var f = new frmChiTietNhanVien(long.Parse(MaNV));
            f.Dock = DockStyle.Fill;
            pnHienThiChiTiet.Controls.Add(f);
        }

        private void btnInThe_Click(object sender, EventArgs e)
        {
            if (nvDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần in thẻ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF file|*.pdf",
                FileName = $"TheNhanVien_{nvDangChon.MaTK}.pdf"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    InTheNV inTheNV = new InTheNV();
                    inTheNV.InTheNhanVienPDF(sfd.FileName, nvDangChon);
                    MessageBox.Show("Đã xuất thẻ nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


    }
}
