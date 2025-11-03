using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{
    public class DoanhThuDAL: DBConnect
    {
        public List<DoanhThuDTO> GetDoanhThu7NgayGanNhat()
        {
            List<DoanhThuDTO> list = new List<DoanhThuDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT CONVERT(date, NgayBan) AS NgayBan, SUM(TongTien) AS TongDoanhThu
                    FROM HoaDon
                    WHERE NgayBan >= DATEADD(DAY, -6, CAST(GETDATE() AS date))
                    GROUP BY CONVERT(date, NgayBan)
                    ORDER BY NgayBan ASC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DateTime ngay = Convert.ToDateTime(dr["NgayBan"]);
                    double tong = Convert.ToDouble(dr["TongDoanhThu"]);

                    list.Add(new DoanhThuDTO
                    {
                        TenMocThoiGian = ngay.ToString("dd/MM"),
                        TongDoanhThu = tong
                    });
                }
                dr.Close();
            }
            return list;
        }

        public List<DoanhThuDTO> GetDoanhThu4ThangGanNhat()
        {
            List<DoanhThuDTO> list = new List<DoanhThuDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT YEAR(NgayBan) AS Nam, MONTH(NgayBan) AS Thang, SUM(TongTien) AS TongDoanhThu
                    FROM HoaDon
                    WHERE NgayBan >= DATEADD(MONTH, -3, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))
                    GROUP BY YEAR(NgayBan), MONTH(NgayBan)
                    ORDER BY YEAR(NgayBan), MONTH(NgayBan) ASC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int thang = Convert.ToInt32(dr["Thang"]);
                    int nam = Convert.ToInt32(dr["Nam"]);
                    double tong = Convert.ToDouble(dr["TongDoanhThu"]);

                    list.Add(new DoanhThuDTO
                    {
                        TenMocThoiGian = $"{thang}/{nam}",
                        TongDoanhThu = tong
                    });
                }
                dr.Close();
            }
            return list;
        }

        public List<DoanhThuDTO> GetDoanhThu4NamGanNhat()
        {
            List<DoanhThuDTO> list = new List<DoanhThuDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT YEAR(NgayBan) AS Nam, SUM(TongTien) AS TongDoanhThu
                    FROM HoaDon
                    WHERE YEAR(NgayBan) >= YEAR(GETDATE()) - 3
                    GROUP BY YEAR(NgayBan)
                    ORDER BY YEAR(NgayBan) ASC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int nam = Convert.ToInt32(dr["Nam"]);
                    double tong = Convert.ToDouble(dr["TongDoanhThu"]);

                    list.Add(new DoanhThuDTO
                    {
                        TenMocThoiGian = nam.ToString(),
                        TongDoanhThu = tong
                    });
                }
                dr.Close();
            }
            return list;
        }


        // --- Thống kê số lượng bán theo loại ---
        public List<DoanhThuDTO> GetSoLuongBanTheoLoai(DateTime tuNgay, DateTime denNgay)
        {
            List<DoanhThuDTO> list = new List<DoanhThuDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT l.TenLoai AS TenDanhMuc, SUM(ct.Soluong) AS SoLuongBan
                    FROM HoaDon hd
                    JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                    JOIN Giay g ON g.MaGiay = ct.MaGiay
                    JOIN Loai l ON l.MaLoai = g.MaLoai
                    WHERE hd.NgayBan BETWEEN @TuNgay AND @DenNgay
                    GROUP BY l.TenLoai
                    ORDER BY SoLuongBan DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new DoanhThuDTO
                    {
                        TenDanhMuc = dr["TenDanhMuc"].ToString(),
                        SoLuongBan = Convert.ToInt32(dr["SoLuongBan"])
                    });
                }
            }
            return list;
        }

        // --- Thống kê theo thương hiệu ---
        public List<DoanhThuDTO> GetSoLuongBanTheoThuongHieu(DateTime tuNgay, DateTime denNgay)
        {
            List<DoanhThuDTO> list = new List<DoanhThuDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT th.TenThuongHieu AS TenDanhMuc, SUM(ct.Soluong) AS SoLuongBan
                    FROM HoaDon hd
                    JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                    JOIN Giay g ON g.MaGiay = ct.MaGiay
                    JOIN ThuongHieu th ON th.MaThuongHieu = g.MaThuongHieu
                    WHERE hd.NgayBan BETWEEN @TuNgay AND @DenNgay
                    GROUP BY th.TenThuongHieu
                    ORDER BY SoLuongBan DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new DoanhThuDTO
                    {
                        TenDanhMuc = dr["TenDanhMuc"].ToString(),
                        SoLuongBan = Convert.ToInt32(dr["SoLuongBan"])
                    });
                }
            }
            return list;
        }

        // --- Thống kê theo màu sắc ---
        public List<DoanhThuDTO> GetSoLuongBanTheoMau(DateTime tuNgay, DateTime denNgay)
        {
            List<DoanhThuDTO> list = new List<DoanhThuDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT m.TenMau AS TenDanhMuc, SUM(ct.Soluong) AS SoLuongBan
                    FROM HoaDon hd
                    JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                    JOIN Giay g ON g.MaGiay = ct.MaGiay
                    JOIN MauSac m ON m.MaMau = g.MaMau
                    WHERE hd.NgayBan BETWEEN @TuNgay AND @DenNgay
                    GROUP BY m.TenMau
                    ORDER BY SoLuongBan DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new DoanhThuDTO
                    {
                        TenDanhMuc = dr["TenDanhMuc"].ToString(),
                        SoLuongBan = Convert.ToInt32(dr["SoLuongBan"])
                    });
                }
            }
            return list;
        }


        public List<(string TenNV, DateTime Ngay, decimal DoanhThu)> GetDoanhThuNhanVienTheoKhoangNgay(DateTime tuNgay, DateTime denNgay, string TenNV)
        {
            var list = new List<(string, DateTime, decimal)>();

            // Đảm bảo ngày hợp lệ trong SQL Server
            if (tuNgay < new DateTime(1753, 1, 1))
                tuNgay = new DateTime(1753, 1, 1);
            if (denNgay < new DateTime(1753, 1, 1))
                denNgay = DateTime.Now;

            string query = @"
        SELECT 
            nv.HoTen, 
            CONVERT(date, hd.NgayBan) AS Ngay, 
            SUM(hd.TongTien) AS DoanhThu
        FROM HoaDon hd
        INNER JOIN TaiKhoan nv ON hd.MaNV = nv.MaTK
        WHERE 
            hd.NgayBan BETWEEN @TuNgay AND @DenNgay
            AND nv.Role = 'BANHANG'
            AND (@TenNV = '' OR nv.HoTen = @TenNV)
        GROUP BY 
            nv.HoTen, CONVERT(date, hd.NgayBan)
        ORDER BY 
            Ngay ASC;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = tuNgay.Date;
                cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = denNgay.Date;
                cmd.Parameters.AddWithValue("@TenNV", string.IsNullOrEmpty(TenNV) ? "" : TenNV); // 🔹 Thêm dòng này

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string tenNV = dr["HoTen"].ToString();
                        DateTime ngay = dr.GetDateTime(dr.GetOrdinal("Ngay"));
                        decimal doanhThu = dr.IsDBNull(dr.GetOrdinal("DoanhThu")) ? 0 : dr.GetDecimal(dr.GetOrdinal("DoanhThu"));

                        list.Add((tenNV, ngay, doanhThu));
                    }
                }
            }

            return list;
        }





        public DataTable GetThongKeTheoNgay(int soNgay)
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT * 
            FROM HoaDon
            WHERE NgayTao >= DATEADD(DAY, -@SoNgay, GETDATE())";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoNgay", soNgay);
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
