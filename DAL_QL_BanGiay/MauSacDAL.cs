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
    public class MauSacDAL:DBConnect
    {
        //Danh sach mau sac
        public List<MauSacDTO> LayDSMauSac()
        {
            var list = new List<MauSacDTO>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MaMau, TenMau FROM MauSac";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var item = new MauSacDTO
                            {
                                MaMau = dr["MaMau"] != DBNull.Value
                                               ? Convert.ToInt64(dr["MaMau"])
                                               : 0,
                                TenMau = dr["TenMau"] != DBNull.Value
                                                ? dr["TenMau"].ToString()
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
