using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using DTO_QL_BanGiay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Snowflake;
using Snowflake.Net;
namespace DAL_QL_BanGiay
{
    public class ThuongHieuDAL:DBConnect
    {
        //Danh sach thuong hieu
        public List<ThuongHieuDTO> LayDSThuongHieu()
        {
            var list = new List<ThuongHieuDTO>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MaThuongHieu, TenThuongHieu FROM ThuongHieu";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var item = new ThuongHieuDTO
                            {
                                MaThuongHieu = dr["MaThuongHieu"] != DBNull.Value
                                               ? Convert.ToInt64(dr["MaThuongHieu"])
                                               : 0,
                                TenThuongHieu = dr["TenThuongHieu"] != DBNull.Value
                                                ? dr["TenThuongHieu"].ToString()
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
