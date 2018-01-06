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
    public class HomeController : Controller
    {
        private EFPosts Posts = new EFPosts();
        private EFSections Sections = new EFSections();
        private EFThreards Threads = new EFThreards();

        public ActionResult Index()
        {
            
            return View(Sections.Sections);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SaveSection(Section section)
        {
            Sections.SaveSection(section);
            return RedirectToAction("Index");
        }
        public ActionResult ViewSection(int sectionId)
        {
            SectionViewModel sectionVM = new SectionViewModel(sectionId, Sections, Threads, Posts);
            return View(sectionVM);
        }
        public ActionResult ViewThread(int threadId)
        {
            ThreadViewModel ThreadVM = new ThreadViewModel(threadId, Threads, Posts, User.Identity.Name);
            return View(ThreadVM);
        }
        public ActionResult RemovePost(int postId)
        {
           int threadId = Posts.Posts.First(p => p.IdPost == postId).IdThread;
           Posts.DeletePost(postId);
            return RedirectToAction("ViewThread", new { threadId = threadId });
        }
        
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult Edit(Post post, int threadId)
        {
            
            post.UserName = User.Identity.Name;
            post.IdThread = threadId;
            Posts.SavePost(post);
            return RedirectToAction("ViewThread", new { threadId = post.IdThread });
        }
        
        public ActionResult AddThread(int sectionId)
        {
            Thread thread = new Thread();
            ViewBag.Id = sectionId;
            return View(thread);
        }
        [HttpPost]
        public ActionResult SaveThread(Thread thread, int sectionId)
        {
            thread.UserName = User.Identity.Name;
            thread.IdSection = sectionId;
            Threads.SaveThread(thread);
            return RedirectToAction("ViewSection", new { sectionId = thread.IdSection });
        }
        public PartialViewResult AddPost(int threadId)
        {
            Post post = new Post();
            ViewBag.id = threadId;
            return PartialView(post);
        }
    
    

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}