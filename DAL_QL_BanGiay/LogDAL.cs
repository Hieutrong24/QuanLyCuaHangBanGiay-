using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QL_BanGiay
{
    public class LogDAL: DBConnect
    {
        public void SaveLog(string user, string action, string detail)
        {
            ///string query = @"INSERT INTO LogActions (Username, Action, Detail, Time)
                    // VALUES (@user, @action, @detail, GETDATE())";

           // using (var conn = new SqlConnection(connectionString))
            //using (var cmd = new SqlCommand(query, conn))
            //{
                //cmd.Parameters.AddWithValue("@user", user);
                //cmd.Parameters.AddWithValue("@action", action);
                //cmd.Parameters.AddWithValue("@detail", detail);
                //conn.Open();
                //cmd.ExecuteNonQuery();
           // }
        }

        public LogDTO GetLastLog()
        {
            string query = "SELECT TOP 1 * FROM LogActions ORDER BY LogID DESC";
            LogDTO log = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    log = new LogDTO
                    {
                        LogID = Convert.ToInt32(reader["LogID"]),
                        Username = reader["Username"].ToString(),
                        Action = reader["Action"].ToString(),
                        Detail = reader["Detail"].ToString(),
                        Time = Convert.ToDateTime(reader["Time"]),
                        IpAddress = reader["IpAddress"] == DBNull.Value ? "" : reader["IpAddress"].ToString()
                    };
                }
            }
            return log;
        }

    }
}
