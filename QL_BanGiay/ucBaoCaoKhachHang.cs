using BUS_QL_BanGiay;
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
    public partial class ucBaoCaoKhachHang : Form
    {
        public ucBaoCaoKhachHang()
        {
            InitializeComponent();
        }

        private void ucBaoCaoKhachHang_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }

        private KhachHangBUS bus = new KhachHangBUS();
        private long currentMaKH;

        

        private void LoadData()
        {
            var kh = bus.GetDefaultCustomer();
            if (kh == null) return;

            currentMaKH = kh.MaKH;

            // Panel Hạng
            if (kh.HangThanhVien == "Golden")
                pnHang.BackgroundImage = Properties.Resources.iconCup; // hình chiếc cúp
            else
                pnHang.BackgroundImage = null;

            // Biểu đồ số lần mua hàng
            LoadChartSoLanMuaHang();
            LoadChartTanSuatMuaHang();
            // Lịch sử mua hàng
            data_LSMH.DataSource = bus.GetLichSuMuaHang(currentMaKH);

            // Danh sách khách hàng
            LoadDanhSachKhachHang();
        }

        private void LoadChartSoLanMuaHang()
        {
            DataTable dt = bus.GetSoLanMuaHangTheoThang(currentMaKH);
            var months = dt.AsEnumerable().Select(r => "Tháng " + r["Thang"].ToString()).ToArray();
            var values = dt.AsEnumerable().Select(r => Convert.ToDouble(r["SoLanMua"])).ToArray();

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Số lần mua hàng",
                    Values = new ChartValues<double>(values)
                }
            };

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Tháng",
                Labels = months
            });

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Số lần mua"
            });
        }


        private void LoadChartTanSuatMuaHang()
        {
            DataTable dt = bus.GetTanSuatMuaHang(currentMaKH);
            if (dt.Rows.Count <= 1) return;

            var labels = new List<string>();
            var values = new List<double>();

            foreach (DataRow row in dt.Rows)
            {
                labels.Add(Convert.ToDateTime(row["NgayBan"]).ToString("dd/MM"));
                values.Add(Convert.ToDouble(row["SoNgayCachLanTruoc"]));
            }

            cartesianChart_TanSuat.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Số ngày cách lần mua trước",
                    Values = new ChartValues<double>(values),
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                }
            };

            cartesianChart_TanSuat.AxisX.Clear();
            cartesianChart_TanSuat.AxisX.Add(new Axis
            {
                Title = "Ngày mua",
                Labels = labels
            });

            cartesianChart_TanSuat.AxisY.Clear();
            cartesianChart_TanSuat.AxisY.Add(new Axis
            {
                Title = "Số ngày cách lần trước"
            });

            pnTanSuatMuaHang.Controls.Clear();
            pnTanSuatMuaHang.Controls.Add(cartesianChart_TanSuat);
            cartesianChart_TanSuat.Dock = DockStyle.Fill;
        }


        private void LoadDanhSachKhachHang()
        {
            DataTable dt = bus.GetAllKhachHang();

            
            data_DSKHTT.DataSource = dt;

            
            data_DSKHTT.Columns["MaKH"].HeaderText = "Mã KH";
            data_DSKHTT.Columns["SDT"].HeaderText = "Số điện thoại";
            data_DSKHTT.Columns["NgayThamGia"].HeaderText = "Ngày tham gia";
            data_DSKHTT.Columns["TongDiem"].HeaderText = "Tổng điểm";
            data_DSKHTT.Columns["TrangThai"].HeaderText = "Trạng thái";

          
            data_DSKHTT.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            data_DSKHTT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

             
            foreach (DataGridViewColumn col in data_DSKHTT.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
             
            data_DSKHTT.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

           
            data_DSKHTT.CellClick -= Data_DSKHTT_CellClick;
            data_DSKHTT.CellClick += Data_DSKHTT_CellClick;
        }

        private void Data_DSKHTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = data_DSKHTT.Rows[e.RowIndex];

                
                if (row.Cells["MaKH"].Value == null ||
                    string.IsNullOrWhiteSpace(row.Cells["MaKH"].Value.ToString()))
                {
                    MessageBox.Show("Mã khách hàng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                long maKH;
                if (!long.TryParse(row.Cells["MaKH"].Value.ToString(), out maKH))
                {
                    MessageBox.Show("Giá trị Mã KH không phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentMaKH = maKH;

                
                LoadChartSoLanMuaHang();
                LoadChartTanSuatMuaHang();
                data_LSMH.DataSource = bus.GetLichSuMuaHang(currentMaKH);

                
                var kh = bus.GetAllKhachHang()
                    .AsEnumerable()
                    .FirstOrDefault(r => r.Field<long>("MaKH") == maKH);

                if (kh != null)
                {
                    string hang = bus.GetDefaultCustomer().HangThanhVien;
                    pnHang.BackgroundImage = (hang == "Golden") ? Properties.Resources.iconCup : null;
                }
            }
        }


        private void data_DSKHTT_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
