using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QL_BanGiay;
namespace DAL_QL_BanGiay
{

    public class CTHoaDonDAL : DBConnect
    {
        public bool InsertChiTietHoaDon(CTHoaDonDTO cthd)
        {
            string query = @"INSERT INTO ChiTietHoaDon (MaHD, MaGiay, SoLuong, GiaBan)
                             VALUES (@MaHD, @MaGiay, @SoLuong, @GiaBan)";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHD", cthd.MaHD);
                cmd.Parameters.AddWithValue("@MaGiay", cthd.MaGiay);
                cmd.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
                cmd.Parameters.AddWithValue("@GiaBan", cthd.GiaBan);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi DAL: Không thể thêm chi tiết hóa đơn. " + ex.Message);
                }
            }
        }

        // Nếu cần thêm nhiều chi tiết 1 lúc
        public bool InsertDanhSachChiTiet(List<CTHoaDonDTO> danhSach)
        {
            bool success = true;

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                foreach (var cthd in danhSach)
                {
                    using (SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO ChiTietHoaDon (MaHD, MaGiay, SoLuong, GiaBan)
                          VALUES (@MaHD, @MaGiay, @SoLuong, @GiaBan)", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", cthd.MaHD);
                        cmd.Parameters.AddWithValue("@MaGiay", cthd.MaGiay);
                        cmd.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
                        cmd.Parameters.AddWithValue("@GiaBan", cthd.GiaBan);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0) success = false;
                    }
                }
            }

            return success;
        }
        public bool DeleteChiTietHoaDon(long maHD, long maGiay)
        {
            // Câu lệnh DELETE an toàn (sử dụng tham số)
            string query = "DELETE FROM ChiTietHoaDon WHERE MaHD = @MaHD AND MaGiay = @MaGiay";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // 🔥 SỬ DỤNG THAM SỐ để chống SQL Injection
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                cmd.Parameters.AddWithValue("@MaGiay", maGiay);

                try
                {
                    conn.Open();
                    // ExecuteNonQuery trả về số lượng hàng bị ảnh hưởng (deleted)
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Nếu rowsAffected > 0, nghĩa là lệnh xóa đã thành công
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Tùy chọn: Ghi log lỗi
                    Console.WriteLine("Lỗi DAL khi xóa Chi Tiết Hóa đơn: " + ex.Message);
                    // Ném lỗi ra tầng trên (BUS)
                    throw new Exception("Lỗi khi xóa chi tiết hóa đơn: " + ex.Message, ex);
                }
            }
        }
        public bool DeleteChiTietHoaDon(long maHD)
        {
            // Câu lệnh DELETE an toàn (sử dụng tham số)
            string query = "DELETE FROM ChiTietHoaDon WHERE MaHD = @MaHD ";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // 🔥 SỬ DỤNG THAM SỐ để chống SQL Injection
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                try
                {
                    conn.Open();
                    // ExecuteNonQuery trả về số lượng hàng bị ảnh hưởng (deleted)
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Nếu rowsAffected > 0, nghĩa là lệnh xóa đã thành công
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Tùy chọn: Ghi log lỗi
                    Console.WriteLine("Lỗi DAL khi xóa Chi Tiết Hóa đơn: " + ex.Message);
                    // Ném lỗi ra tầng trên (BUS)
                    throw new Exception("Lỗi khi xóa chi tiết hóa đơn: " + ex.Message, ex);
                }
            }
        }
        public List<CTHoaDonDTO> GetChiTietByMaHD(string maHD)
        {
            List<CTHoaDonDTO> list = new List<CTHoaDonDTO>();

            // Câu lệnh SQL JOIN để lấy cả TenGiay và MaAnh
            string query = "SELECT ct.MaHD, ct.MaGiay, ct.SoLuong, ct.GiaBan, g.TenGiay, g.MaAnh " +
                           "FROM ChiTietHoaDon ct JOIN Giay g ON ct.MaGiay = g.MaGiay " +
                           "WHERE ct.MaHD = @MaHD";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // 🔥 SỬ DỤNG THAM SỐ để chống SQL Injection
                cmd.Parameters.AddWithValue("@MaHD", maHD);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CTHoaDonDTO cthd = new CTHoaDonDTO();

                            // Đọc dữ liệu từ SQL
                            cthd.MaHD = reader.GetInt32(reader.GetOrdinal("MaHD"));
                            cthd.MaGiay = reader.GetInt32(reader.GetOrdinal("MaGiay"));
                            cthd.SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")); // INT -> GetInt32
                            cthd.GiaBan = reader.GetDecimal(reader.GetOrdinal("GiaBan"));

                            // Lấy thêm các trường JOIN
                            cthd.TenGiay = reader.GetString(reader.GetOrdinal("TenGiay"));

                            // Xử lý trường có thể NULL
                            cthd.MaAnh = reader.IsDBNull(reader.GetOrdinal("MaAnh")) ? string.Empty : reader.GetString(reader.GetOrdinal("MaAnh"));

                            list.Add(cthd);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi DAL khi tải Chi Tiết Hóa đơn: " + ex.Message);
                    throw; // Ném lỗi để tầng trên (BUS) xử lý
                }
            }
            return list;
        }
    }
}
