namespace QL_BanGiay
{
    partial class ucHieuSuatNV
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.kryptonDataGridView1 = new Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pkDN = new Krypton.Toolkit.KryptonDateTimePicker();
            this.pkTN = new Krypton.Toolkit.KryptonDateTimePicker();
            this.cboTenNV = new Krypton.Toolkit.KryptonDropButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(190, 16);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(416, 175);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(190, 198);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.RowHeadersWidth = 51;
            this.kryptonDataGridView1.RowTemplate.Height = 24;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(416, 150);
            this.kryptonDataGridView1.TabIndex = 1;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pkDN);
            this.kryptonPanel1.Controls.Add(this.pkTN);
            this.kryptonPanel1.Controls.Add(this.cboTenNV);
            this.kryptonPanel1.Location = new System.Drawing.Point(4, 4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(180, 344);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // pkDN
            // 
            this.pkDN.Location = new System.Drawing.Point(-1, 110);
            this.pkDN.Name = "pkDN";
            this.pkDN.Size = new System.Drawing.Size(177, 25);
            this.pkDN.TabIndex = 2;
            this.pkDN.ValueChanged += new System.EventHandler(this.pkDN_ValueChanged);
            // 
            // pkTN
            // 
            this.pkTN.Location = new System.Drawing.Point(-1, 64);
            this.pkTN.Name = "pkTN";
            this.pkTN.Size = new System.Drawing.Size(178, 25);
            this.pkTN.TabIndex = 1;
            this.pkTN.ValueChanged += new System.EventHandler(this.pkTN_ValueChanged);
            // 
            // cboTenNV
            // 
            this.cboTenNV.Location = new System.Drawing.Point(0, 12);
            this.cboTenNV.Name = "cboTenNV";
            this.cboTenNV.Size = new System.Drawing.Size(180, 34);
            this.cboTenNV.TabIndex = 0;
            this.cboTenNV.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.cboTenNV.Values.Text = " ";
            this.cboTenNV.Click += new System.EventHandler(this.cboTenNV_Click);
            // 
            // ucHieuSuatNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 315);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "ucHieuSuatNV";
            this.Load += new System.EventHandler(this.ucHieuSuatNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonDateTimePicker pkDN;
        private Krypton.Toolkit.KryptonDateTimePicker pkTN;
        private Krypton.Toolkit.KryptonDropButton cboTenNV;
    }
}
