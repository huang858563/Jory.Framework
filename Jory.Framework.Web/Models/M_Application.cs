using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jory.Framework.Web.Models
{
    public class M_Application
    {
        [Key]
        public Guid ApplicationId { get; set; }

        [DataType(DataType.Text)]
        [StringLength(128)]
        public string ApplicationName { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        //public virtual ICollection<M_User> Users { get; set; }
    }
}