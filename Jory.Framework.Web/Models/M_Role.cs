using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Jory.Framework.Web.Models
{
    public class M_Role : IdentityRole
    {
        //public M_Role() : base() { }
        //public M_Role(string name) : base(name) { }

        public Guid ApplicationId { get; set; }

        public virtual M_Application Application { get; set; }

        ///// <summary>
        ///// 角色描述
        ///// </summary>
        //[DisplayName("角色描述")]
        //[StringLength(256)]
        //public string Description { get; set; }

       
    }
}