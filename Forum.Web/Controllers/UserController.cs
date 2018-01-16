using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using forum.DataBase.Concrete;
using Forum.Web.Models;
using forum.Domain.Entities;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Forum.Web.Controllers
{
    public class UserController : Controller
    {
        private EFPosts Posts = new EFPosts();
        
        private EFThreards Threads = new EFThreards();
        
        public ActionResult Users(string userName)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            UserViewModel UserVM = new UserViewModel(Threads, Posts, UserManager.FindByName(userName));
            return View(UserVM);
        }
    }
}