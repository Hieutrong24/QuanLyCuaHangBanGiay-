using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{


public class ThongKeSoLuongGiayDAL : DBConnect
    {
        public List<BaoCaoSoLuongGiayDTO> LayTongSoLuongGiayTheoNgay(DateTime ngayCanLoc)
        {
            List<BaoCaoSoLuongGiayDTO> listBaoCao = new List<BaoCaoSoLuongGiayDTO>();

            string sql = @"
        SELECT
    H.NgayBan AS Ngay,
    CT.MaGiay,
    G.TenGiay,
    CT.GiaBan,
    SUM(CT.SoLuong) AS TongSoLuongBan
FROM
    ChiTietHoaDon CT
INNER JOIN
    HoaDon H ON CT.MaHD = H.MaHD
INNER JOIN
    Giay G ON CT.MaGiay = G.MaGiay
WHERE 
       H.NgayBan = @NgayLoc 
GROUP BY
    H.NgayBan,
    CT.MaGiay,
    G.TenGiay,
    CT.GiaBan
ORDER BY
    TongSoLuongBan DESC;
    ";

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NgayLoc", ngayCanLoc.Date);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBaoCao.Add(new BaoCaoSoLuongGiayDTO
                            {
                                Ngay = reader.GetDateTime(0),
                                MaGiay = reader.GetInt64(1),
                                TenGiay = reader.GetString(2),
                                DonGia = reader.GetDecimal(3),       // <--- Đọc DonGia (vị trí 3)
                                TongSoLuongBan = reader.GetInt32(4)
                            });
                        }
                    }
                }
            }
            return listBaoCao;
        }
    }
}
