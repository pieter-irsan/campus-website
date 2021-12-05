using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace persons_management.DataAccess
{
    public class MajorCRUD
    {
        private SqlConnection sqlConnection = Libs.Config.Connect();

        public List<Models.Major> List()
        {
            List<Models.Major> listMajor = new List<Models.Major>();
            string sqlQuery = "SELECT * FROM Major";
            DataTable dataTable = new DataTable();
            dataTable = SqlHelper.ExecuteDataset(sqlConnection, CommandType.Text, sqlQuery).Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                Models.Major major = new Models.Major
                {
                    MajorID = Convert.ToInt32(row["MajorID"]),
                    MajorCode = Convert.ToString(row["MajorCode"]),
                    MajorName = Convert.ToString(row["MajorName"]),
                    Program = Convert.ToString(row["Program"])
                };

                listMajor.Add(major);
            }
            return listMajor;
        }
        public Models.Major Get(int id)
        {
            Models.Major major = new Models.Major();
            string sqlQuery = "SELECT * FROM Major";
            DataTable dataTable = new DataTable();
            dataTable = SqlHelper.ExecuteDataset(sqlConnection, CommandType.Text, sqlQuery).Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                major.MajorID = Convert.ToInt32(row["MajorID"]);
                major.MajorCode = Convert.ToString(row["MajorCode"]);
                major.MajorName = Convert.ToString(row["MajorName"]);
                major.Program = Convert.ToString(row["Program"]);
            }
            return major;
        }
        public bool Insert(Models.Major param)
        {
            bool success = false;
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string sqlQuery = "INSERT INTO [dbo].[Major] ([MajorCode],[MajorName],[Program]) VALUES(@MajorCode,@MajorName,@Program)";
            sqlParameter.Add(new SqlParameter("@MajorCode", param.MajorCode));
            sqlParameter.Add(new SqlParameter("@MajorName", param.MajorName));
            sqlParameter.Add(new SqlParameter("@Program", param.Program));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameter.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
        public bool Update(Models.Major param)
        {
            bool success = false;
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string sqlQuery = "UPDATE [dbo].[Major] SET [MajorCode] = @MajorCode, [MajorName] = @MajorName, [Program] = @Program WHERE MajorID = @MajorID";
            sqlParameter.Add(new SqlParameter("@MajorID", param.MajorID));
            sqlParameter.Add(new SqlParameter("@MajorCode", param.MajorCode));
            sqlParameter.Add(new SqlParameter("@MajorName", param.MajorName));
            sqlParameter.Add(new SqlParameter("@Program", param.Program));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameter.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
        public bool Delete(int id)
        {
            bool success = false;
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            string sqlQuery = "DELETE FROM [dbo].[Major] WHERE MajorID = @MajorID";
            sqlParameters.Add(new SqlParameter("@MajorID", id));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameters.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
    }
}