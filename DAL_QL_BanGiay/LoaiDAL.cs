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

    }

}
