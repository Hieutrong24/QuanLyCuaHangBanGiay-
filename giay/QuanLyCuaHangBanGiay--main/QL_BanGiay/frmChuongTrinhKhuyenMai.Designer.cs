namespace QL_BanGiay
{
    partial class frmChuongTrinhKhuyenMai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.data_DSKM = new Sunny.UI.UIDataGridView();
            this.pkNBD = new Krypton.Toolkit.KryptonDateTimePicker();
            this.pkNKT = new Krypton.Toolkit.KryptonDateTimePicker();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.cboDKAD = new Sunny.UI.UIComboBox();
            this.txtTKM = new Sunny.UI.UITextBox();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.btnThem = new Krypton.Toolkit.KryptonButton();
            this.btnSua = new Krypton.Toolkit.KryptonButton();
            this.btnXoa = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.cboLCT = new Sunny.UI.UIComboBox();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.MucGiam = new Krypton.Toolkit.KryptonNumericUpDown();
            this.clmMaKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLoaiCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDieuKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNgayBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNgayKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMucGgiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.data_DSKM)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // data_DSKM
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.data_DSKM.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.data_DSKM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_DSKM.BackgroundColor = System.Drawing.Color.White;
            this.data_DSKM.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_DSKM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.data_DSKM.ColumnHeadersHeight = 32;
            this.data_DSKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.data_DSKM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaKM,
            this.clmTenKM,
            this.clmLoaiCT,
            this.clmDieuKien,
            this.clmNgayBD,
            this.clmNgayKT,
            this.clmMucGgiam,
            this.clmTrangThai});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_DSKM.DefaultCellStyle = dataGridViewCellStyle13;
            this.data_DSKM.EnableHeadersVisualStyles = false;
            this.data_DSKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.data_DSKM.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.data_DSKM.Location = new System.Drawing.Point(12, 133);
            this.data_DSKM.Name = "data_DSKM";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_DSKM.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.data_DSKM.RowHeadersWidth = 51;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.data_DSKM.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.data_DSKM.RowTemplate.Height = 24;
            this.data_DSKM.SelectedIndex = -1;
            this.data_DSKM.Size = new System.Drawing.Size(723, 380);
            this.data_DSKM.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.data_DSKM.TabIndex = 0;
            // 
            // pkNBD
            // 
            this.pkNBD.Location = new System.Drawing.Point(345, 30);
            this.pkNBD.Name = "pkNBD";
            this.pkNBD.Size = new System.Drawing.Size(135, 25);
            this.pkNBD.TabIndex = 1;
            // 
            // pkNKT
            // 
            this.pkNKT.Location = new System.Drawing.Point(345, 88);
            this.pkNKT.Name = "pkNKT";
            this.pkNKT.Size = new System.Drawing.Size(135, 25);
            this.pkNKT.TabIndex = 2;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.MucGiam);
            this.uiPanel1.Controls.Add(this.kryptonLabel6);
            this.uiPanel1.Controls.Add(this.cboLCT);
            this.uiPanel1.Controls.Add(this.kryptonLabel5);
            this.uiPanel1.Controls.Add(this.kryptonLabel4);
            this.uiPanel1.Controls.Add(this.kryptonLabel3);
            this.uiPanel1.Controls.Add(this.kryptonLabel2);
            this.uiPanel1.Controls.Add(this.kryptonLabel1);
            this.uiPanel1.Controls.Add(this.txtTKM);
            this.uiPanel1.Controls.Add(this.cboDKAD);
            this.uiPanel1.Controls.Add(this.pkNBD);
            this.uiPanel1.Controls.Add(this.pkNKT);
            this.uiPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiPanel1.Location = new System.Drawing.Point(12, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(494, 125);
            this.uiPanel1.TabIndex = 3;
            this.uiPanel1.Text = " ";
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboDKAD
            // 
            this.cboDKAD.DataSource = null;
            this.cboDKAD.FillColor = System.Drawing.Color.White;
            this.cboDKAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboDKAD.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cboDKAD.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cboDKAD.Location = new System.Drawing.Point(32, 88);
            this.cboDKAD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboDKAD.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboDKAD.Name = "cboDKAD";
            this.cboDKAD.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboDKAD.Size = new System.Drawing.Size(123, 26);
            this.cboDKAD.SymbolSize = 24;
            this.cboDKAD.TabIndex = 3;
            this.cboDKAD.Text = " ";
            this.cboDKAD.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cboDKAD.Watermark = "";
            // 
            // txtTKM
            // 
            this.txtTKM.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTKM.Location = new System.Drawing.Point(32, 30);
            this.txtTKM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTKM.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtTKM.Name = "txtTKM";
            this.txtTKM.Padding = new System.Windows.Forms.Padding(5);
            this.txtTKM.ShowText = false;
            this.txtTKM.Size = new System.Drawing.Size(123, 26);
            this.txtTKM.TabIndex = 4;
            this.txtTKM.Text = "  ";
            this.txtTKM.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTKM.Watermark = "";
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.btnXoa);
            this.uiPanel2.Controls.Add(this.btnSua);
            this.uiPanel2.Controls.Add(this.btnThem);
            this.uiPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiPanel2.Location = new System.Drawing.Point(514, 0);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(221, 125);
            this.uiPanel2.TabIndex = 4;
            this.uiPanel2.Text = " ";
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(40, 7);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(141, 33);
            this.btnThem.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThem.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThem.TabIndex = 0;
            this.btnThem.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnThem.Values.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(40, 46);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(141, 33);
            this.btnSua.StateCommon.Back.Color1 = System.Drawing.Color.Cyan;
            this.btnSua.StateCommon.Back.Color2 = System.Drawing.Color.Cyan;
            this.btnSua.TabIndex = 1;
            this.btnSua.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnSua.Values.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(40, 85);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(141, 33);
            this.btnXoa.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoa.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnXoa.Values.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(32, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(119, 24);
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Values.Text = "Tên khuyến mãi";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(32, 63);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(136, 24);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "Điều kiện áp dụng";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(345, 3);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(119, 24);
            this.kryptonLabel3.TabIndex = 7;
            this.kryptonLabel3.Values.Text = "Bắt đầu từ ngày";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(345, 63);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(134, 24);
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Kết thúc vào ngày";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(194, 63);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(132, 24);
            this.kryptonLabel5.TabIndex = 9;
            this.kryptonLabel5.Values.Text = "Loại chương trình";
            // 
            // cboLCT
            // 
            this.cboLCT.DataSource = null;
            this.cboLCT.FillColor = System.Drawing.Color.White;
            this.cboLCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboLCT.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cboLCT.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cboLCT.Location = new System.Drawing.Point(194, 88);
            this.cboLCT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboLCT.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboLCT.Name = "cboLCT";
            this.cboLCT.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboLCT.Size = new System.Drawing.Size(123, 26);
            this.cboLCT.SymbolSize = 24;
            this.cboLCT.TabIndex = 10;
            this.cboLCT.Text = " ";
            this.cboLCT.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cboLCT.Watermark = "";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(194, 3);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(119, 24);
            this.kryptonLabel6.TabIndex = 11;
            this.kryptonLabel6.Values.Text = "Tên khuyến mãi";
            // 
            // MucGiam
            // 
            this.MucGiam.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MucGiam.Location = new System.Drawing.Point(194, 29);
            this.MucGiam.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.MucGiam.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MucGiam.Name = "MucGiam";
            this.MucGiam.Size = new System.Drawing.Size(123, 26);
            this.MucGiam.TabIndex = 12;
            this.MucGiam.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // clmMaKM
            // 
            this.clmMaKM.HeaderText = "Mã KM";
            this.clmMaKM.MinimumWidth = 6;
            this.clmMaKM.Name = "clmMaKM";
            this.clmMaKM.Width = 125;
            // 
            // clmTenKM
            // 
            this.clmTenKM.HeaderText = "Tên KM";
            this.clmTenKM.MinimumWidth = 6;
            this.clmTenKM.Name = "clmTenKM";
            this.clmTenKM.Width = 125;
            // 
            // clmLoaiCT
            // 
            this.clmLoaiCT.HeaderText = "Loại CT";
            this.clmLoaiCT.MinimumWidth = 6;
            this.clmLoaiCT.Name = "clmLoaiCT";
            this.clmLoaiCT.Width = 125;
            // 
            // clmDieuKien
            // 
            this.clmDieuKien.HeaderText = "Điều kiện";
            this.clmDieuKien.MinimumWidth = 6;
            this.clmDieuKien.Name = "clmDieuKien";
            this.clmDieuKien.Width = 125;
            // 
            // clmNgayBD
            // 
            this.clmNgayBD.HeaderText = "Ngày BD";
            this.clmNgayBD.MinimumWidth = 6;
            this.clmNgayBD.Name = "clmNgayBD";
            this.clmNgayBD.Width = 125;
            // 
            // clmNgayKT
            // 
            this.clmNgayKT.HeaderText = "Ngày KT";
            this.clmNgayKT.MinimumWidth = 6;
            this.clmNgayKT.Name = "clmNgayKT";
            this.clmNgayKT.Width = 125;
            // 
            // clmMucGgiam
            // 
            this.clmMucGgiam.HeaderText = "Mức giảm";
            this.clmMucGgiam.MinimumWidth = 6;
            this.clmMucGgiam.Name = "clmMucGgiam";
            this.clmMucGgiam.Width = 125;
            // 
            // clmTrangThai
            // 
            this.clmTrangThai.HeaderText = "Trạng thái";
            this.clmTrangThai.MinimumWidth = 6;
            this.clmTrangThai.Name = "clmTrangThai";
            this.clmTrangThai.Width = 125;
            // 
            // frmChuongTrinhKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 525);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.data_DSKM);
            this.Name = "frmChuongTrinhKhuyenMai";
            this.Text = "frmChuongTrinhKhuyenMai";
            this.Load += new System.EventHandler(this.frmChuongTrinhKhuyenMai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_DSKM)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1.PerformLayout();
            this.uiPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView data_DSKM;
        private Krypton.Toolkit.KryptonDateTimePicker pkNBD;
        private Krypton.Toolkit.KryptonDateTimePicker pkNKT;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITextBox txtTKM;
        private Sunny.UI.UIComboBox cboDKAD;
        private Sunny.UI.UIPanel uiPanel2;
        private Krypton.Toolkit.KryptonButton btnThem;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonButton btnXoa;
        private Krypton.Toolkit.KryptonButton btnSua;
        private Sunny.UI.UIComboBox cboLCT;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonNumericUpDown MucGiam;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLoaiCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDieuKien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNgayBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNgayKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMucGgiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTrangThai;
    }
}