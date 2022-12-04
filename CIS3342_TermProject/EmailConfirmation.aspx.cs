using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS3342_TermProject
{
    public partial class EmailConfirmation : System.Web.UI.Page
    {
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            email = Request.QueryString["Email"];
            if (email == null || email.Equals(""))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                welcomeMessage.InnerText = email + ", thank you for confirming your account.";
            }
        }
    }
}