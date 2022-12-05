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

                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonEmail = js.Serialize(email);
                try
                {
                    WebRequest request = WebRequest.Create("https://localhost:44382/api/user/ConfirmEmail");
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
                }

            }
        }
    }
}