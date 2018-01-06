using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using forum.Domain.Entities;
using forum.DataBase.Concrete;
using System.Security.Principal;

namespace Forum.Web.Models
{
    public class ThreadViewModel
    {
        private EFThreards threads;
        private EFPosts posts;
        public IPrincipal user { get; set; }

        

        public ThreadViewModel(int threadId, EFThreards threads, EFPosts posts, IPrincipal user)
        {
            this.threadId = threadId;
            this.threads = threads;
            this.posts = posts;
            Posts = posts.Posts;
            this.user = user;
        }

        public int threadId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public string CurrentUser { get; set; }
        public Post CreatePost()
        {
            Post post = new Post();
            return post;
        }

    }
}