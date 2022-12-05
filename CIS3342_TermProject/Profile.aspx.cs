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
    public partial class Profile : System.Web.UI.Page
    {
        UsersService upxy = new UsersService();
        string username = "JacobTemple";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadAccounts();
            }
        }

        public void loadAccounts()
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

        protected void rptAccounts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int row = e.Item.ItemIndex;
            Label lblusername = (Label)rptAccounts.Items[row].FindControl("lblUsername");

            upxy.Unfollow(lblusername.Text, username).ToString();
        }
    }
}