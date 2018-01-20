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
    public class SectionController : Controller
    {
        private EFPosts Posts = new EFPosts();
        private EFSections Sections = new EFSections();
        private EFThreards Threads = new EFThreards();
        private EFOverSections OverSections = new EFOverSections();

        [Authorize(Roles = "Admin")]
        public ActionResult SaveSection(Section section, int overSectionId)
        {
            section.OverSectionId = overSectionId;
            Sections.SaveSection(section);
            return RedirectToAction("Index","Home", null);
        }
        public ActionResult ViewSection(int sectionId, int? page)
        {
            var pager = new Pager(Threads.Threads.Where(p => p.IdSection == sectionId).Count(), page);
            SectionViewModel sectionVM = new SectionViewModel(sectionId, Sections, Threads, Posts, User);
            sectionVM.pager = pager;
            return View(sectionVM);
        }
    }
}