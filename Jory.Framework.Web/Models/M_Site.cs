using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jory.Framework.Web.Models
{
    public class M_Site
    {
        public string ID { get; set; }
        public Guid ApplicationId { get; set; }
        public virtual M_Application Application { get; set; }
    }
}