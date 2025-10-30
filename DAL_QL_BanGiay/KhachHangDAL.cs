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
    public class KhachHangDAL: DBConnect
    {
        public KhachHangDTO GetFirstCustomer()
        {
            string query = "SELECT TOP 1 * FROM KhachHangThanThiet";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new KhachHangDTO
                    {
                        MaKH = Convert.ToInt64(reader["MaKH"]),
                        NgayThamGia = Convert.ToDateTime(reader["NgayThamGia"]),
                        TongDiem = Convert.ToInt32(reader["TongDiem"]),
                        HangThanhVien = reader["HangThanhVien"].ToString(),
                        NgayCapNhat = Convert.ToDateTime(reader["NgayCapNhat"]),
                        TrangThai = reader["TrangThai"].ToString(),
                        SDT = reader["SDT"].ToString()
                    };
                }
            }
            return null;
        }

        public DataTable GetLichSuMuaHang(long maKH)
        {
            string query = @"SELECT hd.MaHD, hd.NgayBan, hd.TongTien 
                         FROM HoaDon hd 
                         WHERE hd.MaKH = @MaKH";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaKH", maKH);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetSoLanMuaHangTheoThang(long maKH)
        {
            string query = @"SELECT MONTH(NgayBan) AS Thang, COUNT(MaHD) AS SoLanMua
                         FROM HoaDon
                         WHERE MaKH = @MaKH
                         GROUP BY MONTH(NgayBan)
                         ORDER BY Thang";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaKH", maKH);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetTanSuatMuaHang(long maKH)
        {
            string query = @"
                            SELECT NgayBan
                            FROM HoaDon
                            WHERE MaKH = @MaKH
                            ORDER BY NgayBan ASC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaKH", maKH);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Thêm cột "SoNgayCachLanTruoc"
                dt.Columns.Add("SoNgayCachLanTruoc", typeof(double));

                DateTime? lastDate = null;
                foreach (DataRow row in dt.Rows)
                {
                    DateTime current = Convert.ToDateTime(row["NgayBan"]);
                    if (lastDate != null)
                    {
                        double days = (current - lastDate.Value).TotalDays;
                        row["SoNgayCachLanTruoc"] = days;
                    }
                    else
                    {
                        row["SoNgayCachLanTruoc"] = 0;  
                    }
                    lastDate = current;
                }

                return dt;
            }
        }


        public DataTable GetAllKhachHang()
        {
            string query = @"SELECT MaKH, SDT, NgayThamGia, TongDiem, TrangThai 
                     FROM KhachHangThanThiet";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


    }
}
