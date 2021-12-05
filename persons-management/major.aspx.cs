using System;
using System.Web.UI.WebControls;

namespace persons_management
{
    public partial class major : System.Web.UI.Page
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
            Models.Major program = new Models.Major
            {
                MajorCode = txtMajorCode.Text,
                MajorName = txtMajorName.Text,
                Program = txtProgram.Text
            };

            DataAccess.MajorCRUD majorCRUD = new DataAccess.MajorCRUD();

            if (Request.QueryString["id"] == null)
            {
                if (majorCRUD.Insert(program))
                {
                    Response.Write("<script>alert('Insert Success!'); window.location.href='major.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Insert Failed!'); window.location.href='major.aspx';</script>");
                }
            }
            else
            {
                program.MajorID = Convert.ToInt32(Request.QueryString["id"]);
                if (majorCRUD.Update(program))
                {
                    Response.Write("<script>alert('Update Success!'); window.location.href='major.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Update Failed!'); window.location.href='major.aspx';</script>");
                }
            }
            BindData();
        }

        public void BindData()
        {
            DataAccess.MajorCRUD majorCRUD = new DataAccess.MajorCRUD();
            tblMajor.DataSource = majorCRUD.List();
            tblMajor.DataBind();
        }

        protected void tblMajor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "update")
            {
                Response.Redirect("major.aspx?id=" + Convert.ToString(e.CommandArgument));
            }
            else if (e.CommandName == "delete")
            {
                DataAccess.MajorCRUD majorCRUD = new DataAccess.MajorCRUD();
                int id = Convert.ToInt32(e.CommandArgument);
                if (majorCRUD.Delete(id))
                {
                    Response.Write("<script>alert('Delete Success!'); window.location.href='major.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Delete Failed!'); window.location.href='major.aspx';</script>");
                }
            }
        }

        protected void tblMajor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}