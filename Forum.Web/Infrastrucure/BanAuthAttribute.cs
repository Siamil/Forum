using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Security.Principal;
using forum.DataBase.Concrete;
using Forum.Web.Models;

namespace Forum.Web.Infrastrucure
{
    public class BanAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        private EFBans Bans = new EFBans();
        
       
        

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity ident = filterContext.Principal.Identity;
            if(!ident.IsAuthenticated || Bans.Bans.FirstOrDefault(m => m.UserName == ident.Name) != null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
              {
                  { "controller", "Home"}, {"action", "Index"}
              });
            }
        }
        
    }
}