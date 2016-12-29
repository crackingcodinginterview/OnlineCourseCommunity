using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Data.Mapping
{
    public class UserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public string TableName
        {
            get { return "UserRoles"; }
        }

        public UserRoleConfiguration()
        {
            this.ToTable(TableName);
            HasKey(r => new { r.RoleId, r.UserId }); // It's row was my decision
        }
    }
}