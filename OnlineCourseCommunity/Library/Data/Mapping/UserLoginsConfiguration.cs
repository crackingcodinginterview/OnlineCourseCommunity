using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Data.Mapping
{
    public class UserLoginsConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public string TableName
        {
            get { return "UserLogins"; }
        }

        public UserLoginsConfiguration()
        {
            this.ToTable(TableName);
            HasKey<string>(l => l.UserId); // It's row was my decision
        }
    }
}