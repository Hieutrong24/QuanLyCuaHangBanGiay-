using LiveCharts;
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
using LiveCharts.Wpf;
using BUS_QL_BanGiay;


namespace QL_BanGiay
{
    public partial class ucBaoCaoTonKho : UserControl
    {
        ThongKeGiayBUS busThongKeGiay = new ThongKeGiayBUS();
        ThongKeBUS busThongKe = new ThongKeBUS();
        public ucBaoCaoTonKho()
        {
            InitializeComponent();
        }

        private void pnTonKho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HienThiBieuDo()
        {
            
            pnSPHH.Controls.Clear();

            DataTable dt = busThongKe.LaySanPhamSoLuongThap();
            if (dt.Rows.Count == 0)
            {
                Label lbl = new Label()
                {
                    Text = "Không có sản phẩm nào có số lượng dưới 100.",
                    AutoSize = true,
                    ForeColor = Color.Red,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                pnSPHH.Controls.Add(lbl);
                return;
            }

            // Tạo biểu đồ vùng (AreaChart)
            var chart = new LiveCharts.WinForms.CartesianChart();
            var values = new ChartValues<int>();
            var labels = new string[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                labels[i] = dt.Rows[i]["TenSanPham"].ToString();
                values.Add(Convert.ToInt32(dt.Rows[i]["SoLuong"]));
            }

            chart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Số lượng sản phẩm",
                    Values = values,
                    Fill = System.Windows.Media.Brushes.SkyBlue,
                    Stroke = System.Windows.Media.Brushes.SteelBlue,
                    PointGeometry = DefaultGeometries.Circle,
                    LineSmoothness = 0.4
                }
            };

            chart.AxisX.Add(new Axis
            {
                Title = "Sản phẩm",
                Labels = labels.ToList()
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Số lượng",
                LabelFormatter = value => value.ToString()
            });

            chart.Dock = DockStyle.Fill;
            pnSPHH.Controls.Add(chart);
        }


        private void LoadBieuDoTonKho()
        {
            var list = busThongKe.LayDanhSachTonKhoTheoLoai();

            var chart = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill
            };

            chart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Tồn kho",
                    Values = new ChartValues<int>(list.Select(x => x.TongSoLuong)),
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(135, 206, 250)), // LightSkyBlue
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 255)),   // Blue

                    PointGeometrySize = 8,
                    LineSmoothness = 0.5
                }
            };

            chart.AxisX.Add(new Axis
            {
                Title = "Loại giày",
                Labels = list.Select(x => x.TenLoai).ToList()
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Số lượng tồn"
            });

            pnTonKho.Controls.Clear();
            pnTonKho.Controls.Add(chart);
        }

        
        private void ucBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            LoadBieuDoTonKho();
            LoadPieChart();
            LoadPieChartSoLuong();
            HienThiBieuDo();
        }

        private void LoadPieChartSoLuong()
        {
            pnDNH.Controls.Clear();

            decimal tongThap = 350;
            decimal tongNhieu = 900;

            var pieChart = new LiveCharts.WinForms.PieChart
            {
                Dock = DockStyle.Fill,
                LegendLocation = LegendLocation.Bottom
            };

            pieChart.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Số lượng thấp (<100)",
                    Values = new ChartValues<decimal> { tongThap },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Số lượng nhiều (>99)",
                    Values = new ChartValues<decimal> { tongNhieu },
                    DataLabels = true
                }
            };


            pieChart.InnerRadius = 60;

            pnDNH.Controls.Add(pieChart);
        }

        private void LoadPieChart()
        {

            pnDTTN.Controls.Clear();

            decimal doanhThu = busThongKe.LayTongDoanhThuNamHienTai();
            decimal tienNhap = busThongKe.LayTongTienNhapKho();


            var pieChart = new LiveCharts.WinForms.PieChart
            {
                Dock = DockStyle.Fill,
                LegendLocation = LiveCharts.LegendLocation.Bottom,
                Series = new LiveCharts.SeriesCollection
                 {
                        new LiveCharts.Wpf.PieSeries
                        {
                            Title = "Doanh thu",
                            Values = new LiveCharts.ChartValues<decimal> { doanhThu },
                            DataLabels = true
                        },
                        new LiveCharts.Wpf.PieSeries
                        {
                            Title = "Nhập kho",
                            Values = new LiveCharts.ChartValues<decimal> { tienNhap },
                            DataLabels = true
                        }
                  }
            };

            pnDTTN.Controls.Add(pieChart);
        }

         
    }
}
