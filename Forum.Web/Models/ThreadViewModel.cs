using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using forum.Domain.Entities;
using forum.DataBase.Concrete;


namespace Forum.Web.Models
{
    public class ThreadViewModel
    {
        
        public ThreadViewModel(int threadId, EFThreards threads, EFPosts posts, string currentUser)
        {
            this.threadId = threadId;
            CurrentUser = currentUser;
            Name = threads.Threads.FirstOrDefault(p => p.IdThread == threadId).ThreadName;
            Posts = posts.Posts.Where(p => p.IdThread == threadId);
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