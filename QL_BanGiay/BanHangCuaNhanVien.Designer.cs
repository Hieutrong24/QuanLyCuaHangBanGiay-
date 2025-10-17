using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace QL_BanGiay
{
    partial class BanHangCuaNhanVien : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BanHangCuaNhanVien));
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.menulogout = new Sunny.UI.UIContextMenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bánChạyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sapxep = new Sunny.UI.UIContextMenuStrip();
            this.quảnLýTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlCommand2 = new Microsoft.Data.SqlClient.SqlCommand();
            this.uiPanel6 = new Sunny.UI.UIPanel();
            this.lblPageInfo = new Sunny.UI.UILabel();
            this.btnNext = new Sunny.UI.UIButton();
            this.btnPrev = new Sunny.UI.UIButton();
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenGiay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MauSac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeGiay = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.uiPanel5 = new Sunny.UI.UIPanel();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiPanel10 = new Sunny.UI.UIPanel();
            this.lbgia = new Sunny.UI.UILabel();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiComboBox1 = new Sunny.UI.UIComboBox();
            this.SearchBox = new Sunny.UI.UITextBox();
            this.uiPanel4 = new Sunny.UI.UIPanel();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.sapxep.SuspendLayout();
            this.uiPanel6.SuspendLayout();
            this.uiPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.uiPanel5.SuspendLayout();
            this.uiPanel10.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // menulogout
            // 
            this.menulogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.menulogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.menulogout.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menulogout.Name = "menulogout";
            this.menulogout.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 24);
            this.toolStripMenuItem1.Text = "Giá tăng dần";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 24);
            this.toolStripMenuItem2.Text = "Giá giảm dần";
            // 
            // bánChạyToolStripMenuItem
            // 
            this.bánChạyToolStripMenuItem.Name = "bánChạyToolStripMenuItem";
            this.bánChạyToolStripMenuItem.Size = new System.Drawing.Size(172, 24);
            this.bánChạyToolStripMenuItem.Text = "Bán chạy";
            // 
            // sapxep
            // 
            this.sapxep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(171)))), ((int)(((byte)(47)))));
            this.sapxep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.sapxep.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sapxep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.bánChạyToolStripMenuItem});
            this.sapxep.Name = "menulogout";
            this.sapxep.Size = new System.Drawing.Size(173, 76);
            // 
            // quảnLýTàiKhoảnToolStripMenuItem
            // 
            this.quảnLýTàiKhoảnToolStripMenuItem.Name = "quảnLýTàiKhoảnToolStripMenuItem";
            this.quảnLýTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.quảnLýTàiKhoảnToolStripMenuItem.Text = "Quản Lý Tài Khoản";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandTimeout = 30;
            this.sqlCommand2.EnableOptimizedParameterBinding = false;
            // 
            // uiPanel6
            // 
            this.uiPanel6.Controls.Add(this.lblPageInfo);
            this.uiPanel6.Controls.Add(this.btnNext);
            this.uiPanel6.Controls.Add(this.btnPrev);
            this.uiPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPanel6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(243)))));
            this.uiPanel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel6.Location = new System.Drawing.Point(0, 586);
            this.uiPanel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel6.Name = "uiPanel6";
            this.uiPanel6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(243)))));
            this.uiPanel6.Size = new System.Drawing.Size(781, 44);
            this.uiPanel6.TabIndex = 46;
            this.uiPanel6.Text = null;
            this.uiPanel6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblPageInfo.Location = new System.Drawing.Point(339, 18);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(126, 23);
            this.lblPageInfo.TabIndex = 2;
            this.lblPageInfo.Text = "Trang";
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(120)))), ((int)(((byte)(141)))));
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNext.Location = new System.Drawing.Point(535, 6);
            this.btnNext.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Radius = 30;
            this.btnNext.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(120)))), ((int)(((byte)(141)))));
            this.btnNext.Size = new System.Drawing.Size(98, 35);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Sau";
            this.btnNext.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(120)))), ((int)(((byte)(141)))));
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPrev.Location = new System.Drawing.Point(166, 6);
            this.btnPrev.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Radius = 30;
            this.btnPrev.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(120)))), ((int)(((byte)(141)))));
            this.btnPrev.Size = new System.Drawing.Size(100, 35);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "Trước";
            this.btnPrev.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // uiPanel3
            // 
            this.uiPanel3.Controls.Add(this.uiDataGridView1);
            this.uiPanel3.Controls.Add(this.uiPanel5);
            this.uiPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiPanel3.FillColor = System.Drawing.Color.White;
            this.uiPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel3.Location = new System.Drawing.Point(781, 43);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Radius = 0;
            this.uiPanel3.RectColor = System.Drawing.Color.Transparent;
            this.uiPanel3.Size = new System.Drawing.Size(368, 587);
            this.uiPanel3.TabIndex = 47;
            this.uiPanel3.Text = null;
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.uiDataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView1.ColumnHeadersHeight = 32;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.TenGiay,
            this.SoLuong,
            this.MauSac,
            this.Gia,
            this.SizeGiay});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiDataGridView1.GridColor = System.Drawing.Color.White;
            this.uiDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.uiDataGridView1.Name = "uiDataGridView1";
            this.uiDataGridView1.RectColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.uiDataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridView1.ScrollBarColor = System.Drawing.Color.Black;
            this.uiDataGridView1.ScrollBarRectColor = System.Drawing.Color.Black;
            this.uiDataGridView1.ScrollBarStyleInherited = false;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.Size = new System.Drawing.Size(368, 453);
            this.uiDataGridView1.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.TabIndex = 3;
            // 
            // id
            // 
            this.id.HeaderText = "Mã Sản Phẩm";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 133;
            // 
            // TenGiay
            // 
            this.TenGiay.HeaderText = "Tên Giày";
            this.TenGiay.MinimumWidth = 6;
            this.TenGiay.Name = "TenGiay";
            this.TenGiay.Width = 96;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 102;
            // 
            // MauSac
            // 
            this.MauSac.HeaderText = "Màu sắc";
            this.MauSac.MinimumWidth = 6;
            this.MauSac.Name = "MauSac";
            this.MauSac.Width = 93;
            // 
            // Gia
            // 
            this.Gia.HeaderText = "Giá";
            this.Gia.MinimumWidth = 6;
            this.Gia.Name = "Gia";
            this.Gia.Width = 58;
            // 
            // SizeGiay
            // 
            this.SizeGiay.HeaderText = "Size";
            this.SizeGiay.MinimumWidth = 6;
            this.SizeGiay.Name = "SizeGiay";
            this.SizeGiay.Width = 45;
            // 
            // uiPanel5
            // 
            this.uiPanel5.Controls.Add(this.uiButton1);
            this.uiPanel5.Controls.Add(this.uiPanel10);
            this.uiPanel5.Controls.Add(this.uiButton2);
            this.uiPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPanel5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(243)))));
            this.uiPanel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel5.Location = new System.Drawing.Point(0, 453);
            this.uiPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel5.Name = "uiPanel5";
            this.uiPanel5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(243)))));
            this.uiPanel5.Size = new System.Drawing.Size(368, 134);
            this.uiPanel5.TabIndex = 3;
            this.uiPanel5.Text = null;
            this.uiPanel5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(171)))), ((int)(((byte)(47)))));
            this.uiButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton1.Location = new System.Drawing.Point(174, 58);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 20;
            this.uiButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(171)))), ((int)(((byte)(47)))));
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.TabIndex = 25;
            this.uiButton1.Text = "Xác Nhận";
            this.uiButton1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiPanel10
            // 
            this.uiPanel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.uiPanel10.Controls.Add(this.lbgia);
            this.uiPanel10.Controls.Add(this.uiLabel12);
            this.uiPanel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel10.FillColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel10.Location = new System.Drawing.Point(0, 0);
            this.uiPanel10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel10.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel10.Name = "uiPanel10";
            this.uiPanel10.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(156)))));
            this.uiPanel10.Size = new System.Drawing.Size(368, 35);
            this.uiPanel10.TabIndex = 26;
            this.uiPanel10.Text = null;
            this.uiPanel10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbgia
            // 
            this.lbgia.BackColor = System.Drawing.Color.Transparent;
            this.lbgia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbgia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbgia.Location = new System.Drawing.Point(200, 7);
            this.lbgia.Name = "lbgia";
            this.lbgia.Size = new System.Drawing.Size(100, 23);
            this.lbgia.TabIndex = 1;
            this.lbgia.Text = "0đ";
            // 
            // uiLabel12
            // 
            this.uiLabel12.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(156)))));
            this.uiLabel12.Location = new System.Drawing.Point(3, 7);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(100, 23);
            this.uiLabel12.TabIndex = 0;
            this.uiLabel12.Text = "Tổng Cộng";
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.uiButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(138)))), ((int)(((byte)(151)))));
            this.uiButton2.Location = new System.Drawing.Point(92, 58);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Radius = 20;
            this.uiButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.uiButton2.Size = new System.Drawing.Size(100, 35);
            this.uiButton2.TabIndex = 24;
            this.uiButton2.Text = "Xoá đơn";
            this.uiButton2.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton2.TipsForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(138)))), ((int)(((byte)(151)))));
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiPanel2
            // 
            this.uiPanel2.BackColor = System.Drawing.Color.Transparent;
            this.uiPanel2.Controls.Add(this.uiLabel7);
            this.uiPanel2.Controls.Add(this.uiComboBox1);
            this.uiPanel2.Controls.Add(this.SearchBox);
            this.uiPanel2.Controls.Add(this.uiPanel4);
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(243)))));
            this.uiPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel2.Location = new System.Drawing.Point(0, 0);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(243)))));
            this.uiPanel2.Size = new System.Drawing.Size(1149, 43);
            this.uiPanel2.TabIndex = 48;
            this.uiPanel2.Text = null;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel2.Click += new System.EventHandler(this.uiPanel2_Click);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(162)))), ((int)(((byte)(156)))));
            this.uiLabel7.Location = new System.Drawing.Point(391, 10);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(77, 31);
            this.uiLabel7.TabIndex = 43;
            this.uiLabel7.Text = "Sắp Xếp:";
            // 
            // uiComboBox1
            // 
            this.uiComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiComboBox1.DataSource = null;
            this.uiComboBox1.FillColor = System.Drawing.Color.White;
            this.uiComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiComboBox1.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uiComboBox1.Items.AddRange(new object[] {
            "Giá tăng dần",
            "Giá giảm dần",
            "Bán chạy"});
            this.uiComboBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox1.Location = new System.Drawing.Point(476, 7);
            this.uiComboBox1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.uiComboBox1.MinimumSize = new System.Drawing.Size(72, 0);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 34, 3);
            this.uiComboBox1.Radius = 15;
            this.uiComboBox1.Size = new System.Drawing.Size(132, 30);
            this.uiComboBox1.SymbolSize = 24;
            this.uiComboBox1.TabIndex = 42;
            this.uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox1.Watermark = "";
            // 
            // SearchBox
            // 
            this.SearchBox.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(120)))), ((int)(((byte)(141)))));
            this.SearchBox.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(120)))), ((int)(((byte)(141)))));
            this.SearchBox.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(120)))), ((int)(((byte)(141)))));
            this.SearchBox.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(120)))), ((int)(((byte)(141)))));
            this.SearchBox.ButtonStyleInherited = false;
            this.SearchBox.ButtonSymbol = 61442;
            this.SearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SearchBox.Location = new System.Drawing.Point(70, 7);
            this.SearchBox.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.SearchBox.MinimumSize = new System.Drawing.Size(1, 21);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.SearchBox.Radius = 29;
            this.SearchBox.RectColor = System.Drawing.Color.Black;
            this.SearchBox.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(120)))), ((int)(((byte)(141)))));
            this.SearchBox.ScrollBarStyleInherited = false;
            this.SearchBox.ShowButton = true;
            this.SearchBox.ShowText = false;
            this.SearchBox.Size = new System.Drawing.Size(269, 32);
            this.SearchBox.Symbol = 61442;
            this.SearchBox.TabIndex = 41;
            this.SearchBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchBox.Watermark = "Tìm Kiếm . . .";
            this.SearchBox.WatermarkActiveColor = System.Drawing.SystemColors.ButtonFace;
            this.SearchBox.ButtonClick += new System.EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // uiPanel4
            // 
            this.uiPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(252)))));
            this.uiPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiPanel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(252)))));
            this.uiPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPanel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(178)))));
            this.uiPanel4.Location = new System.Drawing.Point(781, 0);
            this.uiPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel4.Name = "uiPanel4";
            this.uiPanel4.RectColor = System.Drawing.Color.Transparent;
            this.uiPanel4.Size = new System.Drawing.Size(368, 43);
            this.uiPanel4.TabIndex = 39;
            this.uiPanel4.Text = "Tạo Hoá Đơn";
            this.uiPanel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.uiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 3;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(781, 543);
            this.uiTableLayoutPanel1.TabIndex = 49;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // BanHangCuaNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1149, 630);
            this.Controls.Add(this.uiTableLayoutPanel1);
            this.Controls.Add(this.uiPanel6);
            this.Controls.Add(this.uiPanel3);
            this.Controls.Add(this.uiPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BanHangCuaNhanVien";
            this.Text = "Quản lý bán hàng";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.sapxep.ResumeLayout(false);
            this.uiPanel6.ResumeLayout(false);
            this.uiPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.uiPanel5.ResumeLayout(false);
            this.uiPanel10.ResumeLayout(false);
            this.uiPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Sunny.UI.UIContextMenuStrip menulogout;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem bánChạyToolStripMenuItem;
        private Sunny.UI.UIContextMenuStrip sapxep;
        private ToolStripMenuItem quảnLýTàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand2;
        private Sunny.UI.UIPanel uiPanel6;
        private Sunny.UI.UILabel lblPageInfo;
        private Sunny.UI.UIButton btnNext;
        private Sunny.UI.UIButton btnPrev;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private Sunny.UI.UIPanel uiPanel5;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIPanel uiPanel10;
        private Sunny.UI.UILabel lbgia;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UITextBox SearchBox;
        private Sunny.UI.UIPanel uiPanel4;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn TenGiay;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn MauSac;
        private DataGridViewTextBoxColumn Gia;
        private DataGridViewComboBoxColumn SizeGiay;
    }
}
