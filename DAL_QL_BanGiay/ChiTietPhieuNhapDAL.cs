using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QL_BanGiay
{
    public class ChiTietPhieuNhapDAL : DBConnect
    {
        private readonly GiayDAL dal = new GiayDAL();


        public List<ChiTietPhieuNhapDTO> LayDanhSachChiTietPhieuNhap()
        {
            List<ChiTietPhieuNhapDTO> ds = new List<ChiTietPhieuNhapDTO>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string query = "SELECT * FROM ChiTietPhieuNhap";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ChiTietPhieuNhapDTO ct = new ChiTietPhieuNhapDTO
                            {
                                MaPN = Convert.ToInt64(dr["MaPhieuNhap"]),
                                MaGiay = Convert.ToInt64(dr["MaGiay"]),
                                SoLuong = Convert.ToInt32(dr["SoLuong"]),
                                GiaNhap = Convert.ToDecimal(dr["DonGiaNhap"])
                            };
                            ds.Add(ct);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chi tiết phiếu nhập: " + ex.Message);
            }

            return ds;
        }



    }
}
