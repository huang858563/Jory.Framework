using Jory.Framework.Web.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Jory.Framework.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<M_User>
    {
        public DbSet<M_Application> AspNetApplications { get; set; }

        public DbSet<M_Site> Sites { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M_Role>().Property(x => x.ApplicationId).IsRequired();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<M_Application>().ToTable("AspNetApplications");

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

           
            //modelBuilder.Entity<AspNetUsersRoles>().HasMany(i => i.Users).WithRequired().WillCascadeOnDelete(false);
            //modelBuilder.Entity<M_User>().HasRequired(x=>x.Application).WithOptional().WillCascadeOnDelete(false);
            //ssmodelBuilder.Entity<M_Role>().HasRequired(x => x.Application).WithOptional().WillCascadeOnDelete(false);
            //modelBuilder.Entity<M_Role>().HasRequired(x => x.Application).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<M_User>()
            //        .HasOptional(x => x.Application)
            //        .WithMany(y => y.Users) //Add this property to model to make mapping work
            //        .WillCascadeOnDelete(false);
        }
    }
}