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
using TermProjectClassLibrary;
using TermProjectLibrary;

namespace CIS3342_TermProject
{
    public partial class Posts : System.Web.UI.Page
    {
        UserAccount user = new UserAccount();
        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SerializedAccount"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string jsonUsername = (string)Session["SerializedAccount"];
                user = Serialization.Deserialize(jsonUsername);
                username = user.Username;
            }

            NewPostUserControl newPostControl = (NewPostUserControl)LoadControl("NewPostUserControl.ascx");
            newPostControl.username = username;
            Form.Controls.Add(newPostControl);

            if (Session["TypeofPosts"] == null || (string)Session["TypeofPosts"] == "All")
            {
                loadPosts("https://cis-iis2.temple.edu/Fall2022/CIS3342_tuh03252/webapitest/api/post");
            }
            else
            {
                LoadPostsByFollowedUsers();
            }
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

        public void LoadPostsByFollowedUsers()
        {
            List<UserAccount> followedUsers = new List<UserAccount>();
            WebRequest request = WebRequest.Create("https://localhost:44382/api/user/getfollowing/" + username);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();

            String[] usernames = js.Deserialize<String[]>(data);
            List<Post> posts = new List<Post>();
            for(int i = 0; i < usernames.Length; i++)
            {
                request = WebRequest.Create("https://localhost:44382/api/post/" + usernames[i]);
                response = request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                js = new JavaScriptSerializer();
                Post[] userPosts = js.Deserialize<Post[]>(data);
                for(int j = 0; j < userPosts.Length; j++)
                {
                    posts.Add(userPosts[j]);
                }
            }
            posts.OrderBy(p => p.Id).ToList();
            posts.Reverse();

            for (int i = 0; i < posts.Count; i++)
            {
                PostsUserControl postControl = (PostsUserControl)LoadControl("PostsUserControl.ascx");
                postControl.p = posts[i];
                postControl.showPost();
                Form.Controls.Add(postControl);
            }
        }

        public UserAccount getAccountFromUser(string username)
        {
            WebRequest request = WebRequest.Create("https://localhost:44382/api/user/getaccount/" + username);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            UserAccount u = js.Deserialize<UserAccount>(data);

            return u;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("SerializedAccount");
            Response.Redirect("Login.aspx");
        }

        protected void btnFollowedPosts_Click(object sender, EventArgs e)
        {
            Session["TypeofPosts"] = "Follow";
        }

        protected void btnAllPosts_Click(object sender, EventArgs e)
        {
            Session["TypeofPosts"] = "All";
        }
    }
}