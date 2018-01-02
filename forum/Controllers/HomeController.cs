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
          
            return View(Threads.Threads.Where(p => p.IdSection == sectionId));
        }
        public ActionResult ViewThread(int threadId)
        {
            return View(Posts.Posts.Where(p => p.IdThread == threadId));
        }
    }
}