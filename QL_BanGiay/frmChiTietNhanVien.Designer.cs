using System.Windows.Forms;

namespace QL_BanGiay
{
    partial class frmChiTietNhanVien
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
                //this.Padding = new Padding(0);
                //this.Margin = new Padding(0);
                //this.AutoScaleMode = AutoScaleMode.None;
                //this.FormBorderStyle = FormBorderStyle.None;

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
            Sunny.UI.UIImageButton btnT;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietNhanVien));
            this.pnHienThi = new Sunny.UI.UIPanel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.txtSDT = new Krypton.Toolkit.KryptonTextBox();
            this.txtEmail = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            this.pkDT = new Krypton.Toolkit.KryptonDateTimePicker();
            this.rdNu = new Krypton.Toolkit.KryptonRadioButton();
            this.rdNam = new Krypton.Toolkit.KryptonRadioButton();
            this.cboVaiTro = new Krypton.Toolkit.KryptonComboBox();
            this.btnDong = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.txtTenNV = new Krypton.Toolkit.KryptonTextBox();
            this.txtMNV = new Krypton.Toolkit.KryptonTextBox();
            this.txtDC = new Krypton.Toolkit.KryptonTextBox();
            this.txtNQ = new Krypton.Toolkit.KryptonTextBox();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.btnImages = new Krypton.Toolkit.KryptonButton();
            this.uiBarChart1 = new Sunny.UI.UIBarChart();
            this.uiPieChart1 = new Sunny.UI.UIPieChart();
            btnT = new Sunny.UI.UIImageButton();
            this.pnHienThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(btnT)).BeginInit();
            this.uiPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVaiTro)).BeginInit();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHienThi
            // 
            this.pnHienThi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnHienThi.BackColor = System.Drawing.Color.White;
            this.pnHienThi.Controls.Add(this.uiPieChart1);
            this.pnHienThi.Controls.Add(this.uiBarChart1);
            this.pnHienThi.Controls.Add(this.uiPanel3);
            this.pnHienThi.Controls.Add(this.uiPanel2);
            this.pnHienThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pnHienThi.Location = new System.Drawing.Point(0, 4);
            this.pnHienThi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnHienThi.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnHienThi.Name = "pnHienThi";
            this.pnHienThi.RectColor = System.Drawing.Color.White;
            this.pnHienThi.Size = new System.Drawing.Size(1055, 491);
            this.pnHienThi.TabIndex = 0;
            this.pnHienThi.Text = " ";
            this.pnHienThi.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnHienThi.Click += new System.EventHandler(this.pnHienThi_Click);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(22, 117);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(102, 24);
            this.kryptonLabel5.TabIndex = 13;
            this.kryptonLabel5.Values.Text = "Số điện thoại";
            // 
            // btnT
            // 
            btnT.Cursor = System.Windows.Forms.Cursors.Hand;
            btnT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            btnT.Image = ((System.Drawing.Image)(resources.GetObject("btnT.Image")));
            btnT.Location = new System.Drawing.Point(3, 13);
            btnT.Name = "btnT";
            btnT.Size = new System.Drawing.Size(30, 28);
            btnT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            btnT.TabIndex = 8;
            btnT.TabStop = false;
            btnT.Text = " ";
            // 
            // uiPanel3
            // 
            this.uiPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel3.Controls.Add(this.txtSDT);
            this.uiPanel3.Controls.Add(this.txtEmail);
            this.uiPanel3.Controls.Add(this.kryptonLabel6);
            this.uiPanel3.Controls.Add(this.kryptonLabel9);
            this.uiPanel3.Controls.Add(this.kryptonLabel5);
            this.uiPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiPanel3.Location = new System.Drawing.Point(608, 276);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.RectColor = System.Drawing.Color.White;
            this.uiPanel3.Size = new System.Drawing.Size(225, 210);
            this.uiPanel3.TabIndex = 6;
            this.uiPanel3.Text = " ";
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(22, 145);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(178, 33);
            this.txtSDT.StateCommon.Border.Rounding = 10F;
            this.txtSDT.TabIndex = 21;
            this.txtSDT.Text = " ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(22, 78);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(178, 33);
            this.txtEmail.StateCommon.Border.Rounding = 10F;
            this.txtEmail.TabIndex = 20;
            this.txtEmail.Text = " ";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(22, 48);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(48, 24);
            this.kryptonLabel6.TabIndex = 14;
            this.kryptonLabel6.Values.Text = "Email";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(81, 17);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(60, 24);
            this.kryptonLabel9.TabIndex = 0;
            this.kryptonLabel9.Values.Text = "Liên hệ";
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(39, 256);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(80, 24);
            this.kryptonLabel10.TabIndex = 23;
            this.kryptonLabel10.Values.Text = "Ngày sinh";
            // 
            // pkDT
            // 
            this.pkDT.Location = new System.Drawing.Point(39, 286);
            this.pkDT.Name = "pkDT";
            this.pkDT.Size = new System.Drawing.Size(198, 25);
            this.pkDT.TabIndex = 22;
            // 
            // rdNu
            // 
            this.rdNu.Location = new System.Drawing.Point(124, 212);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(47, 24);
            this.rdNu.TabIndex = 21;
            this.rdNu.Values.Text = "Nữ";
            // 
            // rdNam
            // 
            this.rdNam.Checked = true;
            this.rdNam.Location = new System.Drawing.Point(39, 212);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(63, 24);
            this.rdNam.TabIndex = 20;
            this.rdNam.Values.Text = " Nam";
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVaiTro.DropDownWidth = 198;
            this.cboVaiTro.Location = new System.Drawing.Point(365, 77);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(198, 26);
            this.cboVaiTro.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cboVaiTro.TabIndex = 19;
            this.cboVaiTro.Text = " ";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDong.Location = new System.Drawing.Point(305, 411);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(107, 35);
            this.btnDong.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnDong.StateCommon.Border.Rounding = 5F;
            this.btnDong.TabIndex = 18;
            this.btnDong.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnDong.Values.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click_1);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.kryptonButton2.Location = new System.Drawing.Point(143, 411);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(106, 35);
            this.kryptonButton2.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.kryptonButton2.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.kryptonButton2.StateCommon.Border.Rounding = 5F;
            this.kryptonButton2.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton2.TabIndex = 17;
            this.kryptonButton2.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton2.Values.Text = "Lưu";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.kryptonLabel8.Location = new System.Drawing.Point(202, 13);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(178, 28);
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.kryptonLabel8.TabIndex = 16;
            this.kryptonLabel8.Values.Text = "Chi tiết nhân viên";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(39, 121);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(104, 24);
            this.kryptonLabel7.TabIndex = 15;
            this.kryptonLabel7.Values.Text = "Mã nhân viên";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel3.Location = new System.Drawing.Point(365, 47);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(101, 24);
            this.kryptonLabel3.TabIndex = 11;
            this.kryptonLabel3.Values.Text = "Nhóm quyền";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(39, 334);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(58, 24);
            this.kryptonLabel4.TabIndex = 12;
            this.kryptonLabel4.Values.Text = "Địa chỉ";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.Location = new System.Drawing.Point(365, 121);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(109, 24);
            this.kryptonLabel2.TabIndex = 10;
            this.kryptonLabel2.Values.Text = "kryptonLabel2";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(39, 47);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(111, 24);
            this.kryptonLabel1.TabIndex = 9;
            this.kryptonLabel1.Values.Text = " Tên nhân viên";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(39, 77);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(198, 33);
            this.txtTenNV.StateCommon.Border.Rounding = 10F;
            this.txtTenNV.TabIndex = 8;
            this.txtTenNV.Text = " ";
            // 
            // txtMNV
            // 
            this.txtMNV.Location = new System.Drawing.Point(39, 151);
            this.txtMNV.Name = "txtMNV";
            this.txtMNV.Size = new System.Drawing.Size(198, 33);
            this.txtMNV.StateCommon.Border.Rounding = 10F;
            this.txtMNV.TabIndex = 7;
            this.txtMNV.Text = " ";
            // 
            // txtDC
            // 
            this.txtDC.Location = new System.Drawing.Point(39, 364);
            this.txtDC.Name = "txtDC";
            this.txtDC.Size = new System.Drawing.Size(198, 33);
            this.txtDC.StateCommon.Border.Rounding = 10F;
            this.txtDC.TabIndex = 4;
            this.txtDC.Text = " ";
            // 
            // txtNQ
            // 
            this.txtNQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNQ.Location = new System.Drawing.Point(365, 151);
            this.txtNQ.Name = "txtNQ";
            this.txtNQ.Size = new System.Drawing.Size(198, 33);
            this.txtNQ.StateCommon.Border.Rounding = 10F;
            this.txtNQ.TabIndex = 2;
            this.txtNQ.Text = " ";
            // 
            // uiPanel2
            // 
            this.uiPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uiPanel2.Controls.Add(btnT);
            this.uiPanel2.Controls.Add(this.kryptonLabel10);
            this.uiPanel2.Controls.Add(this.pkDT);
            this.uiPanel2.Controls.Add(this.rdNu);
            this.uiPanel2.Controls.Add(this.rdNam);
            this.uiPanel2.Controls.Add(this.cboVaiTro);
            this.uiPanel2.Controls.Add(this.btnDong);
            this.uiPanel2.Controls.Add(this.kryptonButton2);
            this.uiPanel2.Controls.Add(this.kryptonLabel8);
            this.uiPanel2.Controls.Add(this.kryptonLabel7);
            this.uiPanel2.Controls.Add(this.kryptonLabel4);
            this.uiPanel2.Controls.Add(this.kryptonLabel3);
            this.uiPanel2.Controls.Add(this.kryptonLabel2);
            this.uiPanel2.Controls.Add(this.kryptonLabel1);
            this.uiPanel2.Controls.Add(this.txtTenNV);
            this.uiPanel2.Controls.Add(this.txtMNV);
            this.uiPanel2.Controls.Add(this.txtDC);
            this.uiPanel2.Controls.Add(this.txtNQ);
            this.uiPanel2.Controls.Add(this.btnImages);
            this.uiPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiPanel2.Location = new System.Drawing.Point(7, 5);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.RectColor = System.Drawing.Color.White;
            this.uiPanel2.Size = new System.Drawing.Size(593, 472);
            this.uiPanel2.TabIndex = 4;
            this.uiPanel2.Text = " ";
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImages
            // 
            this.btnImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImages.Location = new System.Drawing.Point(378, 198);
            this.btnImages.Name = "btnImages";
            this.btnImages.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnImages.Size = new System.Drawing.Size(185, 199);
            this.btnImages.StateCommon.Border.Rounding = 5F;
            this.btnImages.TabIndex = 0;
            this.btnImages.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnImages.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnImages.Values.Image")));
            this.btnImages.Values.ImageTransparentColor = System.Drawing.Color.Silver;
            this.btnImages.Values.ShowSplitOption = true;
            this.btnImages.Values.Text = " ";
            // 
            // uiBarChart1
            // 
            this.uiBarChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBarChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiBarChart1.LegendFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiBarChart1.Location = new System.Drawing.Point(607, 18);
            this.uiBarChart1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBarChart1.Name = "uiBarChart1";
            this.uiBarChart1.RectColor = System.Drawing.Color.White;
            this.uiBarChart1.Size = new System.Drawing.Size(433, 250);
            this.uiBarChart1.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiBarChart1.TabIndex = 22;
            this.uiBarChart1.Text = "uiBarChart1";
            // 
            // uiPieChart1
            // 
            this.uiPieChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPieChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiPieChart1.LegendFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiPieChart1.Location = new System.Drawing.Point(840, 276);
            this.uiPieChart1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPieChart1.Name = "uiPieChart1";
            this.uiPieChart1.RectColor = System.Drawing.Color.White;
            this.uiPieChart1.Size = new System.Drawing.Size(200, 210);
            this.uiPieChart1.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiPieChart1.TabIndex = 23;
            this.uiPieChart1.Text = "uiPieChart1";
            // 
            // frmChiTietNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnHienThi);
            this.Name = "frmChiTietNhanVien";
            this.Size = new System.Drawing.Size(1055, 500);
            this.Load += new System.EventHandler(this.frmChiTietNhanVien_Load);
            this.pnHienThi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(btnT)).EndInit();
            this.uiPanel3.ResumeLayout(false);
            this.uiPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVaiTro)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.uiPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnHienThi;
        private Sunny.UI.UIBarChart uiBarChart1;
        private Sunny.UI.UIPanel uiPanel3;
        private Krypton.Toolkit.KryptonTextBox txtSDT;
        private Krypton.Toolkit.KryptonTextBox txtEmail;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Sunny.UI.UIPanel uiPanel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private Krypton.Toolkit.KryptonDateTimePicker pkDT;
        private Krypton.Toolkit.KryptonRadioButton rdNu;
        private Krypton.Toolkit.KryptonRadioButton rdNam;
        private Krypton.Toolkit.KryptonComboBox cboVaiTro;
        private Krypton.Toolkit.KryptonButton btnDong;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTextBox txtTenNV;
        private Krypton.Toolkit.KryptonTextBox txtMNV;
        private Krypton.Toolkit.KryptonTextBox txtDC;
        private Krypton.Toolkit.KryptonTextBox txtNQ;
        private Krypton.Toolkit.KryptonButton btnImages;
        private Sunny.UI.UIPieChart uiPieChart1;
    }
}