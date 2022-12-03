using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS3342_TermProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrors.Text = "";
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            lblErrors.Text = "An email has been sent containing your password.";
        }

        protected void btnForgotUsername_Click(object sender, EventArgs e)
        {
            lblErrors.Text = "An email has been sent containing your username.";
        }
    }
}