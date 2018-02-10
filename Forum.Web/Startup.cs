using Forum.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Forum.Web.Startup))]
namespace Forum.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsersAsync();
        }


        // In this method we will create default User roles and Admin user for login   
        private async void createRolesandUsersAsync()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //UserManager.AddToRole((UserManager.FindByEmail("Admin@gmail.com").Id.ToString()), "Admin");

            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            var user = new ApplicationUser { UserName = "Admin@gmail.com", Email = "Admin@gmail.com" };

            var result = await UserManager.CreateAsync(user, "admin11");
            UserManager.AddToRole((UserManager.FindByEmail("Admin@gmail.com").Id.ToString()), "Admin");
            UserManager.AddToRole((UserManager.FindByEmail("Admin@gmail.com").Id.ToString()), "User");

            // creating Creating Employee role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }
        }
    }
}
