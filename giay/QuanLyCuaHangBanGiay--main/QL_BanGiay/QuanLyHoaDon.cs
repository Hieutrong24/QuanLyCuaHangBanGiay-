using BUS_QL_BanGiay;
using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using Microsoft.Data.SqlClient;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;
//using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
namespace QL_BanGiay
{
    public partial class QuanLyHoaDon : UserControl
    {
    
        HoaDonBUS hdBUS = new HoaDonBUS();
        CTHoaDonBUS ctBUS = new CTHoaDonBUS();
        public QuanLyHoaDon()
        {
            InitializeComponent();
           
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            var listHoaDon = hdBUS.GetAllHoaDon();
            LoadData(listHoaDon);
        }
        private void LoadData(IEnumerable<HoaDonDTO> list)
        {
           

            try
            {





                foreach (var hd in list)
                {
                    int rowIndex = dgview.Rows.Add();
                    DataGridViewRow row = dgview.Rows[rowIndex];

                    row.Cells["MaHD"].Value = hd.MaHD;
                    row.Cells["TenNV"].Value = hd.TenNV;
                    row.Cells["NgayBan"].Value = hd.NgayBan;
                    row.Cells["Tong"].Value = hd.TongTien;



                }

                // ----------------------------------------------------
                // PHẦN 4: THÊM CỘT BUTTON
                // ----------------------------------------------------



                // Cột Xóa
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.Name = "DeleteColumn";
                deleteButtonColumn.HeaderText = "Xóa";
                deleteButtonColumn.Text = "Xóa";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                dgview.Columns.Add(deleteButtonColumn);

            }
            catch (Exception ex)
            {
                // Hiển thị lỗi từ tầng BUS/DAL
                MessageBox.Show("Lỗi khi tải dữ liệu Hóa đơn: " + ex.Message, "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Không cần khối finally vì không có conn.Open() ở đây
        }

      


        private void uiPanel3_Click_1(object sender, EventArgs e)
        {

        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

        private void dgview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnback_Click(object sender, EventArgs e)
        {
            var listHoaDon = hdBUS.GetAllHoaDon();
            LoadData(listHoaDon);
        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QuanLyHoaDon_Load_1(object sender, EventArgs e)
        {

        }

        private void uiPanel1_Click_1(object sender, EventArgs e)
        {

        }

        private void dgview_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiPanel3_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel4_Click(object sender, EventArgs e)
        {

        }

        private void uiDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
