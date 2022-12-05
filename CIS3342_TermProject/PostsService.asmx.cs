using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using TermProjectLibrary;
using Utilities;

namespace CIS3342_TermProject
{
    /// <summary>
    /// Summary description for PostsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PostsService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Post> GetPosts() // Get All posts
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_GetPosts";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            List<Post> Posts = new List<Post>();
            Post p;

            foreach (DataRow record in myDS.Tables[0].Rows)
            {
                p = new Post();
                p.Id = int.Parse(record["PostID"].ToString());
                p.Username = record["Username"].ToString();
                p.Content = record["Content"].ToString();
                p.Likes = int.Parse(record["Likes"].ToString());
                p.Dislikes = int.Parse(record["Dislikes"].ToString());
                Posts.Add(p);
            }
            return Posts;
        }
    }
}
