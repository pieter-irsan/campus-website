using System;

namespace persons_management
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        public void BindData()
        {
            DataAccess.StudentCRUD studentCRUD = new DataAccess.StudentCRUD();
            tblStudent.DataSource = studentCRUD.List();
            tblStudent.DataBind();

            DataAccess.FacultyCRUD facultyCRUD = new DataAccess.FacultyCRUD();
            tblFaculty.DataSource = facultyCRUD.List();
            tblFaculty.DataBind();

            DataAccess.MajorCRUD majorCRUD = new DataAccess.MajorCRUD();
            tblMajor.DataSource = majorCRUD.List();
            tblMajor.DataBind();

            DataAccess.CourseCRUD courseCRUD = new DataAccess.CourseCRUD();
            tblCourse.DataSource = courseCRUD.List();
            tblCourse.DataBind();
        }
    }
}