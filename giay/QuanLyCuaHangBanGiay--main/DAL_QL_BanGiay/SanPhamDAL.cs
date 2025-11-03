using DTO_QL_BanGiay;
using Snowflake;
using Snowflake.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace DAL_QL_BanGiay
{
    public class SanPhamDAL : DBConnect
    {
         
        
        public List<SanPhamDTO> GetAll()
        {
            List<SanPhamDTO> list = new List<SanPhamDTO>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM Giay";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                // Xử lý giá trị NULL từ DB
                                long maGiay = dr["MaGiay"] == DBNull.Value ? 0 : Convert.ToInt64(dr["MaGiay"]);
                                string tenGiay = dr["TenGiay"] == DBNull.Value ? "" : dr["TenGiay"].ToString();
                                int soLuong = dr["SoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SoLuong"]);
                                decimal donGia = dr["DonGia"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["DonGia"]);
                                string size = dr["Size"] == DBNull.Value ? "" : dr["Size"].ToString();
                                string doiTuongSD = dr["DoiTuongSD"] == DBNull.Value ? "" : dr["DoiTuongSD"].ToString();
                                string chatLieu = dr["ChatLieu"] == DBNull.Value ? "" : dr["ChatLieu"].ToString();
                                long maLoai = dr["MaLoai"] == DBNull.Value ? 0 : Convert.ToInt64(dr["MaLoai"]);
                                long maXX = dr["MaXX"] == DBNull.Value ? 0 : Convert.ToInt64(dr["MaXX"]);
                                long maMau = dr["MaMau"] == DBNull.Value ? 0 : Convert.ToInt64(dr["MaMau"]);
                                long maThuongHieu = dr["MaThuongHieu"] == DBNull.Value ? 0 : Convert.ToInt64(dr["MaThuongHieu"]);
                                string trangThai = dr["TrangThai"] == DBNull.Value ? "" : dr["TrangThai"].ToString();
                                string hinhAnh = dr["Images"] == DBNull.Value ? "" : dr["Images"].ToString();
                                // Tạo DTO và thêm vào list
                                SanPhamDTO sp = new SanPhamDTO(maGiay, tenGiay, soLuong, donGia, size, doiTuongSD, chatLieu, maLoai, maXX, maMau, maThuongHieu, trangThai,hinhAnh);
                                list.Add(sp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }

            return list;
        }
        

        // Thêm sản phẩm mới
        public bool Insert(SanPhamDTO  sp)
        {
            int rows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var worker = new IdWorker(1, 1);
                    long newId = worker.NextId();
                    string sql = @"INSERT INTO Giay
                               (MaGiay, TenGiay, SoLuong, DonGia, Size, DoiTuongSD, ChatLieu, MaLoai, MaXX, MaMau, MaThuongHieu, Images) 
                               VALUES 
                               (@MaGiay, @TenGiay, @SoLuong, @DonGia, @Size, @DoiTuongSD, @ChatLieu, @MaLoai, @MaXX, @MaMau, @MaThuongHieu, @Images)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaGiay", newId);
                        cmd.Parameters.AddWithValue("@TenGiay", sp.TenGiay);
                        cmd.Parameters.AddWithValue("@SoLuong", sp.SoLuong);
                        cmd.Parameters.AddWithValue("@DonGia", sp.DonGia);
                        cmd.Parameters.AddWithValue("@Size", sp.Size);
                        cmd.Parameters.AddWithValue("@DoiTuongSD", sp.DoiTuongSD);
                        cmd.Parameters.AddWithValue("@ChatLieu", sp.ChatLieu);
                        cmd.Parameters.AddWithValue("@MaLoai", sp.MaLoai);
                        cmd.Parameters.AddWithValue("@MaXX", sp.MaXX);
                        cmd.Parameters.AddWithValue("@MaMau", sp.MaMau);
                        cmd.Parameters.AddWithValue("@MaThuongHieu", sp.MaThuongHieu);
                        cmd.Parameters.AddWithValue("@Images", sp.HinhAnh);
                        System.Windows.Forms.MessageBox.Show(sp.HinhAnh);
                        rows = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }

            return rows > 0;
        }

        //Xoasan pham
        public bool Delete(long maGiay)
        {
            int rows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM Giay WHERE MaGiay = @MaGiay"; // kiểm tra tên cột trong DB

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaGiay", SqlDbType.BigInt).Value = maGiay;
                        rows = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi xoá dữ liệu: " + ex.Message);
            }

            return rows > 0;
        }


        //Dem so luong san pham
        public int DemSoLuongLoai()
        {
            string query = "SELECT COUNT(*) FROM Loai";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        //Tongtonkho 
        public int TongTonKho()
        {
            string query = "SELECT SUM(Soluong) AS TongSoLuong FROM Giay";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar() ;
            }
        }

        //Kiem tra san pham sap het
        public int SanPhamSapHet()
        {
            string query = "SELECT COUNT(*) AS SoLuongNhoHon5 FROM Giay WHERE Soluong < 5";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        //Tong gia tri ton kho
        public double TongGiaTriTonKho()
        {
            string query = "SELECT SUM(DonGia) AS TongDonGia FROM Giay WHERE Soluong > 5";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToDouble(result) : 0.0;
            }
        }

        //Sap xep  tim kiem
        public List<SanPhamDTO> LocTheoHang(long thuongHieu)
        {
            string query = "SELECT * FROM Giay WHERE MaThuongHieu = @MaThuongHieu";
            List<SanPhamDTO> list = new List<SanPhamDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaThuongHieu", thuongHieu);
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new SanPhamDTO
                        {
                            MaGiay = Convert.ToInt64(dr["MaGiay"]),
                            TenGiay = dr["TenGiay"].ToString(),
                            MaThuongHieu = Convert.ToInt64(dr["MaThuongHieu"]),
                            MaMau = Convert.ToInt64(dr["MaMau"]),
                            DonGia = Convert.ToDecimal(dr["DonGia"]),
                            SoLuong = Convert.ToInt32(dr["SoLuong"]),
                            TrangThai = dr["TrangThai"].ToString(),
                            HinhAnh = dr["Images"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        public List<SanPhamDTO> LocTheoMau(long maMau)
        {
            string query = "SELECT * FROM Giay WHERE MaMau = @MaMau";
            List<SanPhamDTO> list = new List<SanPhamDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaMau", maMau);
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new SanPhamDTO
                        {
                            MaGiay = Convert.ToInt64(dr["MaGiay"]),
                            TenGiay = dr["TenGiay"].ToString(),
                            MaThuongHieu = Convert.ToInt64(dr["MaThuongHieu"]),
                            MaMau = Convert.ToInt64(dr["MaMau"]),
                            DonGia = Convert.ToDecimal(dr["DonGia"]),
                            SoLuong = Convert.ToInt32(dr["SoLuong"]),
                            TrangThai = dr["TrangThai"].ToString(),
                            HinhAnh = dr["Images"].ToString()
                        });
                    }
                }
            }

            return list;
        }


        public List<SanPhamDTO> LocTheoGia(string sortOrder) { var list = new List<SanPhamDTO>(); string order = (string.IsNullOrEmpty(sortOrder) || sortOrder.ToUpper() == "ASC") ? "ASC" : "DESC"; string sql = $@"SELECT MaGiay, TenGiay, SoLuong, DonGia, Size, DoiTuongSD, ChatLieu, MaLoai, MaXX, MaMau, MaThuongHieu, TrangThai, Images FROM Giay ORDER BY DonGia {order}"; using (SqlConnection conn = new SqlConnection(connectionString)) using (SqlCommand cmd = new SqlCommand(sql, conn)) { conn.Open(); using (var reader = cmd.ExecuteReader()) { while (reader.Read()) { var sp = new SanPhamDTO(); sp.MaGiay = !reader.IsDBNull(reader.GetOrdinal("MaGiay")) ? reader.GetInt64(reader.GetOrdinal("MaGiay")) : 0; sp.TenGiay = !reader.IsDBNull(reader.GetOrdinal("TenGiay")) ? reader.GetString(reader.GetOrdinal("TenGiay")) : null; sp.SoLuong = !reader.IsDBNull(reader.GetOrdinal("SoLuong")) ? reader.GetInt32(reader.GetOrdinal("SoLuong")) : 0; sp.DonGia = !reader.IsDBNull(reader.GetOrdinal("DonGia")) ? reader.GetDecimal(reader.GetOrdinal("DonGia")) : 0; sp.Size = !reader.IsDBNull(reader.GetOrdinal("Size")) ? reader.GetString(reader.GetOrdinal("Size")) : null; sp.DoiTuongSD = !reader.IsDBNull(reader.GetOrdinal("DoiTuongSD")) ? reader.GetString(reader.GetOrdinal("DoiTuongSD")) : null; sp.ChatLieu = !reader.IsDBNull(reader.GetOrdinal("ChatLieu")) ? reader.GetString(reader.GetOrdinal("ChatLieu")) : null; sp.MaLoai = !reader.IsDBNull(reader.GetOrdinal("MaLoai")) ? reader.GetInt64(reader.GetOrdinal("MaLoai")) : 0; sp.MaXX = !reader.IsDBNull(reader.GetOrdinal("MaXX")) ? reader.GetInt64(reader.GetOrdinal("MaXX")) : 0; sp.MaMau = !reader.IsDBNull(reader.GetOrdinal("MaMau")) ? reader.GetInt64(reader.GetOrdinal("MaMau")) : 0; sp.MaThuongHieu = !reader.IsDBNull(reader.GetOrdinal("MaThuongHieu")) ? reader.GetInt64(reader.GetOrdinal("MaThuongHieu")) : 0; sp.TrangThai = !reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? reader.GetString(reader.GetOrdinal("TrangThai")) : null; sp.HinhAnh = !reader.IsDBNull(reader.GetOrdinal("Images")) ? reader.GetString(reader.GetOrdinal("Images")) : null; list.Add(sp); } } } return list; }



    }
}
