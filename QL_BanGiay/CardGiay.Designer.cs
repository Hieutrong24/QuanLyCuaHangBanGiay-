using Microsoft.Data.SqlClient;
using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Windows.Forms;
namespace QL_BanGiay
{
    partial class CardGiay : UserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardGiay));
            this.uiPanel6 = new Sunny.UI.UIPanel();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.txtGia = new Sunny.UI.UIButton();
            this.lbtonkho = new Sunny.UI.UILabel();
            this.pnAnh = new Sunny.UI.UIPanel();
            this.lbGia = new Sunny.UI.UILabel();
            this.lbgiam = new Krypton.Toolkit.KryptonLabel();
            this.lbTenGiay = new Sunny.UI.UILabel();
            this.uiPanel6.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.pnAnh.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel6
            // 
            this.uiPanel6.Controls.Add(this.uiPanel1);
            this.uiPanel6.Controls.Add(this.pnAnh);
            this.uiPanel6.FillColor = System.Drawing.Color.White;
            this.uiPanel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel6.Location = new System.Drawing.Point(0, 0);
            this.uiPanel6.Margin = new System.Windows.Forms.Padding(4);
            this.uiPanel6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel6.Name = "uiPanel6";
            this.uiPanel6.Radius = 20;
            this.uiPanel6.RectColor = System.Drawing.Color.Transparent;
            this.uiPanel6.Size = new System.Drawing.Size(344, 88);
            this.uiPanel6.TabIndex = 29;
            this.uiPanel6.Text = null;
            this.uiPanel6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.txtGia);
            this.uiPanel1.Controls.Add(this.lbtonkho);
            this.uiPanel1.Controls.Add(this.lbTenGiay);
            this.uiPanel1.FillColor = System.Drawing.Color.White;
            this.uiPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(160, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Radius = 1;
            this.uiPanel1.RectColor = System.Drawing.Color.White;
            this.uiPanel1.Size = new System.Drawing.Size(230, 157);
            this.uiPanel1.TabIndex = 32;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGia
            // 
            this.txtGia.BackColor = System.Drawing.Color.Transparent;
            this.txtGia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtGia.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(241)))), ((int)(((byte)(220)))));
            this.txtGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(161)))));
            this.txtGia.Location = new System.Drawing.Point(26, 90);
            this.txtGia.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtGia.Name = "txtGia";
            this.txtGia.Radius = 25;
            this.txtGia.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(241)))), ((int)(((byte)(220)))));
            this.txtGia.Size = new System.Drawing.Size(100, 35);
            this.txtGia.TabIndex = 30;
            this.txtGia.Text = "uiButton1";
            this.txtGia.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtGia.Click += new System.EventHandler(this.txtGia_Click_1);
            // 
            // lbtonkho
            // 
            this.lbtonkho.BackColor = System.Drawing.Color.Transparent;
            this.lbtonkho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbtonkho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lbtonkho.Location = new System.Drawing.Point(35, 62);
            this.lbtonkho.Name = "lbtonkho";
            this.lbtonkho.Size = new System.Drawing.Size(138, 25);
            this.lbtonkho.TabIndex = 31;
            this.lbtonkho.Text = " SL tồn: 1";
            // 
            // pnAnh
            // 
            this.pnAnh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnAnh.BackgroundImage")));
            this.pnAnh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnAnh.Controls.Add(this.lbGia);
            this.pnAnh.Controls.Add(this.lbgiam);
            this.pnAnh.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnAnh.Location = new System.Drawing.Point(0, 0);
            this.pnAnh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnAnh.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnAnh.Name = "pnAnh";
            this.pnAnh.RectColor = System.Drawing.Color.Transparent;
            this.pnAnh.Size = new System.Drawing.Size(152, 88);
            this.pnAnh.TabIndex = 29;
            this.pnAnh.Text = null;
            this.pnAnh.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbGia
            // 
            this.lbGia.BackColor = System.Drawing.Color.Red;
            this.lbGia.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbGia.ForeColor = System.Drawing.Color.White;
            this.lbGia.Location = new System.Drawing.Point(0, 59);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(152, 29);
            this.lbGia.TabIndex = 34;
            this.lbGia.Text = "2.500.000đ";
            // 
            // lbgiam
            // 
            this.lbgiam.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbgiam.LabelStyle = Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.lbgiam.Location = new System.Drawing.Point(0, 0);
            this.lbgiam.Name = "lbgiam";
            this.lbgiam.Size = new System.Drawing.Size(152, 20);
            this.lbgiam.TabIndex = 33;
            this.lbgiam.Values.Text = "- 20%";
            // 
            // lbTenGiay
            // 
            this.lbTenGiay.BackColor = System.Drawing.Color.Transparent;
            this.lbTenGiay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTenGiay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbTenGiay.Location = new System.Drawing.Point(7, 13);
            this.lbTenGiay.Name = "lbTenGiay";
            this.lbTenGiay.Size = new System.Drawing.Size(177, 49);
            this.lbTenGiay.TabIndex = 25;
            this.lbTenGiay.Text = "Giày Samba Decon";
            // 
            // CardGiay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiPanel6);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CardGiay";
            this.Size = new System.Drawing.Size(350, 97);
            this.Load += new System.EventHandler(this.CardGiay_Load);
            this.uiPanel6.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.pnAnh.ResumeLayout(false);
            this.pnAnh.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel6;
        private Sunny.UI.UIPanel pnAnh;
        private Sunny.UI.UILabel lbTenGiay;
        private Sunny.UI.UIButton txtGia;
        private Sunny.UI.UILabel lbtonkho;
        private Sunny.UI.UIPanel uiPanel1;
        private Krypton.Toolkit.KryptonLabel lbgiam;
        private Sunny.UI.UILabel lbGia;
    }
}

