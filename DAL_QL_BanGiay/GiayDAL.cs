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
                long nextId = GetNextMaGiay(conn);
                string sql = @"INSERT INTO Giay(MaGiay, TenGiay, SoLuong, DonGia, Size, DoiTuongSD, MaLoai, Images, MaXX, MaMau, MaThuongHieu) VALUES(@id, @ten, @sl, @gia, @size, @dt, @ml, @img, @MaXX, @MaMau, @MaThuongHieu)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", nextId);
                    cmd.Parameters.AddWithValue("@ten", (object)g.TenGiay ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@sl", g.SoLuong);
                    cmd.Parameters.AddWithValue("@gia", g.DonGia);
                    cmd.Parameters.AddWithValue("@size", g.Size);
                    cmd.Parameters.AddWithValue("@dt", (object)g.DoiTuongSD ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ml", g.MaLoai);
                    cmd.Parameters.AddWithValue("@img", (object)g.Images ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaXX", g.MaXX);
                    cmd.Parameters.AddWithValue("@MaMau", g.MaMau);
                    cmd.Parameters.AddWithValue("@MaThuongHieu", g.MaThuongHieu);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private long GetNextMaGiay(SqlConnection conn)
        {
            string query = "SELECT ISNULL(MAX(MaGiay), 0) + 1 FROM Giay";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();
                return Convert.ToInt64(result);
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

        public void Delete(long id)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Giay WHERE MaGiay = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        public List<GiayDTO> LayDanhSachGiay()
        {
            List<GiayDTO> dsGiay = new List<GiayDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT MaGiay, TenGiay, MaLoai, DonGia, SoLuong FROM Giay";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GiayDTO g = new GiayDTO
                    {
                        IdGiay = Convert.ToInt64(reader["MaGiay"]),
                        TenGiay = reader["TenGiay"].ToString(),
                        MaLoai = Convert.ToInt64(reader["MaLoai"]),
                        DonGia = Convert.ToDecimal(reader["DonGia"]),
                        SoLuong = Convert.ToInt32(reader["SoLuong"])
                    };
                    dsGiay.Add(g);
                }

                reader.Close();
            }

            return dsGiay;
        }
        public int CapNhatAnhGiay(long maGiay, string fileAnh)
        {
            string query = "UPDATE Giay SET Images = @image WHERE MaGiay = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@image", fileAnh);
                cmd.Parameters.AddWithValue("@id", maGiay);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public void ThemGiayVaChiTietPhieuNhap(GiayDTO g)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // ===== 1. Thêm Giày =====
                    long nextMaGiay = GetNextMaGiay(conn, tran);
                    string sqlGiay = @"INSERT INTO Giay(MaGiay, TenGiay, SoLuong, DonGia, Size, DoiTuongSD, 
                                MaLoai, Images, MaXX, MaMau, MaThuongHieu)
                               VALUES(@id, @ten, @sl, @gia, @size, @dt, @ml, @img, @MaXX, @MaMau, @MaThuongHieu)";
                    using (SqlCommand cmd = new SqlCommand(sqlGiay, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", nextMaGiay);
                        cmd.Parameters.AddWithValue("@ten", (object)g.TenGiay ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@sl", g.SoLuong);
                        cmd.Parameters.AddWithValue("@gia", g.DonGia);
                        cmd.Parameters.AddWithValue("@size", g.Size);
                        cmd.Parameters.AddWithValue("@dt", (object)g.DoiTuongSD ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ml", g.MaLoai);
                        cmd.Parameters.AddWithValue("@img", (object)g.Images ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaXX", g.MaXX);
                        cmd.Parameters.AddWithValue("@MaMau", g.MaMau);
                        cmd.Parameters.AddWithValue("@MaThuongHieu", g.MaThuongHieu);
                        cmd.ExecuteNonQuery();
                    }

                    // ===== 2. Thêm Phiếu Nhập =====
                    long nextMaPN = GetNextMaPN(conn, tran);
                    long nextMaNV = 1;
                    long nextMaNCC = 1;
                    decimal tongTien = g.SoLuong * g.DonGia;

                    string sqlPN = @"INSERT INTO PhieuNhap(MaPN, MaNV, MaNCC, NgayNhap, TongTien)
                             VALUES(@maPN, @maNV, @maNCC, @ngay, @tongTien)";
                    using (SqlCommand cmd = new SqlCommand(sqlPN, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@maPN", nextMaPN);
                        cmd.Parameters.AddWithValue("@maNV", nextMaNV);
                        cmd.Parameters.AddWithValue("@maNCC", nextMaNCC);
                        cmd.Parameters.AddWithValue("@ngay", DateTime.Now);
                        cmd.Parameters.AddWithValue("@tongTien", tongTien);
                        cmd.ExecuteNonQuery();
                    }

                    // ===== 3. Thêm Chi Tiết Phiếu Nhập =====
                    string sqlCT = @"INSERT INTO ChiTietPhieuNhap(MaPN, MaGiay, SoLuong, GiaNhap)
                             VALUES (@maPN, @maGiay, @sl, @gia)";
                    using (SqlCommand cmd = new SqlCommand(sqlCT, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@maPN", nextMaPN);
                        cmd.Parameters.AddWithValue("@maGiay", nextMaGiay);
                        cmd.Parameters.AddWithValue("@sl", g.SoLuong);
                        cmd.Parameters.AddWithValue("@gia", g.DonGia);
                        cmd.ExecuteNonQuery();
                    }

                    // ===== 4. Commit giao dịch =====
                    tran.Commit();
                    MessageBox.Show("✅ Thêm giày, phiếu nhập và chi tiết phiếu nhập thành công!");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("❌ Lỗi khi thêm giày và phiếu nhập: " + ex.Message);
                }
            }
        }
        private long GetNextMaGiay(SqlConnection conn, SqlTransaction tran)
        {
            string query = "SELECT ISNULL(MAX(MaGiay), 0) + 1 FROM Giay";
            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                return Convert.ToInt64(cmd.ExecuteScalar());
            }
        }

        private long GetNextMaPN(SqlConnection conn, SqlTransaction tran)
        {
            string query = "SELECT ISNULL(MAX(MaPN), 0) + 1 FROM PhieuNhap";
            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                return Convert.ToInt64(cmd.ExecuteScalar());
            }
        }
    }

}
