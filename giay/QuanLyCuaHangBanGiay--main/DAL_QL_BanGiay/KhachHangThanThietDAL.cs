using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QL_BanGiay;

namespace DAL_QL_BanGiay
{
    public class KhachHangThanThietDAL :DBConnect
    {

    
        public List<KhachHangThanThietDTO> GetAllKhachHangThanThiet()
        {
            List<KhachHangThanThietDTO> list = new List<KhachHangThanThietDTO>();
            string query = "SELECT MaKH, NgayThamGia, TongDiem, HangThanhVien, NgayCapNhat, TrangThai FROM KhachHangThanThiet";

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
                            KhachHangThanThietDTO kh = new KhachHangThanThietDTO();

                            // Đọc dữ liệu từ SQL Reader
                            kh.MaKH = reader.GetInt64(reader.GetOrdinal("MaKH")); // BIGINT -> GetInt64
                            kh.NgayThamGia = reader.GetDateTime(reader.GetOrdinal("NgayThamGia")); // DATE -> GetDateTime
                            kh.TongDiem = reader.GetInt32(reader.GetOrdinal("TongDiem")); // INT -> GetInt32
                            kh.HangThanhVien = reader.GetString(reader.GetOrdinal("HangThanhVien")); // NVARCHAR -> GetString
                            kh.NgayCapNhat = reader.GetDateTime(reader.GetOrdinal("NgayCapNhat"));
                            kh.TrangThai = reader.GetInt32(reader.GetOrdinal("TrangThai")); // BIT -> GetBoolean

                            list.Add(kh);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi DAL khi tải danh sách Khách Hàng Thân Thiết: " + ex.Message);
                    throw new Exception("Lỗi DAL khi tải Khách hàng thân thiết.", ex);
                }
            }
            return list;
        }

        public bool InsertKhachHangThanThiet(KhachHangThanThietDTO khachHang)
        {
            string query = @"
                INSERT INTO KhachHangThanThiet (MaKH, NgayThamGia, TongDiem, HangThanhVien, NgayCapNhat, TrangThai)
                VALUES (@MaKH, @NgayThamGia, @TongDiem, @HangThanhVien, @NgayCapNhat, @TrangThai)";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Sử dụng tham số để chống SQL Injection
                cmd.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                cmd.Parameters.AddWithValue("@NgayThamGia", khachHang.NgayThamGia);
                cmd.Parameters.AddWithValue("@TongDiem", khachHang.TongDiem);
                cmd.Parameters.AddWithValue("@HangThanhVien", khachHang.HangThanhVien);
                cmd.Parameters.AddWithValue("@NgayCapNhat", khachHang.NgayCapNhat);
                cmd.Parameters.AddWithValue("@TrangThai", khachHang.TrangThai);

                try
                {
                    conn.Open();
                    // ExecuteNonQuery trả về số lượng hàng bị ảnh hưởng
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi trùng lặp MaKH (Primary Key Violation) hoặc lỗi khác
                    if (ex.Number == 2627) // Số lỗi cho Primary Key violation
                    {
                        throw new Exception("Mã Khách Hàng này đã tồn tại trong danh sách thân thiết.");
                    }
                    throw new Exception("Lỗi DAL khi thêm Khách hàng thân thiết: " + ex.Message, ex);
                }
            }
        }
        public bool CapNhatDiem(KhachHangThanThietDTO kh)
        {
            string query = @"
                UPDATE KhachHangThanThiet
                SET 
                    TongDiem = TongDiem + @DiemCong,
                    NgayCapNhat = @NgayCapNhat
                WHERE MaKH = @MaKH";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@DiemCong", kh.TongDiem); // số điểm cộng thêm (ví dụ 100)
                cmd.Parameters.AddWithValue("@NgayCapNhat", kh.NgayCapNhat);
                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi DAL: Không thể cập nhật điểm khách hàng. " + ex.Message);
                }
            }
        }
        public KhachHangThanThietDTO GetKhachHangByMaKH(long maKH)
        {
            KhachHangThanThietDTO kh = null;
            string query = "SELECT TongDiem, HangThanhVien FROM KhachHangThanThiet WHERE MaKH = @MaKH AND TrangThai = 1";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Sử dụng tham số để chống SQL Injection
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            kh = new KhachHangThanThietDTO();

                            // Vì chỉ SELECT TongDiem và HangThanhVien nên ta chỉ đọc 2 trường này
                            kh.MaKH = maKH; // Gán lại MaKH
                            kh.TongDiem = reader.GetInt32(reader.GetOrdinal("TongDiem"));

                            // Xử lý trường có thể NULL nếu cần
                            kh.HangThanhVien = reader.GetString(reader.GetOrdinal("HangThanhVien"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi DAL khi tải thông tin Khách Hàng: " + ex.Message);
                    throw new Exception("Lỗi DAL khi tải thông tin Khách hàng.", ex);
                }
            }
            return kh;
        }
    }
}
