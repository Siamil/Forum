using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using forum.Domain.Entities;
using forum.DataBase.Concrete;
using System.Security.Principal;
namespace Forum.Web.Models
{
    public class HomeViewModel
    {
        public EFSections Sections { get; set; }
       public  IPrincipal User { get; set; }
       public  EFThreards Threads { get; set; }

        public HomeViewModel(EFSections sections, IPrincipal user, EFThreards threads)
        {
            this.Sections = sections;
            this.User = user;
            this.Threads = threads;
        }
        public int CountThreads(int sectionId)
        {
            return Threads.Threads.Where(p => p.IdSection == sectionId).Count();
        }
    }
}