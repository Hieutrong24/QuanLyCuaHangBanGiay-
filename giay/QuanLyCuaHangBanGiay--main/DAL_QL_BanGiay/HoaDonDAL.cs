using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QL_BanGiay;
using DAL_QL_BanGiay;
namespace DAL_QL_BanGiay
{
    public class HoaDonDAL : DBConnect
    {
        public bool DeleteHoaDon(long maHD)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM HoaDon WHERE MaHD = @MaHD";
                cmd.Parameters.AddWithValue("@MaHD", maHD);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0; // Trả về true nếu xóa được ít nhất 1 hóa đơn
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi DAL khi xóa Hóa đơn: " + ex.Message);
                    throw new Exception("Lỗi khi xóa Hóa đơn: " + ex.Message, ex);
                }
            }
        }


        public bool CapNhatTongTienHoaDon(long maHD)
        {
            string query = @"
                UPDATE HoaDon
                SET TongTien = (
                    SELECT SUM(SoLuong * GiaBan)
                    FROM ChiTietHoaDon
                    WHERE MaHD = @MaHD
                )
                WHERE MaHD = @MaHD;
            ";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHD", maHD);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi DAL khi cập nhật tổng tiền hóa đơn: " + ex.Message);
                    throw new Exception("Lỗi khi tính tổng tiền hóa đơn: " + ex.Message, ex);
                }
            }
        }
        public List<HoaDonDTO> GetAllHoaDon()
        {
            List<HoaDonDTO> list = new List<HoaDonDTO>();
            // Câu lệnh SQL (chọn tất cả các cột cần thiết)
            string query = "SELECT MaHD,HoTen, MaKH, MaNV, NgayBan, TongTien, Thue, MaKM FROM HoaDon hd join TaiKhoan tk on hd.MaNV=tk.MaTK ";

            // Sử dụng khối using để đảm bảo Connection và Command được đóng
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoaDonDTO hd = new HoaDonDTO();

                            // 1. Chuyển dữ liệu từ DataReader sang thuộc tính DTO
                            hd.MaHD = reader.GetInt64(reader.GetOrdinal("MaHD"));
                            hd.MaKH = reader.GetInt64(reader.GetOrdinal("MaKH"));
                            hd.TenNV = reader.GetString(reader.GetOrdinal("HoTen"));
                            // Kiểm tra DBNull cho MaNV trước khi đọc (nếu cột đó có thể NULL)
                            if (!reader.IsDBNull(reader.GetOrdinal("MaNV")))
                            {
                                hd.MaNV = reader.GetInt64(reader.GetOrdinal("MaNV"));
                            }
                            // Bạn cần xử lý tương tự cho các cột BIGINT khác

                            hd.NgayBan = reader.GetDateTime(reader.GetOrdinal("NgayBan"));

                            // Dùng GetDecimal cho các cột DECIMAL
                            hd.TongTien = reader.GetDecimal(reader.GetOrdinal("TongTien"));
                            hd.Thue = reader.GetDecimal(reader.GetOrdinal("Thue"));

                            if (!reader.IsDBNull(reader.GetOrdinal("MaKM")))
                            {
                                hd.MaKM = reader.GetInt64(reader.GetOrdinal("MaKM"));
                            }

                            list.Add(hd);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Tùy chọn: Ghi log lỗi ra Console hoặc file log
                    Console.WriteLine("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
                    // Có thể throw lại lỗi hoặc trả về danh sách trống
                    throw new Exception("Lỗi DAL khi tải Hóa đơn.", ex);
                }
            } // Kết nối tự động đóng ở đây

            return list;
        }
        public List<HoaDonDTO> GetAllHoaDon_TongTienTang()
        {
            return GetHoaDonByQuery(@"
        SELECT MaHD, HoTen, MaKH, MaNV, NgayBan, TongTien, Thue, MaKM
        FROM HoaDon hd 
        JOIN TaiKhoan tk ON hd.MaNV = tk.MaTK
        ORDER BY TongTien");
        }

        // ====== 2. Theo tổng tiền giảm dần ======
        public List<HoaDonDTO> GetAllHoaDon_TongTienGiam()
        {
            return GetHoaDonByQuery(@"
        SELECT MaHD, HoTen, MaKH, MaNV, NgayBan, TongTien, Thue, MaKM
        FROM HoaDon hd 
        JOIN TaiKhoan tk ON hd.MaNV = tk.MaTK
        ORDER BY TongTien DESC ");
        }

        // ====== 3. Theo ngày mới nhất ======
        public List<HoaDonDTO> GetAllHoaDon_MoiNhat()
        {
            return GetHoaDonByQuery(@"
        SELECT MaHD, HoTen, MaKH, MaNV, NgayBan, TongTien, Thue, MaKM
        FROM HoaDon hd 
        JOIN TaiKhoan tk ON hd.MaNV = tk.MaTK
        ORDER BY NgayBan DESC");
        }

        // ====== 4. Theo ngày cũ nhất ======
        public List<HoaDonDTO> GetAllHoaDon_CuNhat()
        {
            return GetHoaDonByQuery(@"
        SELECT MaHD, HoTen, MaKH, MaNV, NgayBan, TongTien, Thue, MaKM
        FROM HoaDon hd 
        JOIN TaiKhoan tk ON hd.MaNV = tk.MaTK
        ORDER BY NgayBan ASC");
        }

        private List<HoaDonDTO> GetHoaDonByQuery(string query)
        {
            List<HoaDonDTO> list = new List<HoaDonDTO>();

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoaDonDTO hd = new HoaDonDTO();

                            hd.MaHD = Convert.ToInt64(reader["MaHD"]);
                            hd.MaKH = Convert.ToInt64(reader["MaKH"]);
                            hd.TenNV = reader["HoTen"].ToString();

                            if (!reader.IsDBNull(reader.GetOrdinal("MaNV")))
                                hd.MaNV = Convert.ToInt64(reader["MaNV"]);

                            hd.NgayBan = Convert.ToDateTime(reader["NgayBan"]);
                            hd.TongTien = Convert.ToDecimal(reader["TongTien"]);
                            hd.Thue = Convert.ToDecimal(reader["Thue"]);

                            if (!reader.IsDBNull(reader.GetOrdinal("MaKM")))
                                hd.MaKM = Convert.ToInt64(reader["MaKM"]);

                            list.Add(hd);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
                    throw new Exception("Lỗi DAL khi tải Hóa đơn.", ex);
                }
            }

            return list;
        }
        public bool InsertHoaDon(HoaDonDTO hd)
        {
            string query = @"
                INSERT INTO HoaDon (MaHD, MaKH, MaNV, NgayBan, TongTien, Thue) 
                VALUES (@MaHD, @MaKH, @MaNV, @NgayBan, @TongTien, @Thue)";

            using (SqlConnection conn = GetConnection())

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHD", hd.MaHD);
                cmd.Parameters.AddWithValue("@MaKH", hd.MaKH);
                cmd.Parameters.AddWithValue("@MaNV", hd.MaNV);
                cmd.Parameters.AddWithValue("@NgayBan", hd.NgayBan);
                cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                cmd.Parameters.AddWithValue("@Thue", hd.Thue);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi DAL khi thêm hóa đơn: " + ex.Message, ex);
                }
            }
        }
    }
}
