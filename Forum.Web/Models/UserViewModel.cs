using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using forum.Domain.Entities;
using forum.DataBase.Concrete;
using System.Security.Principal;
using System.Web.Mvc;
using Forum.Web.Models;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Forum.Web.Models
{
    public class UserViewModel
    {
        private EFThreards threads;
        private EFPosts posts;
        private UserManager<ApplicationUser> UserManager { get; set; }

        public UserViewModel(EFThreards threads, EFPosts posts, UserManager<ApplicationUser> user, string userName)
        {
            this.threads = threads;
            this.posts = posts;
            this.UserManager = user;
            this.user = UserManager.Users.First(m => m.UserName == userName);
            userThreads = threads.Threads.Where(p => p.UserName == this.user.UserName);
            userRoles = UserManager.GetRoles(this.user.Id);
        }
    
        public ApplicationUser user { get; set; }
        public int CountPosts()
        {
            return posts.Posts.Where(p => p.UserName == user.UserName).Count();
        }
        public IEnumerable<Thread> userThreads { set; get; }
        public IEnumerable<string> userRoles { set; get; }
        
    }
}