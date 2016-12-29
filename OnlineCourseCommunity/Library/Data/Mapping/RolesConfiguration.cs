using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Data.Mapping
{
    public class RolesConfiguration : EntityTypeConfiguration<IdentityRole>
    {
        public string TableName
        {
            get { return "Roles"; }
        }
        public RolesConfiguration()
        {
            this.ToTable(TableName);
            this.HasKey<string>(r => r.Id); // It's row decision
        }
    }
}