﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TermProjectLibrary;
using Utilities;

namespace TermProjectAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        [HttpGet]
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

        [HttpGet("{username}")] // Get all posts by username
        public List<Post> GetPostsByUser(string username)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_GetPostsFromUsername";
            objCommand.Parameters.AddWithValue("@theUsername", username);

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

        [HttpPut("LikePost")] // Like a post
        public Boolean LikePost([FromBody] Post p)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_LikePost";
            objCommand.Parameters.AddWithValue("@thePostID", p.Id);

            int updated = objDB.DoUpdateUsingCmdObj(objCommand);
            if (updated > 0)
            {
                return true;
            }
            return false;
        }

        [HttpPut("DislikePost")] // Dislike a post
        public Boolean DislikePost([FromBody] Post p)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_DislikePost";
            objCommand.Parameters.AddWithValue("@thePostID", p.Id);

            int updated = objDB.DoUpdateUsingCmdObj(objCommand);
            if (updated > 0)
            {
                return true;
            }
            return false;
        }

        [HttpPost("AddPost")] // Post a new post
        public Boolean AddPost([FromBody] Post p)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_Addpost";
            objCommand.Parameters.AddWithValue("@theUsername", p.Username);
            objCommand.Parameters.AddWithValue("@theContent", p.Content);

            int updated = objDB.DoUpdateUsingCmdObj(objCommand);
            if (updated > 0)
            {
                return true;
            }
            return false;
        }

        [HttpDelete("DeletePost/{id}")] // Post a new post
        public Boolean DeletePost(int id)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_DeletePost";
            objCommand.Parameters.AddWithValue("@thePostID", id);

            int updated = objDB.DoUpdateUsingCmdObj(objCommand);
            if (updated > 0)
            {
                return true;
            }
            return false;
        }
    }
}
