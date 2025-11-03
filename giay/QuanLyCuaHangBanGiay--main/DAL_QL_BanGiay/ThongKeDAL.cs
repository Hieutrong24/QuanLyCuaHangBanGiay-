using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{
    public class ThongKeDAL :DBConnect
    {
        // Chuỗi kết nối đến cơ sở dữ liệu (cần được thay thế bằng chuỗi thực tế của bạn)
        private readonly string connectionString = "Server=YourServer;Database=YourDB;Integrated Security=True;";

        // Hàm chung để thực thi các lệnh SQL
        private int ExecuteNonQuery(string sql)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        // --- Phương thức 1: Thêm mới thống kê ---
        public int ThemThongKe(ThongKeDTO tk)
        {
            string sql = $"INSERT INTO ThongKeDoanhSo (MaThongKe, NgayLap, SoLuongBan, DoanhThu) " +
                         $"VALUES ({tk.MaThongKe}, '{tk.NgayLap:yyyy-MM-dd}', {tk.SoLuongBan}, {tk.DoanhThu})";
            return ExecuteNonQuery(sql);
        }

        // --- Phương thức 2: Sửa số lượng bán ---
        public int SuaSoLuongBan(int maThongKe, int soLuongMoi)
        {
            string sql = $"UPDATE ThongKeDoanhSo SET SoLuongBan = {soLuongMoi} " +
                         $"WHERE MaThongKe = {maThongKe}";
            return ExecuteNonQuery(sql);
        }

        // --- Phương thức 3: Sửa doanh thu ---
        public int SuaDoanhThu(int maThongKe, decimal doanhThuMoi)
        {
            string sql = $"UPDATE ThongKeDoanhSo SET DoanhThu = {doanhThuMoi} " +
                         $"WHERE MaThongKe = {maThongKe}";
            return ExecuteNonQuery(sql);
        }

        // --- Phương thức 4: Lấy ra danh sách thống kê ---
        public List<ThongKeDTO> LayDanhSachThongKe()
        {
            List<ThongKeDTO> list = new List<ThongKeDTO>();
            string sql = "SELECT MaThongKe, NgayLap, SoLuongBan, DoanhThu FROM ThongKeDoanhSo";

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ThongKeDTO
                            {
                                MaThongKe = reader.GetInt32(0),
                                NgayLap = reader.GetDateTime(1),
                                SoLuongBan = reader.GetInt32(2),
                                DoanhThu = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public DataTable GetSanPhamSoLuongThap()
        {
                    string query = @"
                SELECT TenGiay AS TenSanPham, SoLuong
                FROM Giay
                WHERE SoLuong < 100
            ";

            using (SqlConnection connection = GetConnection()) // dùng hàm GetConnection() chung
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable GetSanPhamSoLuongNhieu()
        {
            string query = @"
        SELECT TenGiay AS TenSanPham, SoLuong
        FROM Giay
        WHERE SoLuong > 99
        ORDER BY SoLuong DESC
    ";

            using (SqlConnection connection = GetConnection()) // dùng hàm GetConnection() chung
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }


        public List<ThongKeTonKhoDTO> GetTonKhoTheoLoai()
        {
            List<ThongKeTonKhoDTO> list = new List<ThongKeTonKhoDTO>();

            string query = @"
        SELECT l.TenLoai, SUM(g.SoLuong) AS TongSoLuong
        FROM Giay g
        JOIN Loai l ON g.MaLoai = l.MaLoai
        WHERE g.SoLuong >= 100
        GROUP BY l.TenLoai
        ORDER BY TongSoLuong DESC;
    ";

            using (SqlConnection connection = GetConnection()) // Dùng chung hàm GetConnection()
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ThongKeTonKhoDTO
                            {
                                TenLoai = reader["TenLoai"].ToString(),
                                TongSoLuong = Convert.ToInt32(reader["TongSoLuong"])
                            });
                        }
                    }
                }
            }

            return list;
        }


        public decimal GetTongDoanhThuNamHienTai()
        {
            decimal tong = 0;

            string query = @"
        SELECT SUM(TongTien) AS TongDoanhThu
        FROM HoaDon
        WHERE YEAR(NgayBan) = YEAR(GETDATE());
    ";

            using (SqlConnection connection = GetConnection()) // Dùng chung GetConnection()
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                        tong = Convert.ToDecimal(result);
                }
            }

            return tong;
        }

        public decimal GetTongTienNhapKho()
        {
            decimal tong = 0;

            string query = @"
        SELECT SUM(DonGia) AS TongNhapKho
        FROM Giay;
    ";

            using (SqlConnection connection = GetConnection()) // Dùng chung GetConnection()
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                        tong = Convert.ToDecimal(result);
                }
            }

            return tong;
        }


        public DataTable GetSanPhamBanChay(int soNgay)
        {
            string query = @"
        SELECT TOP 10 
            g.TenGiay AS TenSanPham,
            SUM(ct.SoLuong) AS TongSoLuongBan
        FROM ChiTietHoaDon ct
        INNER JOIN HoaDon hd ON ct.MaHD = hd.MaHD
        INNER JOIN Giay g ON ct.MaGiay = g.MaGiay
        WHERE hd.NgayBan >= DATEADD(DAY, -@SoNgay, GETDATE())
        GROUP BY g.TenGiay
        ORDER BY TongSoLuongBan DESC;
    ";

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SoNgay", soNgay);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }
}
