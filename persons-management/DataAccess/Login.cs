using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace persons_management.DataAccess
{
    public class Login
    {
        private SqlConnection sqlConnection = Libs.Config.Connect();

        public bool LoginMethod(Models.User param)
        {
            bool success = false;
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string sqlQuery = "SELECT * FROM [User] WHERE [Username] = @Username AND [Password] = @Password";
            sqlParameter.Add(new SqlParameter("@Username", param.Username));
            sqlParameter.Add(new SqlParameter("@Password", param.Password));
            DataTable dataTable = new DataTable();
            dataTable = SqlHelper.ExecuteDataset(sqlConnection, CommandType.Text, sqlQuery, sqlParameter.ToArray()).Tables[0];
            if (dataTable.Rows.Count > 0)
                success = true;
            return success;
        }
    }
}