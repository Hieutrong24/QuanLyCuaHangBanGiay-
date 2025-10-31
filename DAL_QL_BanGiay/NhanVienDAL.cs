using DTO_QL_BanGiay;
using Snowflake.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{
    public class NhanVienDAL:DBConnect
    {
        // Lấy toàn bộ danh sách nhân viên
        public List<NhanVienDTO> GetAll()
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            string query = "SELECT * FROM TaiKhoan WHERE Role != 'Admin'";


            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NhanVienDTO nv = new NhanVienDTO
                        {
                            MaTK = Convert.ToInt64(reader["MaTK"]),
                            HoTen = reader["HoTen"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DienThoai = reader["DienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            Role = reader["Role"].ToString(),
                            NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                            TrangThai = Convert.ToBoolean(reader["TrangThai"]),
                            ImagePath = reader["Avatar"] != DBNull.Value ? reader["Avatar"].ToString() : null,
                            QRCode = reader["QRCode"] != DBNull.Value ? (byte[])reader["QRCode"] : null
                        };
                        list.Add(nv);
                    }
                }
            }
            return list;
        }
        // Lấy nhân viên theo mã
        public NhanVienDTO GetByMaNV(long maNV)
        {
            NhanVienDTO nv = null;
            string query = "SELECT * FROM TaiKhoan WHERE MaTK = @MaTK";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTK", maNV);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nv = new NhanVienDTO
                        {
                            MaTK = Convert.ToInt64(reader["MaTK"]),
                            HoTen = reader["HoTen"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DienThoai = reader["DienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            Role = reader["Role"].ToString(),
                            NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                            TrangThai = Convert.ToBoolean(reader["TrangThai"]),
                            ImagePath = reader["Avatar"] != DBNull.Value ? reader["Avatar"].ToString() : null,
                            QRCode = reader["QRCode"] != DBNull.Value ? (byte[])reader["QRCode"] : null
                        };
                    }
                }
            }
            return nv;
        }

        // Thêm nhân viên mới
        public bool Insert(NhanVienDTO nv)
        {
            var worker = new IdWorker(1, 1);
            long newId = worker.NextId();
            string query = @"INSERT INTO TaiKhoan (MaTK, HoTen, GioiTinh, NgaySinh, DienThoai, Email, DiaChi, MatKhau, Role, NgayTao, TrangThai, Avatar)
                         VALUES (@MaTK, @HoTen, @GioiTinh, @NgaySinh, @DienThoai, @Email, @DiaChi, @MatKhau, @Role, @NgayTao, @TrangThai, @Avatar)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTK", newId);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
                cmd.Parameters.AddWithValue("@Email", nv.Email);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@MatKhau", nv.MatKhau);
                cmd.Parameters.AddWithValue("@Role", nv.Role);
                cmd.Parameters.AddWithValue("@NgayTao", nv.NgayTao);
                cmd.Parameters.AddWithValue("@TrangThai", nv.TrangThai);
                cmd.Parameters.AddWithValue("@Avatar", nv.ImagePath ?? (object)DBNull.Value);

                System.Windows.Forms.MessageBox.Show(nv.ImagePath);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public long GetMaNhanVienMoiNhat()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 MaTK FROM TaiKhoan ORDER BY MaTK DESC", conn);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt64(result) : 0;
            }
        }


        public void CapNhatQRCode(long maNV, byte[] qrCode)
        {
            string query = "UPDATE TaiKhoan SET QRCode = @QRCode WHERE MaTK = @MaTK";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@QRCode", qrCode ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MaTK", maNV);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public byte[] GetQRCodeByMaNV(int maNV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT QRCode FROM TaiKhoan WHERE MaTK = @MaTK", conn);
                cmd.Parameters.AddWithValue("@MaTK", maNV);

                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    return (byte[])result;
                }
                return null;
            }
        }


        // Cập nhật nhân viên
        public bool Update(NhanVienDTO nv)
        {
            string query = @"UPDATE TaiKhoan SET 
                        HoTen = @HoTen,
                        GioiTinh = @GioiTinh,
                        NgaySinh = @NgaySinh,
                        DienThoai = @DienThoai,
                        Email = @Email,
                        DiaChi = @DiaChi,
                        MatKhau = @MatKhau,
                        Role = @Role,
                        TrangThai = @TrangThai
                        WHERE MaTK = @MaTK";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTK", nv.MaTK);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
                cmd.Parameters.AddWithValue("@Email", nv.Email);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@MatKhau", nv.MatKhau);
                cmd.Parameters.AddWithValue("@Role", nv.Role);
                cmd.Parameters.AddWithValue("@TrangThai", nv.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa nhân viên theo mã
        public bool Delete(long maTK)
        {
            string query = "DELETE FROM TaiKhoan WHERE MaTK = @MaTK";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTK", maTK);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Tìm kiếm nhân viên theo tên hoặc email
        public List<NhanVienDTO> Search(string keyword)
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            string query = "SELECT * FROM TaiKhoan WHERE HoTen LIKE @kw OR Email LIKE @kw";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NhanVienDTO nv = new NhanVienDTO
                    {
                        MaTK = Convert.ToInt64(reader["MaTK"]),
                        HoTen = reader["HoTen"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        NgaySinh = reader["NgaySinh"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["NgaySinh"])
                                    : DateTime.MinValue,
                        DienThoai = reader["DienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        Role = reader["Role"].ToString(),
                        NgayTao = reader["NgayTao"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["NgayTao"])
                                    : DateTime.Now,
                        TrangThai = reader["TrangThai"] != DBNull.Value
                                    && Convert.ToBoolean(reader["TrangThai"])  
                    };
                    list.Add(nv);
                }
            }

            return list;
        }


        public bool UpdateRole(NhanVienDTO nv)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE NhanVien SET Role = @Role WHERE MaNV = @MaNV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Role", nv.Role);
                        cmd.Parameters.AddWithValue("@MaNV", nv.MaTK);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi DAL.UpdateRole: " + ex.Message);
            }
        }

        public bool UpdateTrangThai(NhanVienDTO nv)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE TaiKhoan SET TrangThai = @TrangThai WHERE MaTK = @MaNV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    { 
                        cmd.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = nv.TrangThai ? 1 : 0;

                       
                        cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nv.MaTK;

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi DAL.UpdateTrangThai: " + ex.Message);
            }
        }



    }
}
