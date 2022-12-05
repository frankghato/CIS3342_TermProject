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
    public partial class NewPostUserControl : System.Web.UI.UserControl
    {
        public string username;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (txtNewPost.Text != "")
            {
                Post p = new Post();
                p.Username = username;
                p.Content = txtNewPost.Text;
                p.Likes = 0;
                p.Dislikes = 0;

                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonPost = js.Serialize(p);
                try
                {
                    WebRequest request = WebRequest.Create("https://localhost:44382/api/post/AddPost");
                    request.Method = "POST";
                    request.ContentLength = jsonPost.Length;
                    request.ContentType = "application/json";

                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonPost);
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
                    txtNewPost.Text = "Error: " + ex.Message;
                }
                Response.Redirect("Posts.aspx");
            }
        }
    }
}