using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplicationProject.Models
{
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var roleAdmin = new IdentityRole("admin");
            var roleUser = new IdentityRole("user");

            roleManager.Create(roleUser);
            roleManager.Create(roleAdmin);

            var admin = new ApplicationUser { Email = "furyredux@gmail.com", UserName = "furyredux@gmail.com", EmailConfirmed = true };
            string password = "Qwerty1_";
            var result = userManager.Create(admin, password);
            
            if(result.Succeeded)
            {
                userManager.AddToRole(admin.Id, roleAdmin.Name);
                userManager.AddToRole(admin.Id, roleUser.Name);
            }
            base.Seed(context);
        }
    }
}