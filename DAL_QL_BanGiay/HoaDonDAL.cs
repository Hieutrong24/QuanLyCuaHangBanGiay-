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
        public int GetMaxMaHD()
        {
            int peak = 0;
            string query = "SELECT MAX(MaHD) FROM HoaDon";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        // Chuyển đổi kiểu dữ liệu an toàn
                        peak = Convert.ToInt32(result);
                    }
                    else
                    {
                        // Nếu bảng rỗng, khởi tạo mã đầu tiên là 1
                        peak = 1;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi DAL: Không thể lấy MaHD lớn nhất. " + ex.Message, ex);
                }
            }

            return peak;
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
