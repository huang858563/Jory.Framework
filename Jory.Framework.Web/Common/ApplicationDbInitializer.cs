using Jory.Framework.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity;
using System.Web;

namespace Jory.Framework.Web.Common
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //InitializeIdentityForEF(context);
            base.Seed(context);
        }
    
        public static async void InitializeIdentityForEF(ApplicationDbContext db)
        {
            //Guid applicationId = Guid.NewGuid();
            //M_Application app = new M_Application();
            //app.ApplicationId=applicationId;
            //app.ApplicationName = "JoryMVC";
            //app.Description="MVC";

            //db.AspNetApplications.Add(app);
            //db.SaveChanges();

            //var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            //const string name = "admin@admin.com";
            //const string password = "123456";
            //const string roleName = "admin";

            ////Create Role Admin if it does not exist
            //var role = await roleManager.FindByNameAsync(roleName);
            //if (role == null)
            //{
            //    role = new M_Role(roleName);
            //    role.ApplicationId = applicationId;
            //    var roleresult = roleManager.CreateAsync(role);
            //}

            //var user = await userManager.FindByNameAsync(name);
            //if (user == null)
            //{
            //    user = new M_User { UserName = name, Email = name };
            //    user.ApplicationId = applicationId;
            //    var result = userManager.CreateAsync(user, password);
            //    result = userManager.SetLockoutEnabledAsync(user.Id, false);
            //}

            //// Add user admin to Role Admin if not already added
            //var rolesForUser = await userManager.GetRolesAsync(user.Id);
            //if (!rolesForUser.Contains(role.Name))
            //{
            //    var result = userManager.AddToRoleAsync(user.Id, role.Name);
            //}
        }
    }
}