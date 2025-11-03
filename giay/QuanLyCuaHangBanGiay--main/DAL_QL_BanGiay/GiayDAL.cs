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
        // Lưu ý: DBConnect giả sử cung cấp:
        // - protected string connectionString;
        // - protected SqlConnection GetConnection();

        public DataTable LoadGiaySapXepTang()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT MaGiay, TenGiay, DonGia, SoLuong, Images, TenMau
                FROM Giay a
                JOIN MauSac s ON a.MaMau = s.MaMau
                ORDER BY DonGia ASC";  // Sắp xếp tăng dần theo giá

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public bool CapNhatSoLuong(long maGiay, int soLuongTru)
        {
            string query = "UPDATE Giay SET SoLuong = SoLuong - @SoLuongTru WHERE MaGiay = @MaGiay";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@SoLuongTru", soLuongTru);
                cmd.Parameters.AddWithValue("@MaGiay", maGiay);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public DataTable LoadGiayTheoMa(long maGiay)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT MaGiay, TenGiay, DonGia, SoLuong, Images, TenMau
                FROM Giay a
                JOIN MauSac s ON a.MaMau = s.MaMau
                WHERE a.MaGiay = @MaGiay";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaGiay", maGiay);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable LoadGiaySapXepGiam()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT MaGiay, TenGiay, DonGia, SoLuong, Images, TenMau
                FROM Giay a
                JOIN MauSac s ON a.MaMau = s.MaMau
                ORDER BY DonGia DESC";  // Sắp xếp giảm dần theo giá

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable LoadTatCaGiay()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT MaGiay, TenGiay, DonGia, SoLuong, Images, TenMau
                FROM Giay a
                JOIN MauSac s ON a.MaMau = s.MaMau
                ORDER BY MaGiay";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
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
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Keyword", "%" + (tenGiayKeyword ?? string.Empty) + "%");
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetSizesByTenGiay(string tenGiay)
        {
            DataTable dt = new DataTable();
            // Lấy các size duy nhất và sắp xếp chúng
            string query = "SELECT DISTINCT Size FROM Giay WHERE TenGiay = @TenGiay ORDER BY Size";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TenGiay", tenGiay ?? string.Empty);
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
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@MaGiay", maGiay);
                    cmd.Parameters.AddWithValue("@NgayHienTai", today);
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        if (decimal.TryParse(result.ToString(), out decimal giam))
                        {
                            phanTramGiam = giam;
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

        // Khoa
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
                da.SelectCommand.Parameters.AddWithValue("@ten", "%" + (tenGiay ?? string.Empty) + "%");
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
                da.SelectCommand.Parameters.AddWithValue("@tenLoai", tenLoai ?? string.Empty);
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
                string sql = @"INSERT INTO Giay(MaGiay, TenGiay, SoLuong, DonGia, Size, DoiTuongSD, MaLoai, Images, MaXX, MaMau, MaThuongHieu) 
                               VALUES(@id, @ten, @sl, @gia, @size, @dt, @ml, @img, @MaXX, @MaMau, @MaThuongHieu)";

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

        // Lấy next id khi không có transaction (conn phải đã open khi gọi)
        private long GetNextMaGiay(SqlConnection conn)
        {
            string query = "SELECT ISNULL(MAX(MaGiay), 0) + 1 FROM Giay";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();
                return Convert.ToInt64(result);
            }
        }

        public bool UpdateGiay(GiayDTO g)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE Giay
                       SET TenGiay = @TenGiay, SoLuong = @SoLuong, DonGia = @DonGia,
                           Size = @Size, DoiTuongSD = @DoiTuongSD, MaLoai = @MaLoai,
                           MaMau = @MaMau, MaThuongHieu = @MaThuongHieu, MaXX = @MaXX
                       WHERE MaGiay = @MaGiay";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenGiay", g.TenGiay);
                    cmd.Parameters.AddWithValue("@SoLuong", g.SoLuong);
                    cmd.Parameters.AddWithValue("@DonGia", g.DonGia);
                    cmd.Parameters.AddWithValue("@Size", g.Size);
                    cmd.Parameters.AddWithValue("@DoiTuongSD", g.DoiTuongSD);
                    cmd.Parameters.AddWithValue("@MaLoai", g.MaLoai);
                    cmd.Parameters.AddWithValue("@MaMau", g.MaMau);
                    cmd.Parameters.AddWithValue("@MaThuongHieu", g.MaThuongHieu);
                    cmd.Parameters.AddWithValue("@MaXX", g.MaXX);
                    cmd.Parameters.AddWithValue("@MaGiay", g.IdGiay);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public void Delete(long id)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // 1️⃣ Xóa chi tiết phiếu nhập có MaGiay này
                    string sqlCTPN = "DELETE FROM ChiTietPhieuNhap WHERE MaGiay = @id";
                    using (SqlCommand cmd = new SqlCommand(sqlCTPN, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    string sqlDeleteEmptyPN = @"
                DELETE FROM PhieuNhap 
                WHERE MaPN NOT IN (SELECT DISTINCT MaPN FROM ChiTietPhieuNhap)";
                    using (SqlCommand cmd = new SqlCommand(sqlDeleteEmptyPN, conn, tran))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    string sqlGiay = "DELETE FROM Giay WHERE MaGiay = @id";
                    using (SqlCommand cmd = new SqlCommand(sqlGiay, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show(" Xóa giày và dữ liệu liên quan thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show(" Lỗi khi xóa giày: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    long nextMaNV = 1;   // bạn nên lấy MaNV thực tế từ context
                    long nextMaNCC = 1;  // bạn nên lấy MaNCC thực tế từ context
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

        public int CapNhatAnhGiay(long maGiay, string fileAnh)
        {
            string query = "UPDATE Giay SET Images = @image WHERE MaGiay = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@image", (object)fileAnh ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", maGiay);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DemGiayTheoLoai(long maLoai)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Giay WHERE MaLoai = @ma", conn))
            {
                cmd.Parameters.AddWithValue("@ma", maLoai);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public List<GiayDTO> GetAllGiayADKM()
        {
            List<GiayDTO> lstGiay = new List<GiayDTO>();
            string sql = @"SELECT g.MaGiay, g.TenGiay, g.Size, m.TenMau, t.TenThuongHieu, l.TenLoai 
                           FROM Giay g 
                           INNER JOIN MauSac m ON g.MaMau = m.MaMau 
                           INNER JOIN Loai l ON g.MaLoai = l.MaLoai 
                           INNER JOIN ThuongHieu t ON g.MaThuongHieu = t.MaThuongHieu";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GiayDTO giay = new GiayDTO
                            {
                                IdGiay = reader.IsDBNull(0) ? 0 : Convert.ToInt64(reader[0]),
                                TenGiay = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                Size = reader.IsDBNull(2) ? 0 : Convert.ToInt32(reader[2]),
                                TenMau = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                TenThuongHieu = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                                TenLoai = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
                            };
                            lstGiay.Add(giay);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy danh sách Giày: " + ex.Message);
                }
            }
            return lstGiay;
        }
        // Dùng khi có transaction
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
