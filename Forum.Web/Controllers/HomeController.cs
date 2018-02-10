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
    public class HomeController : Controller
    {
        private EFPosts Posts = new EFPosts();
        private EFSections Sections = new EFSections();
        private EFThreards Threads = new EFThreards();
        private EFOverSections OverSections = new EFOverSections();
        private EFMesseges Messeges = new EFMesseges();
       

        public void SeedDB()
        {
            OverSection overSection = new OverSection();
            overSection.Name = "oversection1";
            OverSections.SaveSection(overSection);
            
            OverSection overSection2 = new OverSection();
            for (int i = 0; i < 5; i++)
            {
                Section section = new Section();
                section.SectionName = "dzial" + i;
                section.OverSectionId = overSection.OverSectionId;
                Sections.SaveSection(section);
            }
          
            overSection2.Name = "oversection2";
            OverSections.SaveSection(overSection2);
            for (int i = 0; i < 5; i++)
            {
                Section section = new Section();
                section.SectionName = "dzial" + i;
                section.OverSectionId = overSection2.OverSectionId;
                Sections.SaveSection(section);
            }
        }
        public void clearDB()
        {
            foreach (var item in OverSections.OverSections.ToList())
            {
                    foreach (var section in Sections.Sections.Where(p => p.OverSectionId == item.OverSectionId ).ToList())
                    {
                        
                        foreach(var thread in Threads.Threads.Where(t => t.IdSection == section.IdSection).ToList())
                        {
                        
                        foreach (var post in Posts.Posts.Where(p => p.IdThread == thread.IdThread).ToList())
                        {
                            Posts.DeletePost(post.IdPost);
                        }
                        Threads.DeleteThread(thread.IdThread);
                    }
                    Sections.DeleteSection(section.IdSection);
                }
                OverSections.DeleteSection(item.OverSectionId);
            }
            
            
        }
        public ActionResult Index()
        {
           
            HomeViewModel HomeVM = new HomeViewModel(Sections, User, Threads, OverSections);
            return View(HomeVM);
        }
    
    }
}