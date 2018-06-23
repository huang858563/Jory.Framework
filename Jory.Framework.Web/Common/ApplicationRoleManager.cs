using Jory.Framework.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jory.Framework.Web.Common
{
    public class ApplicationRoleManager : RoleManager<M_Role>
    {
        public ApplicationRoleManager(IRoleStore<M_Role, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<M_Role>(context.Get<ApplicationDbContext>()));
        }
    }
}