using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using forum.Domain.Entities;
using forum.DataBase.Concrete;


namespace forum.Controllers
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
        public ActionResult ViewSection(int sectionId)
        {
            ViewBag.name = Sections.Sections.First(p => p.IdSection == sectionId).SectionName;
            return View(Threads.Threads.Where(p => p.IdSection == sectionId));
        }
        public ActionResult ViewThread(int threadId)
        {
            ViewBag.id = threadId;
            ViewBag.name = Threads.Threads.FirstOrDefault(p => p.IdThread == threadId).ThreadName;
            return View(Posts.Posts.Where(p => p.IdThread == threadId));
        }
        [HttpPost]
        public ActionResult Edit(Post post, int threadId)
        {
            post.IdThread = threadId;
            Posts.SavePost(post);
            return RedirectToAction("ViewThread", new { threadId = post.IdThread});
        }
        public PartialViewResult AddPost(int threadId)
        {
            Post post = new Post();
            ViewBag.id = threadId;
            return PartialView(post);
        }
    }
}