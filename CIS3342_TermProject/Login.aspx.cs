using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectLibrary;

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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblErrors.Text = "";
            if(tboxUsername.Equals(""))
            {
                lblErrors.Text += "*You must enter your username.";
            }
            if(tboxPassword.Equals(""))
            {
                lblErrors.Text += "*You must enter your password.";
            }

            if(lblErrors.Text.Equals(""))
            {
                WebRequest request = WebRequest.Create("https://localhost:44382/api/user/GetPasswordFromUsername/" + tboxUsername.Text);
                WebResponse response = request.GetResponse();
                Stream ds = response.GetResponseStream();
                StreamReader reader = new StreamReader(ds);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                JavaScriptSerializer js = new JavaScriptSerializer();

                string pw = js.Deserialize<string>(data);

                string encryptedPw = Encryption.EncryptPassword(tboxPassword.Text);

                if(pw.Equals(""))
                {
                    lblErrors.Text = "*Your username is incorrect.";
                    return;
                }

                if(!pw.Equals(encryptedPw))
                {
                    lblErrors.Text = "*Your password is incorrect.";
                    return;
                }
                else
                {
                    //log in 
                    lblErrors.Text = "Passwords match, proceed to login.";
                    Response.Redirect("Posts.aspx?Username=" + tboxUsername.Text);
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterAccount.aspx");
        }
    }
}