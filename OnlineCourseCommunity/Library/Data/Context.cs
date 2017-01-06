using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCourseCommunity.Library.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Data
{
    public class Context : IdentityDbContext
    {
        public Context()
            : base("Context")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RolesConfiguration());
            modelBuilder.Configurations.Add(new UserClaimsConfiguration());
            modelBuilder.Configurations.Add(new UserLoginsConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new ProfileConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}