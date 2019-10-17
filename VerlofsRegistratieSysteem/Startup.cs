using Microsoft.Owin;
using Owin;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using VerlofsRegistratieSysteem.Models;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(VerlofsRegistratieSysteem.Startup))]
namespace VerlofsRegistratieSysteem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateEntities();
        }

        private void CreateEntities()
        {
            AbsenceContext absenceContext = new AbsenceContext();
            ApplicationDbContext context = new ApplicationDbContext();

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var applicationRoleAdministrator = new ApplicationRole { Name = "Administrator" };
            var applicationRoleEmployee = new ApplicationRole { Name = "Employee" };

            if (!RoleManager.RoleExists(applicationRoleAdministrator.Name)) RoleManager.Create(applicationRoleAdministrator);
            if (!RoleManager.RoleExists(applicationRoleEmployee.Name)) RoleManager.Create(applicationRoleEmployee);

            if(!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };
                userManager.Create(user, "Admin.123");
                userManager.AddToRole(user.Id, "Administrator");
            }
        }
    }
}
