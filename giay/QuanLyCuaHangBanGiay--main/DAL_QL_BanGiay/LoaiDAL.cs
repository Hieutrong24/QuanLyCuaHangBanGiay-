using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL_QL_BanGiay
{
    public class LoaiDAL : DBConnect
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
                // Lấy mã lớn nhất + 1
                string sql = @"
            DECLARE @newMa BIGINT;
            SELECT @newMa = ISNULL(MAX(MaLoai), 0) + 1 FROM Loai;
            INSERT INTO Loai (MaLoai, TenLoai) VALUES (@newMa, @ten)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", tenLoai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public bool InsertLoai(LoaiDTO loai)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sql = @"
            DECLARE @newMa BIGINT;
            SELECT @newMa = ISNULL(MAX(MaLoai), 0) + 1 FROM Loai;
            INSERT INTO Loai (MaLoai, TenLoai) VALUES (@newMa, @ten)";

                SqlCommand cmd = new SqlCommand(sql, conn);
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
        public bool DeleteLoai(long maLoai)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // Xóa ChiTietPhieuNhap có Giày thuộc loại này
                    string sqlDeleteCTPN = @"
                DELETE FROM ChiTietPhieuNhap
                WHERE MaGiay IN (SELECT MaGiay FROM Giay WHERE MaLoai = @maLoai)";
                    using (SqlCommand cmd = new SqlCommand(sqlDeleteCTPN, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@maLoai", maLoai);
                        cmd.ExecuteNonQuery();
                    }

                    // Xóa các Phiếu nhập không còn chi tiết nào
                    string sqlDeleteEmptyPN = @"
                DELETE FROM PhieuNhap 
                WHERE MaPN NOT IN (SELECT DISTINCT MaPN FROM ChiTietPhieuNhap)";
                    using (SqlCommand cmd = new SqlCommand(sqlDeleteEmptyPN, conn, tran))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Xóa các Giày thuộc loại này
                    string sqlDeleteGiay = "DELETE FROM Giay WHERE MaLoai = @maLoai";
                    using (SqlCommand cmd = new SqlCommand(sqlDeleteGiay, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@maLoai", maLoai);
                        cmd.ExecuteNonQuery();
                    }

                    // Cuối cùng xóa loại
                    string sqlDeleteLoai = "DELETE FROM Loai WHERE MaLoai = @maLoai";
                    using (SqlCommand cmd = new SqlCommand(sqlDeleteLoai, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@maLoai", maLoai);
                        int rows = cmd.ExecuteNonQuery();

                        tran.Commit();

                        if (rows > 0)
                        {
                            MessageBox.Show("✅ Đã xóa loại giày và toàn bộ dữ liệu liên quan!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("⚠️ Không tìm thấy loại giày để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("❌ Lỗi khi xóa loại giày: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }



    }

}
