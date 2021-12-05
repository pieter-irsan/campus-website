using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace persons_management.DataAccess
{
    public class CourseCRUD
    {
        private SqlConnection sqlConnection = Libs.Config.Connect();

        public List<Models.Course> List()
        {
            List<Models.Course> listCourse = new List<Models.Course>();
            string sqlQuery = "SELECT * FROM Course";
            DataTable dataTable = new DataTable();
            dataTable = SqlHelper.ExecuteDataset(sqlConnection, CommandType.Text, sqlQuery).Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                Models.Course course = new Models.Course
                {
                    CourseID = Convert.ToInt32(row["CourseID"]),
                    CourseCode = Convert.ToString(row["CourseCode"]),
                    CourseName = Convert.ToString(row["CourseName"]),
                    Credit = Convert.ToInt32(row["Credit"])
                };

                listCourse.Add(course);
            }
            return listCourse;
        }
        public Models.Course Get(int id)
        {
            Models.Course course = new Models.Course();
            string sqlQuery = "SELECT * FROM Course";
            DataTable dataTable = new DataTable();
            dataTable = SqlHelper.ExecuteDataset(sqlConnection, CommandType.Text, sqlQuery).Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                course.CourseID = Convert.ToInt32(row["CourseID"]);
                course.CourseCode = Convert.ToString(row["CourseCode"]);
                course.CourseName = Convert.ToString(row["CourseName"]);
                course.Credit = Convert.ToInt32(row["Credit"]);
            }
            return course;
        }
        public bool Insert(Models.Course param)
        {
            bool success = false;
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string sqlQuery = "INSERT INTO [dbo].[Course] ([CourseCode],[CourseName],[Credit]) VALUES(@CourseCode,@CourseName,@Credit)";
            sqlParameter.Add(new SqlParameter("@CourseCode", param.CourseCode));
            sqlParameter.Add(new SqlParameter("@CourseName", param.CourseName));
            sqlParameter.Add(new SqlParameter("@Credit", param.Credit));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameter.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
        public bool Update(Models.Course param)
        {
            bool success = false;
            List<SqlParameter> sqlParameter = new List<SqlParameter>();
            string sqlQuery = "UPDATE [dbo].[Course] SET [CourseCode] = @CourseCode, [CourseName] = @CourseName, [Credit] = @Credit WHERE CourseID = @CourseID";
            sqlParameter.Add(new SqlParameter("@CourseID", param.CourseID));
            sqlParameter.Add(new SqlParameter("@CourseCode", param.CourseCode));
            sqlParameter.Add(new SqlParameter("@CourseName", param.CourseName));
            sqlParameter.Add(new SqlParameter("@Credit", param.Credit));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameter.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
        public bool Delete(int id)
        {
            bool success = false;
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            string sqlQuery = "DELETE FROM [dbo].[Course] WHERE CourseID = @CourseID";
            sqlParameters.Add(new SqlParameter("@CourseID", id));
            int affected = SqlHelper.ExecuteNonQuery(sqlConnection, CommandType.Text, sqlQuery, sqlParameters.ToArray());
            if (affected > 0)
                success = true;
            return success;
        }
    }
}