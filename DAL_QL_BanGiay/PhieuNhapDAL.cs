using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{
    public class PhieuNhapDAL: DBConnect
    {
        public List<PhieuNhapDTO> GetAllPhieuNhap()
        {
            List<PhieuNhapDTO> list = new List<PhieuNhapDTO>();
            try
            {
                string sql = @"SELECT MaPN, MaNCC, MaNV, NgayNhap, TongTien
                       FROM PhieuNhap
                       ORDER BY NgayNhap DESC";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PhieuNhapDTO pn = new PhieuNhapDTO
                            {
                                MaPN = Convert.ToInt64(reader["MaPN"]),
                                MaNCC = Convert.ToInt64(reader["MaNCC"]),
                                MaNV = Convert.ToInt64(reader["MaNV"]),
                                NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                                TongTien = Convert.ToDecimal(reader["TongTien"])
                            };
                            list.Add(pn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi DAL: " + ex.Message);
            }

            return list;
        }

        public List<PhieuNhapDTO> LayDanhSachPhieuNhap()
        {
            List<PhieuNhapDTO> list = new List<PhieuNhapDTO>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MaPN, MaNCC, MaNV, NgayNhap, TongTien FROM PhieuNhap ORDER BY NgayNhap DESC";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        PhieuNhapDTO pn = new PhieuNhapDTO
                        {
                            MaPN = Convert.ToInt64(dr["MaPN"]),
                            MaNCC = Convert.ToInt64(dr["MaNCC"]),
                            MaNV = Convert.ToInt64(dr["MaNV"]),
                            NgayNhap = Convert.ToDateTime(dr["NgayNhap"]),
                            TongTien = Convert.ToDecimal(dr["TongTien"])
                        };

                        list.Add(pn);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi DAL (PhieuNhapDAL): " + ex.Message);
            }

            return list;
        }

        
    }
}
