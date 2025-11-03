using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
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
    }
}
