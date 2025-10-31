using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{
    public class LoaiDAL:DBConnect
    {


        public List<LoaiDTO> LayDanhSachLoai()
        {
            List<LoaiDTO> dsLoai = new List<LoaiDTO>();

            string sql = "SELECT MaLoai, TenLoai FROM Loai";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LoaiDTO loai = new LoaiDTO
                    {
                        MaLoai = Convert.ToInt32(reader["MaLoai"]),
                        TenLoai = reader["TenLoai"].ToString()
                    };
                    dsLoai.Add(loai);
                }

                reader.Close();
            }

            return dsLoai;
        }

        public bool InsertLoai(string tenLoai)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = "INSERT INTO Loai (TenLoai) VALUES (@ten)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", tenLoai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0; // Trả về true nếu thêm thành công
            }
        }
        public bool InsertLoai(LoaiDTO loai)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = "INSERT INTO Loai (MaLoai, TenLoai) VALUES (@ma, @ten)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", loai.MaLoai);
                cmd.Parameters.AddWithValue("@ten", loai.TenLoai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // ✅ Cập nhật tên loại
        public bool UpdateLoai(long maLoai, string tenMoi)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = "UPDATE Loai SET TenLoai = @ten WHERE MaLoai = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", tenMoi);
                cmd.Parameters.AddWithValue("@id", maLoai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // ✅ Xóa loại khỏi CSDL
        public bool DeleteLoai(long maLoai)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = "DELETE FROM Loai WHERE MaLoai = @ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maLoai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

    }

}
