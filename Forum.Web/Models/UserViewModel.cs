using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using forum.Domain.Entities;
using forum.DataBase.Concrete;
using System.Security.Principal;

namespace Forum.Web.Models
{
    public class UserViewModel
    {
        private EFThreards threads;
        private EFPosts posts;

        public UserViewModel(EFThreards threads, EFPosts posts, ApplicationUser user)
        {
            this.threads = threads;
            this.posts = posts;
            this.user = user;
            userThreads = threads.Threads.Where(p => p.UserName == user.UserName);
        }
    
        public ApplicationUser user { get; set; }
        public int CountPosts()
        {
            return posts.Posts.Where(p => p.UserName == user.UserName).Count();
        }
        public IEnumerable<Thread> userThreads { set; get; }
        
    }
}