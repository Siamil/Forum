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
        private EFMesseges Messeges = new EFMesseges();
        ApplicationDbContext context = new ApplicationDbContext();
        

        public ActionResult Users(string userName)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            UserViewModel UserVM = new UserViewModel(Threads, Posts, UserManager, userName);
            return View(UserVM);
        }
        [Authorize(Roles= "User")]
        public ActionResult SendMessege(string to, string from)
        {
            MessegeViewModel messegeVM = new MessegeViewModel(from, to);
            return View(messegeVM);
        }
        [HttpPost]
        public ActionResult SaveMessege(MessegeViewModel messegeVM, string from, string to)
        {
            Messege messege = new Messege();
            messege.From = from;
            messege.Text = messegeVM.Text;
            messege.To = to;
            messege.Subject = messegeVM.Subject;
            Messeges.SaveMessege(messege);
            return RedirectToAction("index", "home", null);
        }
        public ActionResult UserMesseges()
        {
            UserMessegesViewModel VM = new UserMessegesViewModel(Messeges, User);
            return View(VM);
        }
        
        public ActionResult ShowMessege(int messegeId)
        {
            Messege messege = Messeges.Messeges.First(m => m.ID == messegeId);
            return View(messege);
        }
    }
   
}