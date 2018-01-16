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
    public class PostController : Controller
    {
        private EFPosts Posts = new EFPosts();
        private EFSections Sections = new EFSections();
        private EFThreards Threads = new EFThreards();
        private EFOverSections OverSections = new EFOverSections();

        public ActionResult RemovePost(int postId)
        {
            int threadId = Posts.Posts.FirstOrDefault(p => p.IdPost == postId).IdThread;
            Posts.DeletePost(postId);
            return RedirectToAction("ViewThread","Section", new { threadId = threadId });
        }




        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult Edit(Post post, int threadId)
        {
            post.IdThread = threadId;
            if (ModelState.IsValid)
            {
                post.UserName = User.Identity.Name;
                post.DateTime = DateTime.Now;

                Posts.SavePost(post);
            }
            return RedirectToAction("ViewThread","Thread", new { threadId = post.IdThread });
        }

        public ActionResult EditPost(int postId)
        {
            Post post = Posts.Posts.FirstOrDefault(x => x.IdPost == postId);
            return View(post);
        }
        [HttpPost]
        public ActionResult SavePost(Post post)
        {

            Posts.SavePost(post);
            return RedirectToAction("ViewThread", "Thread", new { threadId = post.IdThread });
        }

        public PartialViewResult AddPost(int threadId, Post post = null)
        {

            ViewBag.id = threadId;
            return PartialView(post);
        }
    }
}