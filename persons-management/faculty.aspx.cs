using System;
using System.Web.UI.WebControls;

namespace persons_management
{
    public partial class faculty : System.Web.UI.Page
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
            Models.Faculty instructor = new Models.Faculty
            {
                FacultyName = txtFacultyName.Text,
                Position = txtPosition.Text,
                Status = txtStatus.Text
            };

            DataAccess.FacultyCRUD facultyCRUD = new DataAccess.FacultyCRUD();

            if (Request.QueryString["id"] == null)
            {
                if (facultyCRUD.Insert(instructor))
                {
                    Response.Write("<script>alert('Insert Success!'); window.location.href='faculty.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Insert Failed!'); window.location.href='faculty.aspx';</script>");
                }
            }
            else
            {
                instructor.FacultyID = Convert.ToInt32(Request.QueryString["id"]);
                if (facultyCRUD.Update(instructor))
                {
                    Response.Write("<script>alert('Update Success!'); window.location.href='faculty.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Update Failed!'); window.location.href='faculty.aspx';</script>");
                }
            }
            BindData();
        }

        public void BindData()
        {
            DataAccess.FacultyCRUD facultyCRUD = new DataAccess.FacultyCRUD();
            tblFaculty.DataSource = facultyCRUD.List();
            tblFaculty.DataBind();
        }

        protected void tblFaculty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "update")
            {
                Response.Redirect("faculty.aspx?id=" + Convert.ToString(e.CommandArgument));
            }
            else if (e.CommandName == "delete")
            {
                DataAccess.FacultyCRUD facultyCRUD = new DataAccess.FacultyCRUD();
                int id = Convert.ToInt32(e.CommandArgument);
                if (facultyCRUD.Delete(id))
                {
                    Response.Write("<script>alert('Delete Success!'); window.location.href='faculty.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Delete Failed!'); window.location.href='faculty.aspx';</script>");
                }
            }
        }

        protected void tblFaculty_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}