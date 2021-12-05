using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace persons_management.DataAccess
{
    public class FacultyCRUD
    {
        private SqlConnection sqlConnection = Libs.Config.Connect();

        public List<Models.Faculty> List()
        {
            List<Models.Faculty> listFaculty = new List<Models.Faculty>();
            string sqlQuery = "SELECT * FROM Faculty";
            DataTable dataTable = new DataTable();
            dataTable = SqlHelper.ExecuteDataset(sqlConnection, CommandType.Text, sqlQuery).Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                Models.Faculty instructor = new Models.Faculty
                {
                    FacultyID = Convert.ToInt32(row["FacultyID"]),
                    FacultyName = Convert.ToString(row["FacultyName"]),
                    Position = Convert.ToString(row["Position"]),
                    Status = Convert.ToString(row["Status"])
                };

                listFaculty.Add(instructor);
            }
            return listFaculty;
        }
        public Models.Faculty Get(int id)
        {
            Models.Faculty faculty = new Models.Faculty();
            string sqlQuery = "SELECT * FROM Faculty";
            DataTable dataTable = new DataTable();
            dataTable = SqlHelper.ExecuteDataset(sqlConnection, CommandType.Text, sqlQuery).Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                faculty.FacultyID = Convert.ToInt32(row["FacultyID"]);
                faculty.FacultyName = Convert.ToString(row["FacultyName"]);
                faculty.Position = Convert.ToString(row["Position"]);
                faculty.Status = Convert.ToString(row["Status"]);
            }
            return faculty;
        }
        public bool Insert(Models.Faculty param)
        {
            bool success = false;
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string sqlQuery = "INSERT INTO [dbo].[Faculty] ([FacultyName],[Position],[Status]) VALUES(@FacultyName,@Position,@Status)";
            sqlParameter.Add(new SqlParameter("@FacultyName", param.FacultyName));
            sqlParameter.Add(new SqlParameter("@Position", param.Position));
            sqlParameter.Add(new SqlParameter("@Status", param.Status));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameter.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
        public bool Update(Models.Faculty param)
        {
            bool success = false;
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string sqlQuery = "UPDATE [dbo].[Faculty] SET [FacultyName] = @FacultyName, [Position] = @Position, [Status] = @Status WHERE FacultyID = @FacultyID";
            sqlParameter.Add(new SqlParameter("@FacultyID", param.FacultyID));
            sqlParameter.Add(new SqlParameter("@FacultyName", param.FacultyName));
            sqlParameter.Add(new SqlParameter("@Position", param.Position));
            sqlParameter.Add(new SqlParameter("@Status", param.Status));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameter.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
        public bool Delete(int id)
        {
            bool success = false;
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            string sqlQuery = "DELETE FROM [dbo].[Faculty] WHERE FacultyID = @FacultyID";
            sqlParameters.Add(new SqlParameter("@FacultyID", id));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameters.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
    }
}