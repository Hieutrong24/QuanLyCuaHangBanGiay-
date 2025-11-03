namespace QL_BanGiay
{
    partial class ucBaoCaoTonKho
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnTonKho = new Krypton.Toolkit.KryptonPanel();
            this.pnDTTN = new Krypton.Toolkit.KryptonPanel();
            this.pnDNH = new Krypton.Toolkit.KryptonPanel();
            this.pnSPHH = new Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnDTTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnDNH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnSPHH)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnTonKho, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnDTTN, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnDNH, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnSPHH, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(699, 338);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnTonKho
            // 
            this.pnTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTonKho.Location = new System.Drawing.Point(3, 3);
            this.pnTonKho.Name = "pnTonKho";
            this.pnTonKho.Size = new System.Drawing.Size(343, 163);
            this.pnTonKho.TabIndex = 0;
            this.pnTonKho.Paint += new System.Windows.Forms.PaintEventHandler(this.pnTonKho_Paint);
            // 
            // pnDTTN
            // 
            this.pnDTTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDTTN.Location = new System.Drawing.Point(352, 3);
            this.pnDTTN.Name = "pnDTTN";
            this.pnDTTN.Size = new System.Drawing.Size(344, 163);
            this.pnDTTN.TabIndex = 1;
            // 
            // pnDNH
            // 
            this.pnDNH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDNH.Location = new System.Drawing.Point(3, 172);
            this.pnDNH.Name = "pnDNH";
            this.pnDNH.Size = new System.Drawing.Size(343, 163);
            this.pnDNH.TabIndex = 2;
            // 
            // pnSPHH
            // 
            this.pnSPHH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSPHH.Location = new System.Drawing.Point(352, 172);
            this.pnSPHH.Name = "pnSPHH";
            this.pnSPHH.Size = new System.Drawing.Size(344, 163);
            this.pnSPHH.TabIndex = 3;
            // 
            // ucBaoCaoTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 338);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucBaoCaoTonKho";
            this.Load += new System.EventHandler(this.ucBaoCaoTonKho_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnDTTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnDNH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnSPHH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Krypton.Toolkit.KryptonPanel pnTonKho;
        private Krypton.Toolkit.KryptonPanel pnDTTN;
        private Krypton.Toolkit.KryptonPanel pnDNH;
        private Krypton.Toolkit.KryptonPanel pnSPHH;
    }
}
