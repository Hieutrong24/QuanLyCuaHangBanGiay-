using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class frmTinhLuong : UserControl
    {
        DateTime TN, DN;
        string ht, nq;
        public frmTinhLuong()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
        }

        private void frmTinhLuong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var nhomQuyen = new Dictionary<string, string>
            {
                { "ADMIN", "Quản trị viên" },
                { "BANHANG", "Nhân viên bán hàng" },
                { "THUKHO", "Thủ kho" },
                { "KETOAN", "Kế toán" },
                { "BAOHANH", "Nhân viên bảo hành" }
            };

            cboNQ.DataSource = new BindingSource(nhomQuyen, null);
            cboNQ.DisplayMember = "Value";
            cboNQ.ValueMember = "Key";
            cboNQ.SelectedIndex = -1;

            LuongNhanVienBUS luongNhanVienBUS = new LuongNhanVienBUS();
            List<LuongNhanVienDTO> listLNV = new List<LuongNhanVienDTO>();
            listLNV = luongNhanVienBUS.GetAll();
            data_TinhLuong.Rows.Clear();

            for (int i = 0; i < listLNV.Count; i++)
            {
                int index = data_TinhLuong.Rows.Add();
                DataGridViewRow row = data_TinhLuong.Rows[index];

                row.Cells["clmSTT"].Value = i + 1;
                row.Cells["clmHoTen"].Value = listLNV[i].HoTen;
                row.Cells["clmCV"].Value = listLNV[i].Role;
                row.Cells["clmLuong1NC"].Value = Math.Round(listLNV[i].LuongCoBan / 26, 2);
                TN = pkTN.Value; DN = pkDN.Value;
                row.Cells["clmSNC"].Value = TinhNgayCong(DN, TN);
                row.Cells["clmLuong"].Value = Math.Round((listLNV[i].LuongCoBan / 26) * TinhNgayCong(DN, TN), 2);


            }
            LoadDatacboThuong();
            LoadDatacboPhat();

        }

        private void LoadDatacboThuong()
        {
            var Thuong = new Dictionary<string, string>
            {
                { "0", "Không thưởng" },
                { "1", "Thưởng 10%" },
                { "2", "Thưởng 20%" },
                { "3", "Thưởng 30%" },
                { "4", "Thưởng 40%" },
                { "5", "Thưởng 50%" }
            };
            cboThuong.DataSource = new BindingSource(Thuong, null);
            cboThuong.DisplayMember = "Value";
            cboThuong.ValueMember = "Key";
            cboThuong.SelectedIndex = -1;
        }

        private void cboThuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThuong.SelectedIndex != -1)
            {
                foreach (DataGridViewRow row in data_TinhLuong.Rows)
                {
                    if (row.Cells["clmLuong"].Value != null)
                    {
                        decimal luong = Convert.ToDecimal(row.Cells["clmLuong"].Value);
                        int thuong = 0;
                        int.TryParse(cboThuong?.SelectedValue?.ToString(), out thuong);

                        decimal tienThuong = luong * thuong / 100;
                        row.Cells["clmThuong"].Value = Math.Round(tienThuong, 2);
                        row.Cells["clmTL"].Value = Math.Round(luong + tienThuong, 2);
                    }
                }
            }
        }

        private void LoadDatacboPhat()
        {
            var Phat = new Dictionary<string, string>
            {
                { "0", "Không phạt" },
                { "1", "Phạt 10%" },
                { "2", "Phạt 20%" },
                { "3", "Phạt 30%" },
                { "4", "Phạt 40%" },
                { "5", "Phạt 50%" }
            };
            cboPhat.DataSource = new BindingSource(Phat, null);
            cboPhat.DisplayMember = "Value";
            cboPhat.ValueMember = "Key";
            cboPhat.SelectedIndex = -1;
        }
        private void cboPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhat.SelectedIndex != -1)
            {
                foreach (DataGridViewRow row in data_TinhLuong.Rows)
                {
                    if (row.Cells["clmTL"].Value != null)
                    {
                        decimal tongLuong = Convert.ToDecimal(row.Cells["clmLuong"].Value);
                        int phat = 0;
                        int.TryParse(cboPhat?.SelectedValue?.ToString(), out phat);

                        decimal tienPhat = tongLuong * phat / 100;
                        row.Cells["clmPhat"].Value = Math.Round(tienPhat, 2);
                        row.Cells["clmTL"].Value = Math.Round(tongLuong - tienPhat, 2);
                    }
                }
            }
        }

        private void pkTN_ValueChanged(object sender, EventArgs e)
        {
            TN = pkTN.Value;

        }
        private void pkDN_ValueChanged(object sender, EventArgs e)
        {
            DN = pkDN.Value;
        }
        private int TinhNgayCong(DateTime tn, DateTime dn)
        {
            return (dn.Day - tn.Day) < 0 ? (dn.Day - tn.Day) * -1 : (dn.Day - tn.Day);
        }



        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if(TN > DN)
            {
                UIMessageBox.ShowError("Ngày bắt đầu không được lớn hơn ngày kết thúc");
                return;
            }
            if(txtHT.Text != "")
            {
                LocTheoTen();
            }
            else if(cboNQ.SelectedIndex != -1)
            {
                LocTheoNhomQuyen();
            }
            else
            {
                LoadData();
            }
        }

        

        private void txtHT_TextChanged(object sender, EventArgs e)
        {
            ht = txtHT?.Text ?? "";
            cboNQ.SelectedIndex = -1;
            LocTheoTen();
        }
        private void LocTheoTen()
        {
            LuongNhanVienBUS luongNhanVienBUS = new LuongNhanVienBUS();
            List<LuongNhanVienDTO> listLNV = new List<LuongNhanVienDTO>();
            listLNV = luongNhanVienBUS.LocTheoTen(ht);
            data_TinhLuong.Rows.Clear();
            if (listLNV != null && listLNV.Count > 0)
            {
                for (int i = 0; i < listLNV.Count; i++)
                {
                    int index = data_TinhLuong.Rows.Add();
                    DataGridViewRow row = data_TinhLuong.Rows[index];
                    row.Cells["clmSTT"].Value = i + 1;
                    row.Cells["clmHoTen"].Value = listLNV[i].HoTen;
                    row.Cells["clmCV"].Value = listLNV[i].Role;
                    row.Cells["clmLuong1NC"].Value = Math.Round(listLNV[i].LuongCoBan / 26, 2);
                    TN = pkTN.Value; DN = pkDN.Value;
                    row.Cells["clmSNC"].Value = TinhNgayCong(DN, TN);
                    row.Cells["clmLuong"].Value = Math.Round((listLNV[i].LuongCoBan / 26) * TinhNgayCong(DN, TN), 2);
                }
            }
        }

        

        private void cboNQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            nq = cboNQ.SelectedValue?.ToString() ?? "";
            txtHT.Text = "";
            LocTheoNhomQuyen();

        }
        private void LocTheoNhomQuyen()
        {
            LuongNhanVienBUS luongNhanVienBUS = new LuongNhanVienBUS();
            List<LuongNhanVienDTO> listLNV = new List<LuongNhanVienDTO>();
            listLNV = luongNhanVienBUS.LocTheoNhomQuyen(nq);
            data_TinhLuong.Rows.Clear();
            if (listLNV != null && listLNV.Count > 0)
            {
                for (int i = 0; i < listLNV.Count; i++)
                {
                    int index = data_TinhLuong.Rows.Add();
                    DataGridViewRow row = data_TinhLuong.Rows[index];
                    row.Cells["clmSTT"].Value = i + 1;
                    row.Cells["clmHoTen"].Value = listLNV[i].HoTen;
                    row.Cells["clmCV"].Value = listLNV[i].Role;
                    row.Cells["clmLuong1NC"].Value = Math.Round(listLNV[i].LuongCoBan / 26, 2);
                    TN = pkTN.Value;
                    DN = pkDN.Value;
                    row.Cells["clmSNC"].Value = TinhNgayCong(DN, TN);
                    row.Cells["clmLuong"].Value = Math.Round((listLNV[i].LuongCoBan / 26) * TinhNgayCong(DN, TN), 2);
                }
            }

        }
    }


}
