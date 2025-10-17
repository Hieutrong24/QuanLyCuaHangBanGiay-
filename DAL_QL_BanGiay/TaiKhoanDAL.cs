using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{
    public class TaiKhoanDAL: DBConnect
    {
        public TaiKhoanDTO DangNhap(string tenDN, string matKhau)
        {
            string query = "SELECT * FROM TAIKHOAN WHERE HoTen = @TenDN AND MatKhau = @MatKhau";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TenDN", tenDN);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TaiKhoanDTO
                        {
                            TenDN = reader["HoTen"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                }
            }
            return null; // sai thông tin
        }

    }
}
