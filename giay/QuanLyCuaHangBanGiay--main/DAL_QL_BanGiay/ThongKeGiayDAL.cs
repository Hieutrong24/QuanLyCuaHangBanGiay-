using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{
    public class ThongKeGiayDAL: DBConnect
    {
        public List<ThongKeGiayDTO> LayThongTinGiay(int luaChon)
        {
            List<ThongKeGiayDTO> list = new List<ThongKeGiayDTO>();

            string query = @"
        SELECT 
            g.TenGiay,
            g.DoiTuongSD,
            l.TenLoai,
            th.TenThuongHieu,
            ISNULL(SUM(ct.SoLuong), 0) AS SoLuongBanRa,
            (g.SoLuong - ISNULL(SUM(ct.SoLuong), 0)) AS SoLuongTonKho,
            (ISNULL(SUM((ct.GiaBan - g.DonGia) * ct.SoLuong), 0)) AS LoiNhuan
        FROM Giay g
        LEFT JOIN Loai l ON g.MaLoai = l.MaLoai
        LEFT JOIN ThuongHieu th ON g.MaThuongHieu = th.MaThuongHieu
        LEFT JOIN ChiTietHoaDon ct ON g.MaGiay = ct.MaGiay
        LEFT JOIN HoaDon hd ON ct.MaHD = hd.MaHD
        WHERE (hd.NgayBan >= DATEADD(DAY, -@SoNgay, GETDATE()) OR hd.NgayBan IS NULL)
        GROUP BY g.TenGiay, g.DoiTuongSD, l.TenLoai, th.TenThuongHieu, g.SoLuong, g.DonGia
    ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoNgay", luaChon);  

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ThongKeGiayDTO giay = new ThongKeGiayDTO
                    {
                        TenGiay = dr["TenGiay"].ToString(),
                        DoiTuongSD = dr["DoiTuongSD"].ToString(),
                        TenLoai = dr["TenLoai"].ToString(),
                        TenThuongHieu = dr["TenThuongHieu"].ToString(),
                        SoLuongBanRa = Convert.ToInt32(dr["SoLuongBanRa"]),
                        SoLuongTonKho = Convert.ToInt32(dr["SoLuongTonKho"]),
                        LoiNhuan = Convert.ToDecimal(dr["LoiNhuan"])
                    };
                    list.Add(giay);
                }
            }

            return list;
        }

    }
}
