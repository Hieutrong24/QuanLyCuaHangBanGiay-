using DTO_QL_BanGiay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{
    public class LuongNhanVienDAL:DBConnect
    {
        public List<LuongNhanVienDTO> GetAll()
        {
            List<LuongNhanVienDTO> listLuong = new List<LuongNhanVienDTO>();
            string query = "SELECT * FROM LUONGNHANVIEN, TAIKHOAN WHERE MaNV = MaTK";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LuongNhanVienDTO luongNhanVien = new LuongNhanVienDTO
                        {
                            MaNV = Convert.ToInt64(reader["MaNV"]),
                            Thang = reader["Thang"].ToString(),
                            LuongCoBan = Convert.ToDecimal(reader["LuongCoBan"]),
                            Role = reader["Role"].ToString(),
                            HoTen = reader["HoTen"].ToString(),

                        };

                        listLuong.Add(luongNhanVien);
                    }
                }
            }

            return listLuong;
        }

        public List<LuongNhanVienDTO> LocTheoTen(string name)
        {
            string query = "SELECT * FROM LUONGNHANVIEN, TAIKHOAN WHERE MaNV = MaTK AND HoTen = @HoTen";
            List<LuongNhanVienDTO> listLuong = new List<LuongNhanVienDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", name);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            LuongNhanVienDTO luongNhanVien = new LuongNhanVienDTO
                            {
                                MaNV = Convert.ToInt64(reader["MaNV"]),
                                Thang = reader["Thang"].ToString(),
                                LuongCoBan = Convert.ToDecimal(reader["LuongCoBan"]),
                                Role = reader["Role"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                            };
                           listLuong.Add(luongNhanVien);
                    }
                        
                    }
                }
            return listLuong;

        }

        public List<LuongNhanVienDTO> LocTheoNhomQuyen(string nhomQuyen)
        {
            string query = "SELECT * FROM LUONGNHANVIEN, TAIKHOAN WHERE MaNV = MaTK AND Role = @Role";
            List<LuongNhanVienDTO> listLuong = new List<LuongNhanVienDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Role", nhomQuyen);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LuongNhanVienDTO luongNhanVien = new LuongNhanVienDTO
                            {
                                MaNV = Convert.ToInt64(reader["MaNV"]),
                                Thang = reader["Thang"].ToString(),
                                LuongCoBan = Convert.ToDecimal(reader["LuongCoBan"]),
                                Role = reader["Role"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                            };
                            listLuong.Add(luongNhanVien);
                        }
                    }
                }
            return listLuong;

        }



    }
}
