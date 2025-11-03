using BUS_QL_BanGiay;
using Krypton.Toolkit;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class drmAPDuungKM : UserControl
    {
        public drmAPDuungKM()
        {
            this.Load += new System.EventHandler(this.drmAPDuungKM_Load);

            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
        }

        private void drmAPDuungKM_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadbtnDRLoc();
        }

        private void LoadData()
        {
            BUS_QL_BanGiay.ChuongTrinhKhuyenMaiBUS ctkmBUS = new BUS_QL_BanGiay.ChuongTrinhKhuyenMaiBUS();
            List<DTO_QL_BanGiay.ChuongTrinhKhuyenMaiDTO> listCTKM = ctkmBUS.GetAllChuongTrinhKhuyenMai();

            data_ADKM.Rows.Clear();
            data_ADKM.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    e.PaintBackground(e.CellBounds, true);

                    bool isOn = false;
                    if (e.FormattedValue != null && bool.TryParse(e.FormattedValue.ToString(), out bool val))
                        isOn = val;
                    
                    Rectangle rect = e.CellBounds;
                    rect.Inflate(-8, -8);

                    // Vẽ nền bo tròn (thanh switch)
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        int radius = rect.Height / 2;
                        path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 90, 180);
                        path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 180);
                        path.CloseFigure();

                        Color backColor = isOn ? Color.MediumSeaGreen : Color.LightGray;
                        using (SolidBrush brush = new SolidBrush(backColor))
                            e.Graphics.FillPath(brush, path);
                    }

                    // Vẽ nút tròn di chuyển theo trạng thái
                    int circleSize = rect.Height - 4;
                    int circleX = isOn ? rect.Right - circleSize - 2 : rect.X + 2;
                    int circleY = rect.Y + 2;

                    using (SolidBrush circleBrush = new SolidBrush(Color.White))
                    {
                        e.Graphics.FillEllipse(circleBrush, circleX, circleY, circleSize, circleSize);
                        e.Graphics.DrawEllipse(Pens.Gray, circleX, circleY, circleSize, circleSize);
                    }

                    e.Handled = true;

                   
                }
            };


            data_ADKM.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Chỉ khi click vào cột switch
                {
                    bool current = Convert.ToBoolean(data_ADKM.Rows[e.RowIndex].Cells[0].Value);
                    bool newValue = !current;

       
                    data_ADKM.Rows[e.RowIndex].Cells[0].Value = newValue;
                    data_ADKM.InvalidateCell(e.ColumnIndex, e.RowIndex);

          
                    if (newValue)
                    {
                        string maCTKM = data_ADKM.Rows[e.RowIndex].Cells["clmKIchHoat"].Value?.ToString();
                        if (!string.IsNullOrEmpty(maCTKM))
                        {
                            frmApDungKMGiay frm = new frmApDungKMGiay(maCTKM);
                            frm.ShowDialog();
                        }
                    }
                }
                else if (e.RowIndex >= 0)
                {
                     
                    string maCTKM = data_ADKM.Rows[e.RowIndex].Cells["clmKIchHoat"].Value?.ToString(); 

                    if (!string.IsNullOrEmpty(maCTKM))
                    {
                       
                        frmApDungKMGiay frm = new frmApDungKMGiay(maCTKM);
                        frm.ShowDialog();  
                    }
                }
            };


            foreach (var ctkm in listCTKM)
            {
                DataGridViewRow row = new DataGridViewRow();
                ChiTietKMBUS chiTietKMBUS = new ChiTietKMBUS();
                bool isActive = chiTietKMBUS.TimCTKMTheoMa(ctkm.MaCTKM);
                row.Height = 40;

                row.CreateCells(data_ADKM);
                row.Cells[0].Value = isActive;
                data_ADKM.Columns[0].Width = 80;
                row.Cells[1].Value = ctkm.TenCTKM;
                row.Cells[2].Value = ctkm.DieuKien;
                row.Cells[3].Value = ctkm.LoaiCTKM;

                if (isActive)
                {
                    row.Cells[4].Value = "Đang hoạt động";
                    row.Cells[4].Style.BackColor = Color.LightGreen;
                    row.Cells[4].Style.ForeColor = Color.Black;
                }
                else
                {
                    row.Cells[4].Value = "Ngừng hoạt động";
                    row.Cells[4].Style.BackColor = Color.Orange;
                    row.Cells[4].Style.ForeColor = Color.White;
                }

                row.Cells[5].Value = chiTietKMBUS.TimCTKMTheoMa(ctkm.MaCTKM) + " Sản phẩm";
                row.Cells[6].Value = ctkm.MucGiamGia;
                data_ADKM.Rows.Add(row);
            }
        }


        private void LoadbtnDRLoc()
        {
            btnDRLoc.Text = "Lọc dữ liệu";

 
            btnDRLoc.KryptonContextMenu = new KryptonContextMenu();

  
            KryptonContextMenuItems items = new KryptonContextMenuItems();
            items.Items.Add(new KryptonContextMenuItem("Tất cả", OnFilterClick));
            items.Items.Add(new KryptonContextMenuItem("Đang hoạt động", OnFilterClick));
            items.Items.Add(new KryptonContextMenuItem("Ngừng hoạt động", OnFilterClick));
 
            btnDRLoc.KryptonContextMenu.Items.Add(items);

        }

        private void OnFilterClick(object sender, EventArgs e)
        {
            var item = sender as KryptonContextMenuItem;
            if (item != null)
            {
                MessageBox.Show($"Bạn đã chọn: {item.Text}");
 
            }
        }
    }
}
