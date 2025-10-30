using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{
    public class ChuongTrinhKhuyenMaiDAL: DBConnect
    {
        public List<ChuongTrinhKhuyenMaiDTO> GetAll()
        {
            List<ChuongTrinhKhuyenMaiDTO> list = new List<ChuongTrinhKhuyenMaiDTO>();
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM ChuongTrinhKhuyenMai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ChuongTrinhKhuyenMaiDTO ctkm = new ChuongTrinhKhuyenMaiDTO
                                {
                                    MaCTKM = reader["MaKM"] != DBNull.Value ? Convert.ToInt64(reader["MaKM"]) : 0,  
                                    TenCTKM = reader["TenChuongTrinh"]?.ToString(),
                                    LoaiCTKM = reader["LoaiChuongTrinh"]?.ToString(),
                                    DieuKien = reader["DieuKien"]?.ToString(),
                                    NgayBatDau = reader["NgayBatDau"] != DBNull.Value ? Convert.ToDateTime(reader["NgayBatDau"]) : DateTime.MinValue,
                                    NgayKetThuc = reader["NgayKetThuc"] != DBNull.Value ? Convert.ToDateTime(reader["NgayKetThuc"]) : DateTime.MinValue,
                                    MucGiamGia = reader["Giam"] != DBNull.Value ? Convert.ToDecimal(reader["Giam"]) : 0
                                };

                                list.Add(ctkm);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Lỗi DAL khi lấy danh sách CTKM: " + ex.Message);
                    }
                }
            }
            return list;
        }


        public bool Insert(ChuongTrinhKhuyenMaiDTO ctkm)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    INSERT INTO ChuongTrinhKhuyenMai (TenCTKM, LoaiCTKM, DieuKien, NgayBatDau, NgayKetThuc, MucGiamGia)
                    VALUES (@TenCTKM, @LoaiCTKM, @DieuKien, @NgayBatDau, @NgayKetThuc, @MucGiamGia)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenCTKM", ctkm.TenCTKM);
                    cmd.Parameters.AddWithValue("@LoaiCTKM", ctkm.LoaiCTKM);
                    cmd.Parameters.AddWithValue("@DieuKien", ctkm.DieuKien);
                    cmd.Parameters.AddWithValue("@NgayBatDau", ctkm.NgayBatDau);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", ctkm.NgayKetThuc);
                    cmd.Parameters.AddWithValue("@MucGiamGia", ctkm.MucGiamGia);
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Ghi log lỗi nếu cần
                        Console.WriteLine("Lỗi DAL khi thêm chương trình khuyến mãi: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool Delete(long maCTKM)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "DELETE FROM ChuongTrinhKhuyenMai WHERE MaCTKM = @MaCTKM";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCTKM", maCTKM);
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Ghi log lỗi nếu cần
                        Console.WriteLine("Lỗi DAL khi xóa chương trình khuyến mãi: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool Update(ChuongTrinhKhuyenMaiDTO ctkm)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
                    UPDATE ChuongTrinhKhuyenMai
                    SET TenCTKM = @TenCTKM,
                        LoaiCTKM = @LoaiCTKM,
                        DieuKien = @DieuKien,
                        NgayBatDau = @NgayBatDau,
                        NgayKetThuc = @NgayKetThuc,
                        MucGiamGia = @MucGiamGia
                    WHERE MaCTKM = @MaCTKM";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenCTKM", ctkm.TenCTKM);
                    cmd.Parameters.AddWithValue("@LoaiCTKM", ctkm.LoaiCTKM);
                    cmd.Parameters.AddWithValue("@DieuKien", ctkm.DieuKien);
                    cmd.Parameters.AddWithValue("@NgayBatDau", ctkm.NgayBatDau);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", ctkm.NgayKetThuc);
                    cmd.Parameters.AddWithValue("@MucGiamGia", ctkm.MucGiamGia);
                    cmd.Parameters.AddWithValue("@MaCTKM", ctkm.MaCTKM);
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Ghi log lỗi nếu cần
                        Console.WriteLine("Lỗi DAL khi cập nhật chương trình khuyến mãi: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public List<ChuongTrinhKhuyenMaiDTO> SearchByName(string keyword)
        {
            using (SqlConnection conn = GetConnection())
            {
                List<ChuongTrinhKhuyenMaiDTO> list = new List<ChuongTrinhKhuyenMaiDTO>();
                string query = "SELECT * FROM ChuongTrinhKhuyenMai WHERE TenCTKM LIKE @Keyword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ChuongTrinhKhuyenMaiDTO ctkm = new ChuongTrinhKhuyenMaiDTO
                                {
                                    MaCTKM = reader.GetInt64(0),
                                    TenCTKM = reader.GetString(1),
                                    LoaiCTKM = reader.GetString(2),
                                    DieuKien = reader.GetString(3),
                                    NgayBatDau = reader.GetDateTime(4),
                                    NgayKetThuc = reader.GetDateTime(5),
                                    MucGiamGia = reader.GetDecimal(6)
                                };
                                list.Add(ctkm);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Ghi log lỗi nếu cần
                        Console.WriteLine("Lỗi DAL khi tìm kiếm chương trình khuyến mãi: " + ex.Message);
                    }
                }
                return list;
            }
        }
    }
}
