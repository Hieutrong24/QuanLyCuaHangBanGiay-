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
    public class XuatXuDAL:DBConnect
    {
        //Danh sach xuat xu
        public List<XuatXuDTO> LayDSXuatXu()
        {
            var list = new List<XuatXuDTO>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MaXX, TenNuoc FROM XuatXu";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var item = new XuatXuDTO
                            {
                                MaXX = dr["MaXX"] != DBNull.Value
                                               ? Convert.ToInt64(dr["MaXX"])
                                               : 0,
                                TenXX = dr["TenNuoc"] != DBNull.Value
                                                ? dr["TenNuoc"].ToString()
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
