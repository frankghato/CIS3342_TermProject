using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectClassLibrary;
using TermProjectLibrary;

namespace CIS3342_TermProject
{
    public partial class Login : System.Web.UI.Page
    {
        SecurityQuestionService pxy = new SecurityQuestionService();
        UsersService upxy = new UsersService();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrors.Text = "";
            if (!IsPostBack && Request.Cookies["LoginCookie"] != null)
            {
                HttpCookie loginCookie = Request.Cookies["LoginCookie"];
                tboxUsername.Text = loginCookie.Values["Username"];
                tboxPassword.Text = Encryption.DecryptPassword(loginCookie.Values["Password"]);
            }
            if(Request.Cookies["LoginCookie"] != null)
            {
                btnClearCookie.Visible = true;
            }
            else
            {
                btnClearCookie.Visible = false;
            }
        }

        protected void btnClearCookie_Click(object sender, EventArgs e)
        {
            HttpCookie loginCookie = Request.Cookies["LoginCookie"];
            loginCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(loginCookie);
            btnClearCookie.Visible = false;
            tboxPassword.Text = "";
            tboxUsername.Text = "";
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            retrieveInfoDiv.Style.Add("visibility", "visible");
        }

        protected void btnForgotUsername_Click(object sender, EventArgs e)
        {
            retrieveInfoDiv.Style.Add("visibility", "visible");
        }

        protected void btnSubmitEmail_Click(object sender, EventArgs e)
        {
            if (tboxEmail.Text.Equals(""))
            {
                lblErrors.Text = "*You must enter an email.";
                return;
            }

            Session["email"] = tboxEmail.Text;
            Random rand = new Random();
            int questionID = rand.Next(1, 4);
            securityQuestion.InnerText = pxy.GetSecurityQuestionByID(questionID);
            string correctAnswer = pxy.GetSecurityQuestionAnswerByEmailAndQuestionID(tboxEmail.Text, questionID);

            if (correctAnswer.Equals("-1"))
            {
                lblErrors.Text = "*There was no record found matching your email addres.";
                return;
            }
            retrieveInfoDiv.Style.Add("visibility", "hidden");
            securityQuestionDiv.Style.Add("visibility", "visible");
            Session["answer"] = correctAnswer;

            //lblErrors.Text = Session["email"].ToString();
        }

        protected void btnSubmitAnswer_Click(object sender, EventArgs e)
        {
            if(tboxSecurityQuestionAnswer.Text.Equals(Session["answer"].ToString()))
            {
                loginInformationDiv.Style.Add("visibility", "visible");
                WebRequest request = WebRequest.Create("https://cis-iis2.temple.edu/Fall2022/CIS3342_tuh03252/webapitest/api/user/GetUsername/" + Session["email"].ToString());
                WebResponse response = request.GetResponse();
                Stream ds = response.GetResponseStream();
                StreamReader reader = new StreamReader(ds);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string username = data;

                
                request = WebRequest.Create("https://cis-iis2.temple.edu/Fall2022/CIS3342_tuh03252/webapitest/api/user/GetPasswordFromUsername/" + username);
                response = request.GetResponse();
                ds = response.GetResponseStream();
                reader = new StreamReader(ds);
                data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                js = new JavaScriptSerializer();
                string password = data;
                password = Encryption.DecryptPassword(password);

                loginInformation.InnerText = "Username: " + username + " Password: " + password;
            }
            else
            {
                lblErrors.Text = "*Your response to the security question was incorrect.";
            }
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
                WebRequest request = WebRequest.Create("https://cis-iis2.temple.edu/Fall2022/CIS3342_tuh03252/webapitest/api/user/GetPasswordFromUsername/" + tboxUsername.Text);
                WebResponse response = request.GetResponse();
                Stream ds = response.GetResponseStream();
                StreamReader reader = new StreamReader(ds);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                JavaScriptSerializer js = new JavaScriptSerializer();

                string pw = data;

                string encryptedPw = Encryption.EncryptPassword(tboxPassword.Text);

                //lblErrors.Text = "pw: " + pw + " epw: " + encryptedPw;

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

                    HttpCookie loginCookie = new HttpCookie("LoginCookie");
                    loginCookie.Values["Username"] = tboxUsername.Text;
                    loginCookie.Values["Password"] = encryptedPw;
                    Response.Cookies.Add(loginCookie);

                    lblErrors.Text = "Passwords match, proceed to login.";

                    string email = upxy.GetEmailFromUsername(tboxUsername.Text);

                    UserAccount user = new UserAccount(tboxUsername.Text, email, tboxPassword.Text);

                    Session["SerializedAccount"] = Serialization.Serialize(user);

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