using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace persons_management.DataAccess
{
    public class StudentCRUD
    {
        private SqlConnection sqlConnection = Libs.Config.Connect();

        public List<Models.Student> List()
        {
            List<Models.Student> listStudent = new List<Models.Student>();
            string sqlQuery = "SELECT * FROM Student";
            DataTable dataTable = new DataTable();
            dataTable = SqlHelper.ExecuteDataset(sqlConnection, CommandType.Text, sqlQuery).Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                Models.Student student = new Models.Student
                {
                    StudentID = Convert.ToInt32(row["StudentID"]),
                    StudentName = Convert.ToString(row["StudentName"]),
                    SchoolOrigin = Convert.ToString(row["SchoolOrigin"]),
                    Major = Convert.ToString(row["Major"])
                };

                listStudent.Add(student);
            }
            return listStudent;
        }
        public Models.Student Get(int id)
        {
            Models.Student student = new Models.Student();
            string sqlQuery = "SELECT * FROM Student";
            DataTable dataTable = new DataTable();
            dataTable = SqlHelper.ExecuteDataset(sqlConnection, CommandType.Text, sqlQuery).Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                student.StudentID = Convert.ToInt32(row["StudentID"]);
                student.StudentName = Convert.ToString(row["StudentName"]);
                student.SchoolOrigin = Convert.ToString(row["SchoolOrigin"]);
                student.Major = Convert.ToString(row["Major"]);
            }
            return student;
        }
        public bool Insert(Models.Student param)
        {
            bool success = false;
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string sqlQuery = "INSERT INTO [dbo].[Student] ([StudentName],[SchoolOrigin],[Major]) VALUES(@StudentName,@SchoolOrigin,@Major)";
            sqlParameter.Add(new SqlParameter("@StudentName", param.StudentName));
            sqlParameter.Add(new SqlParameter("@SchoolOrigin", param.SchoolOrigin));
            sqlParameter.Add(new SqlParameter("@Major", param.Major));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameter.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
        public bool Update(Models.Student param)
        {
            bool success = false;
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string sqlQuery = "UPDATE [dbo].[Student] SET [StudentName] = @StudentName, [SchoolOrigin] = @SchoolOrigin, [Major] = @Major WHERE StudentID = @StudentID";
            sqlParameter.Add(new SqlParameter("@StudentID", param.StudentID));
            sqlParameter.Add(new SqlParameter("@StudentName", param.StudentName));
            sqlParameter.Add(new SqlParameter("@SchoolOrigin", param.SchoolOrigin));
            sqlParameter.Add(new SqlParameter("@Major", param.Major));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameter.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
        public bool Delete(int id)
        {
            bool success = false;
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            string sqlQuery = "DELETE FROM [dbo].[Student] WHERE StudentID = @StudentID";
            sqlParameters.Add(new SqlParameter("@StudentID", id));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameters.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
    }
}