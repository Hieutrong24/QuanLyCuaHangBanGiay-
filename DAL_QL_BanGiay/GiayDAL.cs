using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL_QL_BanGiay
{
    public class GiayDAL : DBConnect
    {





        public DataTable LoadTatCaGiay()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT MaGiay, TenGiay, DonGia, SoLuong, Images, TenMau
                FROM Giay a
                JOIN MauSac s ON a.MaMau = s.MaMau
                ORDER BY MaGiay";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable LoadGiayTheoTen(string tenGiayKeyword)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT MaGiay, TenGiay, DonGia, SoLuong, Images, TenMau
                FROM Giay a
                JOIN MauSac s ON a.MaMau = s.MaMau
                WHERE a.TenGiay LIKE @Keyword 
                ORDER BY MaGiay";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Truyền tham số để tránh lỗi SQL Injection
                    // Thêm ký tự % vào tham số
                    cmd.Parameters.AddWithValue("@Keyword", "%" + tenGiayKeyword + "%");

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable GetSizesByTenGiay(string tenGiay)
        {
            DataTable dt = new DataTable();
            // Lấy các size duy nhất và sắp xếp chúng
            string query = "SELECT DISTINCT Size FROM Giay WHERE TenGiay = @TenGiay ORDER BY Size";

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenGiay", tenGiay);
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        // Ghi log lỗi nếu cần
                        Console.WriteLine("Lỗi DAL khi lấy danh sách size: " + ex.Message);
                    }
                }
            }
            return dt;
        }
        public decimal GetPhanTramGiamHieuLuc(long maGiay)
        {
            decimal phanTramGiam = 0;
            DateTime today = DateTime.Today;

            string query = @"
                SELECT TOP 1 KM.Giam
            FROM ChuongTrinhKhuyenMai KM
        JOIN ChiTietChuongTrinhKhuyenMai CT ON KM.MaKM = CT.MaKM
                WHERE CT.MaGiay = @MaGiay
                  AND @NgayHienTai BETWEEN KM.NgayBatDau AND KM.NgayKetThuc
                ORDER BY KM.Giam DESC";

            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaGiay", maGiay);
                        cmd.Parameters.AddWithValue("@NgayHienTai", today);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            if (decimal.TryParse(result.ToString(), out decimal giam))
                            {
                                phanTramGiam = giam;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi nếu cần
                    Console.WriteLine($"Lỗi DAL khi lấy KM cho giày {maGiay}: {ex.Message}");
                }
            }
            return phanTramGiam;
        }

        //Khoa

        public DataTable GetAll()
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = "SELECT * FROM Giay";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable SearchByName(string tenGiay)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = "SELECT * FROM Giay WHERE TenGiay LIKE @ten";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@ten", "%" + tenGiay + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetByLoai(string tenLoai)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = @"SELECT g.* FROM Giay g
                               JOIN Loai l ON g.MaLoai = l.MaLoai
                               WHERE l.TenLoai = @tenLoai";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@tenLoai", tenLoai);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Insert(GiayDTO g)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO Giay(TenGiay, SoLuong, DonGia, Size, DoiTuongSD, MaLoai)
                               VALUES(@ten, @sl, @gia, @size, @dt, @ml)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", g.TenGiay);
                cmd.Parameters.AddWithValue("@sl", g.SoLuong);
                cmd.Parameters.AddWithValue("@gia", g.DonGia);
                cmd.Parameters.AddWithValue("@size", g.Size);
                cmd.Parameters.AddWithValue("@dt", g.DoiTuongSD);
                cmd.Parameters.AddWithValue("@ml", g.MaLoai);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(GiayDTO g)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE Giay SET TenGiay=@ten, SoLuong=@sl, DonGia=@gia, 
                               Size=@size, DoiTuongSD=@dt, MaLoai=@ml WHERE MaGiay=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", g.IdGiay);
                cmd.Parameters.AddWithValue("@ten", g.TenGiay);
                cmd.Parameters.AddWithValue("@sl", g.SoLuong);
                cmd.Parameters.AddWithValue("@gia", g.DonGia);
                cmd.Parameters.AddWithValue("@size", g.Size);
                cmd.Parameters.AddWithValue("@dt", g.DoiTuongSD);
                cmd.Parameters.AddWithValue("@ml", g.MaLoai);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Giay WHERE MaGiay = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public int CapNhatAnhGiay(int maGiay, string fileAnh)
        {
            string query = "UPDATE Giay SET MaAnh=@maAnh WHERE MaGiay=@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@maAnh", fileAnh);
                cmd.Parameters.AddWithValue("@id", maGiay);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }

}
