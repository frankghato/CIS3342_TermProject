using System;
using System.Collections;
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
    public partial class Posts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NewPostUserControl newPostControl = (NewPostUserControl)LoadControl("NewPostUserControl.ascx");
            newPostControl.username = "JacobJablonski";
            Form.Controls.Add(newPostControl);

            loadPosts("https://localhost:44382/api/post");
        }

        public void loadPosts(string apiurl)
        {
            WebRequest request = WebRequest.Create(apiurl);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();

            Post[] posts = js.Deserialize<Post[]>(data);

            for (int i = 0; i < posts.Length; i++)
            {
                PostsUserControl postControl = (PostsUserControl)LoadControl("PostsUserControl.ascx");
                postControl.p = posts[i];
                postControl.showPost();
                Form.Controls.Add(postControl);
            }
        }
    }
}