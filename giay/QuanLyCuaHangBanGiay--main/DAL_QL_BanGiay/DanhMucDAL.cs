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
    public class DanhMucDAL:DBConnect
    {
        //Danh sach danh muc
        public List<DanhMucDTO> LayDSDanhMuc()
        {
            var list = new List<DanhMucDTO>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MaLoai, TenLoai FROM Loai";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var item = new DanhMucDTO
                            {
                                MaDanhMuc = dr["MaLoai"] != DBNull.Value
                                               ? Convert.ToInt64(dr["MaLoai"])
                                               : 0,
                                TenDanhMuc = dr["TenLoai"] != DBNull.Value
                                                ? dr["TenLoai"].ToString()
                                                : string.Empty
                            };
                            list.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);

            }

            return list;
        }
    }
}
