using System;
using System.Web.UI.WebControls;

namespace persons_management
{
    public partial class course : System.Web.UI.Page
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
            Models.Course course = new Models.Course
            {
                CourseCode = txtCourseCode.Text,
                CourseName = txtCourseName.Text,
                Credit = Convert.ToInt32(txtCredit.Text)
            };

            DataAccess.CourseCRUD courseCRUD = new DataAccess.CourseCRUD();

            if (Request.QueryString["id"] == null)
            {
                if (courseCRUD.Insert(course))
                {
                    Response.Write("<script>alert('Insert Success!'); window.location.href='course.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Insert Failed!'); window.location.href='course.aspx';</script>");
                }

            }
            else
            {
                course.CourseID = Convert.ToInt32(Request.QueryString["id"]);
                if (courseCRUD.Update(course))
                {
                    Response.Write("<script>alert('Update Success!'); window.location.href='course.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Update Failed!'); window.location.href='course.aspx';</script>");
                }
            }
            BindData();
        }



        public void BindData()
        {
            DataAccess.CourseCRUD courseCRUD = new DataAccess.CourseCRUD();
            tblCourse.DataSource = courseCRUD.List();
            tblCourse.DataBind();
        }

        protected void tblCourse_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "update")
            {
                Response.Redirect("course.aspx?id=" + Convert.ToString(e.CommandArgument));
            }
            else if (e.CommandName == "delete")
            {
                DataAccess.CourseCRUD courseCRUD = new DataAccess.CourseCRUD();
                int id = Convert.ToInt32(e.CommandArgument);
                if (courseCRUD.Delete(id))
                {
                    Response.Write("<script>alert('Delete Success!'); window.location.href='course.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Delete Failed!'); window.location.href='course.aspx';</script>");
                }
            }
        }

        protected void tblCourse_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}