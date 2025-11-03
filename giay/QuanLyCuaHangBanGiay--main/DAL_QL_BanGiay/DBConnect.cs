using System.Data.SqlClient;

namespace DAL_QL_BanGiay
{
    public class DBConnect
    {

        protected string connectionString = @"Data Source=DESKTOP-0JDVMNT\KHOADEPTRY;Initial Catalog=QL_BanGiay;Integrated Security=True;Encrypt=False";


        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
     
        }
    }
}
