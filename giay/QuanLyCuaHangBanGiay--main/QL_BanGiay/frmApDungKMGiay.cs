using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class frmApDungKMGiay : UIForm
    {
        private string _maCTKM;

        public frmApDungKMGiay(string maCTKM)
        {
            InitializeComponent();
            _maCTKM = maCTKM;
        }

        private void frmApDungKMGiay_Load(object sender, EventArgs e)
        {
            data_SPAD.Columns.Clear();
            data_SPAD.AllowUserToAddRows = false;
            data_SPAD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            data_SPAD.MultiSelect = false;

           
            DataGridViewCheckBoxColumn colChon = new DataGridViewCheckBoxColumn();
            colChon.HeaderText = "Chọn";
            colChon.Name = "colChon";
            colChon.Width = 50;
            data_SPAD.Columns.Add(colChon);
             
            data_SPAD.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colTenGiay", HeaderText = "Tên giày", ReadOnly = true });
            data_SPAD.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colLoai", HeaderText = "Loại", ReadOnly = true });
            data_SPAD.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colThuongHieu", HeaderText = "Thương hiệu", ReadOnly = true });
            data_SPAD.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colMau", HeaderText = "Màu sắc", ReadOnly = true });
            data_SPAD.Columns.Add(new DataGridViewTextBoxColumn() { Name = "colSize", HeaderText = "Size", ReadOnly = true });
             
            DataGridViewComboBoxColumn colSoLuong = new DataGridViewComboBoxColumn();
            colSoLuong.HeaderText = "Số lượng";
            colSoLuong.Name = "colSoLuong";
            for (int i = 1; i <= 100; i++)
                colSoLuong.Items.Add(i);
            data_SPAD.Columns.Add(colSoLuong);

            
            LoadData();
        }



        private void LoadData()
        {
            var spBUS = new BUS_QL_BanGiay.GiayBUS();
            List<DTO_QL_BanGiay.GiayDTO> lstSP = spBUS.GetAllADKM();

            data_SPAD.Rows.Clear();

            foreach (var sp in lstSP)
            {
                int index = data_SPAD.Rows.Add();
                DataGridViewRow row = data_SPAD.Rows[index];

                row.Cells["colTenGiay"].Value = sp.TenGiay;
                row.Cells["colLoai"].Value = sp.TenLoai;
                row.Cells["colThuongHieu"].Value = sp.TenThuongHieu;
                row.Cells["colMau"].Value = sp.TenMau;
                row.Cells["colSize"].Value = sp.Size;
                row.Cells["colSoLuong"].Value = 1;
            }
        }
    }

 
    public static class UIDataGridViewExtensions
    {
        public static void AddColumn(this UIDataGridView grid, string header, string name)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = header;
            col.Name = name;
            col.ReadOnly = true;
            grid.Columns.Add(col);
        }
    }
}
