using System;

namespace persons_management
{
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Models.User user = new Models.User
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            DataAccess.Login login = new DataAccess.Login();
            if (login.LoginMethod(user))
            {
                Session["user"] = txtUsername.Text;
                Response.Write("<script>alert('Login Success!'); window.location.href='student.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('Wrong Username or Password!'); window.location.href='login.aspx';</script>");
            }
        }

        //public static string session
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["user"] == null)
        //            return string.Empty;
        //        else
        //            return (string)HttpContext.Current.Session["user"];
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["user"] = value;
        //    }
        //}
    }
}