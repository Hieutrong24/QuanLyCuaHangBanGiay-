namespace QL_BanGiay
{
    partial class frmKeToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKeToan));
            this.tabKeToan = new Sunny.UI.UITabControlMenu();
            this.tpMH = new System.Windows.Forms.TabPage();
            this.tpBH = new System.Windows.Forms.TabPage();
            this.tpCTKM = new System.Windows.Forms.TabPage();
            this.tpADKM = new System.Windows.Forms.TabPage();
            this.tpTD = new System.Windows.Forms.TabPage();
            this.tpLuong = new System.Windows.Forms.TabPage();
            this.tpDX = new System.Windows.Forms.TabPage();
            this.uiNavBar1 = new Sunny.UI.UINavBar();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.txtSearch = new Sunny.UI.UITextBox();
            this.uiImageButton2 = new Sunny.UI.UIImageButton();
            this.uiImageButton1 = new Sunny.UI.UIImageButton();
            this.lblName = new Sunny.UI.UITextBox();
            this.uiAvatar1 = new Sunny.UI.UIAvatar();
            this.tabKeToan.SuspendLayout();
            this.uiNavBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabKeToan
            // 
            this.tabKeToan.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabKeToan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabKeToan.Controls.Add(this.tpMH);
            this.tabKeToan.Controls.Add(this.tpBH);
            this.tabKeToan.Controls.Add(this.tpCTKM);
            this.tabKeToan.Controls.Add(this.tpADKM);
            this.tabKeToan.Controls.Add(this.tpTD);
            this.tabKeToan.Controls.Add(this.tpLuong);
            this.tabKeToan.Controls.Add(this.tpDX);
            this.tabKeToan.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabKeToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tabKeToan.ItemSize = new System.Drawing.Size(240, 40);
            this.tabKeToan.Location = new System.Drawing.Point(0, 70);
            this.tabKeToan.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.tabKeToan.Multiline = true;
            this.tabKeToan.Name = "tabKeToan";
            this.tabKeToan.SelectedIndex = 0;
            this.tabKeToan.Size = new System.Drawing.Size(1076, 628);
            this.tabKeToan.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabKeToan.TabBackColor = System.Drawing.Color.DarkSlateBlue;
            this.tabKeToan.TabIndex = 0;
            this.tabKeToan.TabSelectedColor = System.Drawing.Color.White;
            this.tabKeToan.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabKeToan.TabSelectedHighColor = System.Drawing.Color.Silver;
            this.tabKeToan.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tabKeToan.SelectedIndexChanged += new System.EventHandler(this.tabKeToan_SelectedIndexChanged);
            // 
            // tpMH
            // 
            this.tpMH.Location = new System.Drawing.Point(241, 0);
            this.tpMH.Name = "tpMH";
            this.tpMH.Size = new System.Drawing.Size(835, 628);
            this.tpMH.TabIndex = 5;
            this.tpMH.Text = "Mua hàng";
            this.tpMH.UseVisualStyleBackColor = true;
            // 
            // tpBH
            // 
            this.tpBH.Location = new System.Drawing.Point(241, 0);
            this.tpBH.Name = "tpBH";
            this.tpBH.Size = new System.Drawing.Size(835, 628);
            this.tpBH.TabIndex = 6;
            this.tpBH.Text = "Bán Hàng";
            this.tpBH.UseVisualStyleBackColor = true;
            // 
            // tpCTKM
            // 
            this.tpCTKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tpCTKM.Location = new System.Drawing.Point(241, 0);
            this.tpCTKM.Name = "tpCTKM";
            this.tpCTKM.Size = new System.Drawing.Size(835, 628);
            this.tpCTKM.TabIndex = 0;
            this.tpCTKM.Text = "Chương trình KM";
            // 
            // tpADKM
            // 
            this.tpADKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tpADKM.Location = new System.Drawing.Point(241, 0);
            this.tpADKM.Name = "tpADKM";
            this.tpADKM.Size = new System.Drawing.Size(835, 628);
            this.tpADKM.TabIndex = 1;
            this.tpADKM.Text = "Áp dụng KM";
            // 
            // tpTD
            // 
            this.tpTD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tpTD.Location = new System.Drawing.Point(241, 0);
            this.tpTD.Name = "tpTD";
            this.tpTD.Size = new System.Drawing.Size(835, 628);
            this.tpTD.TabIndex = 3;
            this.tpTD.Text = "Tổng Hợp";
            // 
            // tpLuong
            // 
            this.tpLuong.Location = new System.Drawing.Point(241, 0);
            this.tpLuong.Name = "tpLuong";
            this.tpLuong.Size = new System.Drawing.Size(835, 628);
            this.tpLuong.TabIndex = 8;
            this.tpLuong.Text = "Lương";
            this.tpLuong.UseVisualStyleBackColor = true;
            // 
            // tpDX
            // 
            this.tpDX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tpDX.Location = new System.Drawing.Point(241, 0);
            this.tpDX.Name = "tpDX";
            this.tpDX.Size = new System.Drawing.Size(835, 628);
            this.tpDX.TabIndex = 4;
            this.tpDX.Text = "Đăng xuất";
            // 
            // uiNavBar1
            // 
            this.uiNavBar1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.uiNavBar1.Controls.Add(this.uiButton1);
            this.uiNavBar1.Controls.Add(this.txtSearch);
            this.uiNavBar1.Controls.Add(this.uiImageButton2);
            this.uiNavBar1.Controls.Add(this.uiImageButton1);
            this.uiNavBar1.Controls.Add(this.lblName);
            this.uiNavBar1.Controls.Add(this.uiAvatar1);
            this.uiNavBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiNavBar1.DropMenuFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiNavBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiNavBar1.Location = new System.Drawing.Point(0, 0);
            this.uiNavBar1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiNavBar1.Name = "uiNavBar1";
            this.uiNavBar1.Size = new System.Drawing.Size(1073, 64);
            this.uiNavBar1.TabIndex = 1;
            this.uiNavBar1.Text = "uiNavBar1";
            // 
            // uiButton1
            // 
            this.uiButton1.BackColor = System.Drawing.Color.Transparent;
            this.uiButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiButton1.BackgroundImage")));
            this.uiButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.Transparent;
            this.uiButton1.FillColor2 = System.Drawing.Color.Transparent;
            this.uiButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiButton1.Location = new System.Drawing.Point(789, 13);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(44, 35);
            this.uiButton1.TabIndex = 31;
            this.uiButton1.Text = " ";
            this.uiButton1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSearch.Location = new System.Drawing.Point(330, 13);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(5);
            this.txtSearch.ShowText = false;
            this.txtSearch.Size = new System.Drawing.Size(451, 34);
            this.txtSearch.TabIndex = 30;
            this.txtSearch.Text = " ";
            this.txtSearch.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSearch.Watermark = "";
            // 
            // uiImageButton2
            // 
            this.uiImageButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.uiImageButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiImageButton2.BackgroundImage")));
            this.uiImageButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.uiImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiImageButton2.Location = new System.Drawing.Point(926, 5);
            this.uiImageButton2.Name = "uiImageButton2";
            this.uiImageButton2.Size = new System.Drawing.Size(50, 40);
            this.uiImageButton2.TabIndex = 29;
            this.uiImageButton2.TabStop = false;
            this.uiImageButton2.Text = " ";
            // 
            // uiImageButton1
            // 
            this.uiImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.uiImageButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiImageButton1.BackgroundImage")));
            this.uiImageButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.uiImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiImageButton1.Location = new System.Drawing.Point(982, 5);
            this.uiImageButton1.Name = "uiImageButton1";
            this.uiImageButton1.Size = new System.Drawing.Size(60, 42);
            this.uiImageButton1.TabIndex = 28;
            this.uiImageButton1.TabStop = false;
            this.uiImageButton1.Text = " ";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.ButtonForeColor = System.Drawing.Color.Transparent;
            this.lblName.ButtonForeHoverColor = System.Drawing.Color.Transparent;
            this.lblName.ButtonForePressColor = System.Drawing.Color.Transparent;
            this.lblName.ButtonStyleInherited = false;
            this.lblName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblName.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.lblName.FillColor2 = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblName.Location = new System.Drawing.Point(69, 5);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblName.MinimumSize = new System.Drawing.Size(1, 16);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new System.Windows.Forms.Padding(5);
            this.lblName.RectColor = System.Drawing.Color.DarkSlateBlue;
            this.lblName.ShowText = false;
            this.lblName.Size = new System.Drawing.Size(112, 40);
            this.lblName.TabIndex = 3;
            this.lblName.Text = " ";
            this.lblName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Watermark = "";
            // 
            // uiAvatar1
            // 
            this.uiAvatar1.AvatarSize = 40;
            this.uiAvatar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.uiAvatar1.Location = new System.Drawing.Point(12, 0);
            this.uiAvatar1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiAvatar1.Name = "uiAvatar1";
            this.uiAvatar1.Size = new System.Drawing.Size(50, 50);
            this.uiAvatar1.TabIndex = 2;
            this.uiAvatar1.Text = "uiAvatar1";
            // 
            // frmKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 697);
            this.Controls.Add(this.uiNavBar1);
            this.Controls.Add(this.tabKeToan);
            this.Name = "frmKeToan";
            this.Text = "frmKeToan";
            this.Load += new System.EventHandler(this.frmKeToan_Load);
            this.tabKeToan.ResumeLayout(false);
            this.uiNavBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControlMenu tabKeToan;
        private System.Windows.Forms.TabPage tpCTKM;
        private System.Windows.Forms.TabPage tpADKM;
        private System.Windows.Forms.TabPage tpTD;
        private System.Windows.Forms.TabPage tpDX;
        private Sunny.UI.UINavBar uiNavBar1;
        private Sunny.UI.UITextBox lblName;
        private Sunny.UI.UIAvatar uiAvatar1;
        private Sunny.UI.UIImageButton uiImageButton1;
        private Sunny.UI.UIImageButton uiImageButton2;
        private Sunny.UI.UITextBox txtSearch;
        private Sunny.UI.UIButton uiButton1;
        private System.Windows.Forms.TabPage tpMH;
        private System.Windows.Forms.TabPage tpBH;
        private System.Windows.Forms.TabPage tpLuong;
    }
}