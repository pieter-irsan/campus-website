using System.Data.SqlClient;

namespace persons_management.Libs
{
    public class Config
    {
        public static SqlConnection Connect()
        {
            SqlConnection sqlConnection;
            sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=campus_db;Integrated Security=True;");
            return sqlConnection;
        }
    }
}