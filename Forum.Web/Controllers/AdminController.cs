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

namespace Forum.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private EFPosts Posts = new EFPosts();
        private EFSections Sections = new EFSections();
        private EFThreards Threads = new EFThreards();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RemoveThread(int threadId)
        {
            int sectionId = Threads.Threads.First(p => p.IdThread == threadId).IdThread;
            foreach (var item in Posts.Posts.Where(p => p.IdThread == threadId))
            {
                Posts.DeletePost(item.IdPost);
            }
            Threads.DeleteThread(threadId);
            return RedirectToAction("ViewSection", "Home", new { sectionId = sectionId });
        }
        public ActionResult RemoveSection(int sectionId)
        {
            foreach (var item in Threads.Threads.Where(p => p.IdSection == sectionId).ToList())
            {
                foreach (var post in Posts.Posts.Where(p => p.IdThread == item.IdThread).ToList())
                {
                    Posts.DeletePost(post.IdPost);
                }
                Threads.DeleteThread(item.IdThread);
            }
            Sections.DeleteSection(sectionId);
            return RedirectToAction("Index", "Home");
        }
    }
}