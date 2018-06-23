using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Jory.Framework.Web.Models
{
    public class M_User : IdentityUser
    {
        //用戶頭像URL
        public string HeadImgUrl { get; set; }

        public Guid ApplicationId { get; set; }

        public virtual M_Application Application { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<M_User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}