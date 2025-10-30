using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{
    public class ChiTietKMDAL: DBConnect
    {
        public List<ChiTietKhuyenMaiDTO> GetAll()
        {
            List<ChiTietKhuyenMaiDTO> lstCTKM = new List<ChiTietKhuyenMaiDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM CHITIETKHUYENMAI", conn))
            {
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChiTietKhuyenMaiDTO ctkm = new ChiTietKhuyenMaiDTO
                            {
                                MaCTKM = reader.GetInt64(0),
                                MaGiay = reader.GetInt64(1),
                                TiLeKM = reader.GetDecimal(2)
                            };
                            lstCTKM.Add(ctkm);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy danh sách ChiTietKhuyenMai: " + ex.Message);
                }
            }

            return lstCTKM;
        }

        public bool TimCTKMTheoMa(long MaCTKM)
        {
            string query = "SELECT MaKM FROM ChiTietChuongTrinhKhuyenMai WHERE MaKM = @MaCTKM";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaCTKM", MaCTKM);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();  
                    return result != null;  
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi tìm CTKM theo mã: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public long KiemTraDemMa(long MaCTKM)
        {
            string query = "SELECT COUNT(*) FROM ChiTietChuongTrinhKhuyenMai WHERE MaKM = @MaCTKM";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaCTKM", MaCTKM);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar(); 
                    return Convert.ToInt64(result);  
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi đếm CTKM theo mã: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }



    }
}
