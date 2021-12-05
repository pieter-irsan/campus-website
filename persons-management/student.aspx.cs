using System;
using System.Web.UI.WebControls;

namespace persons_management
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                string id = Request.QueryString["id"];
                if (id != null)
                {
                    operationH4.InnerText = "Updating data with ID: " + id;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Models.Student student = new Models.Student
            {
                StudentName = txtStudentName.Text,
                SchoolOrigin = txtSchoolOrigin.Text,
                Major = txtMajor.Text
            };

            DataAccess.StudentCRUD studentCRUD = new DataAccess.StudentCRUD();

            if (Request.QueryString["id"] == null)
            {
                if (studentCRUD.Insert(student))
                {
                    Response.Write("<script>alert('Insert Success!'); window.location.href='student.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Insert Failed!'); window.location.href='student.aspx';</script>");
                }
            }
            else
            {
                student.StudentID = Convert.ToInt32(Request.QueryString["id"]);
                if (studentCRUD.Update(student))
                {
                    Response.Write("<script>alert('Update Success!'); window.location.href='student.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Update Failed!'); window.location.href='student.aspx';</script>");
                }
            }
            BindData();
        }

        public void BindData()
        {
            DataAccess.StudentCRUD studentCRUD = new DataAccess.StudentCRUD();
            tblStudent.DataSource = studentCRUD.List();
            tblStudent.DataBind();
        }

        protected void tblStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "update")
            {
                Response.Redirect("student.aspx?id=" + Convert.ToString(e.CommandArgument));
            }
            else if (e.CommandName == "delete")
            {
                DataAccess.StudentCRUD studentCRUD = new DataAccess.StudentCRUD();
                int id = Convert.ToInt32(e.CommandArgument);
                if (studentCRUD.Delete(id))
                {
                    Response.Write("<script>alert('Delete Success!'); window.location.href='student.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Delete Failed!'); window.location.href='student.aspx';</script>");
                }
            }
        }

        protected void tblStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}