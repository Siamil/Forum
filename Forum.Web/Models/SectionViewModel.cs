using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using forum.Domain.Entities;
using forum.DataBase.Concrete;
using System.Security.Principal;

namespace Forum.Web.Models
{
    public class SectionViewModel
    {
        EFPosts Posts;
        public SectionViewModel(int sectionId, EFSections sections, EFThreards threads, EFPosts posts, IPrincipal user)
        {
            Name = sections.Sections.First(x => x.IdSection == sectionId).SectionName;
            this.threads = threads.Threads.Where(x => x.IdSection == sectionId);
            this.sectionId = sectionId;
            this.User = user;
            Posts = posts;
        }
        public string Name { get; set; }
        public IEnumerable<Thread> threads { get; set; }
        public int sectionId { get; set; }
        public IPrincipal User { get; set; }
        public  int CountPosts(int threadId)
        {
           IEnumerable<Post> posts = Posts.Posts.Where(p => p.IdThread == threadId);
           return  posts.Count();
        }
    }

}