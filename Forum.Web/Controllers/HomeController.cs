﻿using System;
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
       


        public ActionResult Index()
        {
            HomeViewModel HomeVM = new HomeViewModel(Sections, User, Threads, OverSections);
            return View(HomeVM);
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