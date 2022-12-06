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
    public partial class Profile : System.Web.UI.Page
    {
        UsersService upxy = new UsersService();
        UserAccount user = new UserAccount();
        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                loadAccounts();
                loadPosts();
            }
        }

        public void loadAccounts()
        {
            List<UserAccount> followedUsers = new List<UserAccount>();

            WebRequest request = WebRequest.Create("https://cis-iis2.temple.edu/Fall2022/CIS3342_tuh03252/webapitest/api/user/getfollowing/" + username);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();

            String[] usernames = js.Deserialize<String[]>(data);

            for (int i = 0; i < usernames.Length; i++)
            {
                UserAccount u = getAccountFromUser(usernames[i]);
                followedUsers.Add(u);
            }

            rptAccounts.DataSource = followedUsers;
            rptAccounts.DataBind();
        }

        public UserAccount getAccountFromUser(string username)
        {
            UserAccount u = upxy.GetAccountFromUsername(username);

            return u;
        }

        protected void rptAccounts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int row = e.Item.ItemIndex;
            Label lblusername = (Label)rptAccounts.Items[row].FindControl("lblUsername");

            upxy.Unfollow(lblusername.Text, username).ToString();
        }

        public void loadPosts()
        {
            WebRequest request = WebRequest.Create("https://cis-iis2.temple.edu/Fall2022/CIS3342_tuh03252/webapitest/api/post/" + username);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();

            Post[] posts = js.Deserialize<Post[]>(data);

            rptPosts.DataSource = posts;
            rptPosts.DataBind();
        }

        protected void rptPosts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int row = e.Item.ItemIndex;
            Label theID = (Label)rptPosts.Items[row].FindControl("lblID");
            int id = int.Parse(theID.Text);

            try
            {
                WebRequest request = WebRequest.Create("https://cis-iis2.temple.edu/Fall2022/CIS3342_tuh03252/webapitest/api/post/DeletePost/" + id);
                request.Method = "DELETE";

                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
            }

            catch (Exception ex)
            {
                lbltest.Text = "Error: " + ex.Message;
            }
            Response.Redirect("Profile.aspx");
        }
    }
}