using System;
using System.Collections.Generic;
using System.Text;

namespace TermProjectLibrary
{
    class Post
    {
        private int id;
        private int likes;
        private int dislikes;
        private string username;
        private string content;

        public int Id { get => id; set => id = value; }
        public int Likes { get => likes; set => likes = value; }
        public int Dislikes { get => dislikes; set => dislikes = value; }
        public string Username { get => username; set => username = value; }
        public string Content { get => content; set => content = value; }
    }
}
