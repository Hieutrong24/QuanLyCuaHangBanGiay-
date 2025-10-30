using BUS_QL_BanGiay;
using Krypton.Toolkit;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class ucHieuSuatNV : UserControl
    {
        private DoanhThuBUS busDoanhThu = new DoanhThuBUS();
        public ucHieuSuatNV()
        {
            InitializeComponent();
        }

        private void ucHieuSuatNV_Load(object sender, EventArgs e)
        {
            LoadTenNhanVien();


        }
        private void LoadTenNhanVien()
        {

            KryptonContextMenu menu = new KryptonContextMenu();
            KryptonContextMenuItems items = new KryptonContextMenuItems();

            NhanVienBUS busNV = new NhanVienBUS();
            var listTen = busNV.GetDanhSachTenNhanVien();

            foreach (var ten in listTen)
            {
                var item = new KryptonContextMenuItem(ten);
                item.Click += (s, e) =>
                {
                    cboTenNV.Values.Text = ten;
                };
                items.Items.Add(item);
            }


            menu.Items.Add(items);
            cboTenNV.KryptonContextMenu = menu;


            if (listTen.Count > 0)
                cboTenNV.Values.Text = listTen[0];
            else
                cboTenNV.Values.Text = "-- Không có nhân viên --";
        }

        DateTime TN, DN;
        private void btnNVLC()
        {

            TN = pkTN.Value;
            DN = pkDN.Value;
            if (TN > DN)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!");
                return;
            }
            HienThiBieuDoHieuSuatNhanVien(TN, DN, cboTenNV.Text);
        }

        private void cboTenNV_Click(object sender, EventArgs e)
        {
            btnNVLC();

        }

        private void pkTN_ValueChanged(object sender, EventArgs e)
        {
            btnNVLC();
        }

        private void pkDN_ValueChanged(object sender, EventArgs e)
        {
            btnNVLC();
        }

        private void HienThiBieuDoHieuSuatNhanVien(DateTime tuNgay, DateTime denNgay, string tenNV)
        {
            // Lấy dữ liệu từ BUS
            var data = busDoanhThu.GetDoanhThuNhanVienTheoKhoangNgay(tuNgay, denNgay, tenNV);


            if (!string.IsNullOrEmpty(tenNV) && tenNV != "Tất cả nhân viên")
            {
                data = data.Where(d => d.TenNV == tenNV).ToList();
            }


            var ngayList = data.Select(d => d.Ngay.ToString("dd/MM"))
                               .Distinct()
                               .OrderBy(x => x)
                               .ToList();


            var nvList = data.Select(d => d.TenNV)
                             .Distinct()
                             .ToList();


            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            Random rand = new Random();

            foreach (var nv in nvList)
            {
                var doanhThuList = new ChartValues<decimal>();

                foreach (var ngay in ngayList)
                {
                    DateTime parsedDate = DateTime.ParseExact(ngay, "dd/MM", CultureInfo.InvariantCulture);
                    var record = data.FirstOrDefault(d => d.TenNV == nv && d.Ngay.Date == parsedDate.Date);
                    doanhThuList.Add(record.Equals(default((string, DateTime, decimal))) ? 0m : record.DoanhThu);

                }

                var series = new LineSeries
                {
                    Title = nv,
                    Values = doanhThuList,
                    PointGeometrySize = 10,
                    LineSmoothness = 0.6,
                    StrokeThickness = 3,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    DataLabels = false
                };

                series.Fill = new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromArgb(
                        60,
                        (byte)rand.Next(0, 255),
                        (byte)rand.Next(0, 255),
                        (byte)rand.Next(0, 255)
                    ));

                cartesianChart1.Series.Add(series);
            }

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Ngày",
                Labels = ngayList
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Doanh thu (VNĐ)",
                LabelFormatter = value => value.ToString("N0")
            });

            cartesianChart1.LegendLocation = LegendLocation.Top;
        }


    }
}
