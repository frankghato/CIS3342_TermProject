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
    public partial class PostsUserControl : System.Web.UI.UserControl
    {
        public Post p;
        UsersService upxy = new UsersService();
        string useraccount = "Jacob";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonPost = js.Serialize(p);
            try
            {
                WebRequest request = WebRequest.Create("https://cis-iis2.temple.edu/Fall2022/CIS3342_tuh03252/webapi/api/post/LikePost");
                request.Method = "PUT";
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
                lblContent.Text = "Error: " + ex.Message;
            }
            Response.Redirect("Posts.aspx");
        }

        protected void btnDislike_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonPost = js.Serialize(p);
            try
            {
                WebRequest request = WebRequest.Create("https://cis-iis2.temple.edu/Fall2022/CIS3342_tuh03252/webapi/api/post/DislikePost");
                request.Method = "PUT";
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
                lblContent.Text = "Error: " + ex.Message;
            }
            Response.Redirect("Posts.aspx");
        }

        public void showPost()
        {
            lblContent.Text = p.Content;
            lblUsername.Text = p.Username;
            lblLikes.Text = p.Likes.ToString();
            lblDislikes.Text = p.Dislikes.ToString();
        }

        protected void btnFollow_Click(object sender, EventArgs e)
        {
            upxy.FollowUser(p.Username, useraccount);
            Response.Redirect("Posts.aspx");
        }
    }
}