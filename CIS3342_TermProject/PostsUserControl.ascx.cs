using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectLibrary;

namespace CIS3342_TermProject
{
    public partial class PostsUserControl : System.Web.UI.UserControl
    {
        public Post p;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            
        }

        public void showPost()
        {
            lblContent.Text = p.Content;
            lblUsername.Text = p.Username;
            lblLikes.Text = p.Likes.ToString();
            lblDislikes.Text = p.Dislikes.ToString();
        }
    }
}