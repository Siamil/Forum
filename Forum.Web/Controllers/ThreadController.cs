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
    public class ThreadController : Controller
    {
        private EFPosts Posts = new EFPosts();
        private EFSections Sections = new EFSections();
        private EFThreards Threads = new EFThreards();
        private EFOverSections OverSections = new EFOverSections();

        public ActionResult ViewThread(int threadId)
        {

            ThreadViewModel ThreadVM = new ThreadViewModel(threadId, Threads, Posts, User);
            return View(ThreadVM);
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
            return RedirectToAction("ViewSection","Section", new { sectionId = thread.IdSection });
        }
    }
}