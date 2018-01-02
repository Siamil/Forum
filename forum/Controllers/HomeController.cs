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
        public ActionResult Index()
        {
            return View(Posts.Posts);
        }
    }
}