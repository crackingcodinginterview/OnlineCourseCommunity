using OnlineCourseCommunity.Library.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Data
{
    public class Context : DbContext
    {
        public Context()
            : base("Context")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserMapping());
        }
    }
}