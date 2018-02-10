using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using forum.DataBase.Concrete;
using Forum.Web.Models;
using forum.Domain.Entities;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Forum.Web.Models
{
    public class UserMessegesViewModel
    {
        public EFMesseges messeges;

        public UserMessegesViewModel(EFMesseges messeges, IPrincipal user)
        {
            this.messeges = messeges;

            this.userMessegesRec = messeges.Messeges.Where(m => m.To == user.Identity.Name );
            this.userMessegesSent = messeges.Messeges.Where(m => m.From == user.Identity.Name);


        }

        public IEnumerable<Messege> userMessegesSent { get; set; }
        public IEnumerable<Messege> userMessegesRec { get; set; }

    }
}