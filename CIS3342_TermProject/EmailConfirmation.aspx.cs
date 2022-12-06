using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS3342_TermProject
{
    public partial class EmailConfirmation : System.Web.UI.Page
    {
        UsersService upxy = new UsersService();

        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["Username"];
            if (username == null || username.Equals(""))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                
                bool wasConfirmed = upxy.ConfirmEmailOfUsername(username);
                if(wasConfirmed)
                {
                    welcomeMessage.InnerText = username + ", thank you for confirming your account.";
                }
                else
                {
                    welcomeMessage.InnerText = "error";
                }

                /*JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonEmail = js.Serialize(email);
                try
                {
                    WebRequest request = WebRequest.Create("https://cis-iis2.temple.edu/Fall2022/CIS3342_tuh03252/webapitest/api/user/ConfirmEmail");
                    request.Method = "PUT";
                    request.ContentLength = jsonEmail.Length;
                    request.ContentType = "application/json";

                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonEmail);
                    writer.Flush();
                    writer.Close();

                    WebResponse response = request.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                }

                catch (Exception ex)
                {
                    welcomeMessage.InnerText = "Error: " + ex.Message;
                }*/

            }
        }
    }
}