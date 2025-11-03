using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using Krypton.Toolkit;
using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class ucHSBanHang : UserControl
    {
        private DoanhThuBUS busDoanhThu = new DoanhThuBUS();
        ThongKeGiayBUS busThongKeGiay = new ThongKeGiayBUS();
        ThongKeBUS busThongKe = new ThongKeBUS();

        public ucHSBanHang()
        {
            InitializeComponent();
        }

        private void ucHSBanHang_Load(object sender, EventArgs e)
        {
            cbbLoaiThongKe.Items.AddRange(new string[] {
                "7 ngày gần nhất",
                "4 tháng gần nhất",
                "4 năm gần nhất"
            });
            cbbLoaiThongKe.SelectedIndex = 0;
            LoadBieuDo();

            cbbKieuThongKe.Items.AddRange(new string[]
           {
                "Theo Loại",
                "Theo Thương Hiệu",
                "Theo Màu"
           });
            cbbKieuThongKe.SelectedIndex = 0;
            LoadBieuDoPie();
            LoadDataThongKe();
 
            LoadDaTabtn_LuaChon(sender, e);
            this.Load += LoadDaTabtn_LuaChon;

            
        }

        private void cbbLoaiThongKe_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadBieuDo();
        }
        private KryptonContextMenu menu;

       
        private void LoadDaTabtn_LuaChon(object sender, EventArgs e)
        {
            menu = new KryptonContextMenu();
            KryptonContextMenuItems items = new KryptonContextMenuItems();

            KryptonContextMenuItem item1 = new KryptonContextMenuItem("1 ngày trước");
            KryptonContextMenuItem item3 = new KryptonContextMenuItem("3 ngày trước");
            KryptonContextMenuItem item7 = new KryptonContextMenuItem("7 ngày trước");
            KryptonContextMenuItem item14 = new KryptonContextMenuItem("14 ngày trước");
            KryptonContextMenuItem item30 = new KryptonContextMenuItem("30 ngày trước");

            item1.Click += (s, ev) => ChonKhoangThoiGian(item1);
            item3.Click += (s, ev) => ChonKhoangThoiGian(item3);
            item7.Click += (s, ev) => ChonKhoangThoiGian(item7);
            item14.Click += (s, ev) => ChonKhoangThoiGian(item14);
            item30.Click += (s, ev) => ChonKhoangThoiGian(item30);

            items.Items.AddRange(new KryptonContextMenuItem[] { item1, item3, item7, item14, item30 });
            menu.Items.Add(items);

            btnLuaChon.KryptonContextMenu = menu;
            ChonKhoangThoiGian(item1);
        }

        private void btnLuaChon_Click(object sender, EventArgs e)
        {
            if (menu != null)
                menu.Show(btnLuaChon, new Point(0, btnLuaChon.Height));
        }

        private void ChonKhoangThoiGian(KryptonContextMenuItem item)
        {
            
            btnLuaChon.Text = item.Text;

           
            foreach (var i in ((KryptonContextMenuItems)btnLuaChon.KryptonContextMenu.Items[0]).Items)
            {
                if (i is KryptonContextMenuItem menuItem)
                    menuItem.Checked = false;
            }

           
            item.Checked = true;

            
            LoadDataThongKe();
        }




        private void LoadBieuDo()
        {
            pnColumnChar.Controls.Clear();
            var chart = new LiveCharts.WinForms.CartesianChart { Dock = DockStyle.Fill };
            List<DoanhThuDTO> list = new List<DoanhThuDTO>();
            switch (cbbLoaiThongKe.SelectedIndex)
            {
                case 0:
                    list = busDoanhThu.GetDoanhThu7NgayGanNhat();
                    break;

                case 1:
                    list = busDoanhThu.GetDoanhThu4ThangGanNhat();
                    break;

                case 2:
                    list = busDoanhThu.GetDoanhThu4NamGanNhat();
                    break;

                default:
                    list = busDoanhThu.GetDoanhThu7NgayGanNhat();
                    break;
            }

            chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu (VNĐ)",
                    Values = new ChartValues<double>(list.Select(x => x.TongDoanhThu))
                }
            };

            chart.AxisX.Add(new Axis
            {
                Title = "Thời gian",
                Labels = list.Select(x => x.TenMocThoiGian).ToArray()
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Doanh thu (VNĐ)"
            });

            pnColumnChar.Controls.Add(chart);
        }

        private void cbbKieuThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBieuDoPie();

        }

        private void LoadBieuDoPie()
        {
            pnPieChar.Controls.Clear();

            DateTime denNgay = DateTime.Now;
            DateTime tuNgay = denNgay.AddDays(-6);  

            var pieChart = new LiveCharts.WinForms.PieChart
            {
                Dock = DockStyle.Fill
            };

            List<DoanhThuDTO> list = new List<DoanhThuDTO>();

            switch (cbbKieuThongKe.SelectedIndex)
            {
                case 0:
                    list = busDoanhThu.GetSoLuongBanTheoLoai(DateTime.Now.AddDays(-7), DateTime.Now);
                    break;

                case 1:
                    list = busDoanhThu.GetSoLuongBanTheoThuongHieu(DateTime.Now.AddDays(-7), DateTime.Now);
                    break;

                case 2:
                    list = busDoanhThu.GetSoLuongBanTheoMau(DateTime.Now.AddDays(-7), DateTime.Now);
                    break;

                default:
                    list = busDoanhThu.GetSoLuongBanTheoLoai(DateTime.Now.AddDays(-7), DateTime.Now);
                    break;
            }


            foreach (var item in list)
            {
                pieChart.Series.Add(new PieSeries
                {
                    Title = item.TenDanhMuc,
                    Values = new ChartValues<int> { item.SoLuongBan },
                    DataLabels = true
                });
            }

            pnPieChar.Controls.Add(pieChart);
        }

        private void LoadDataThongKe()
        {
            string luaChon = btnLuaChon.Text;
            List<ThongKeGiayDTO> list = busThongKeGiay.LayThongTinGiayTheoLuaChon(luaChon);

             
            data_DT.Rows.Clear();
            data_DT.Columns.Clear();

           
            data_DT.Columns.Add("TenGiay", "Tên Giày");
            data_DT.Columns.Add("DoiTuongSD", "Đối Tượng SD");
            data_DT.Columns.Add("TenLoai", "Loại Giày");
            data_DT.Columns.Add("TenThuongHieu", "Thương Hiệu");
            data_DT.Columns.Add("SoLuongBanRa", "SL Bán Ra");
            data_DT.Columns.Add("SoLuongTonKho", "SL Tồn Kho");
            data_DT.Columns.Add("LoiNhuan", "Lợi Nhuận");
 
            foreach (var item in list)
            {
                data_DT.Rows.Add(
                    item.TenGiay,
                    item.DoiTuongSD,
                    item.TenLoai,
                    item.TenThuongHieu,
                    item.SoLuongBanRa,
                    item.SoLuongTonKho,
                    item.LoiNhuan.ToString("N0") + " đ"
                );
            }
        }
        private void btnBanChay_Click(object sender, EventArgs e)
        {
            data_DT.ClearAll();
            string luaChon = btnLuaChon.Text;
            DataTable dt = busThongKe.GetSanPhamBanChayTheoNgay(luaChon);
            data_DT.DataSource = dt;
        }

        
    }
}
