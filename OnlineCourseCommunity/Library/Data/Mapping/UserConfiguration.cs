using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Data.Mapping
{
    public class UserConfiguration : EntityTypeConfiguration<IdentityUser>
    {
        public string TableName
        {
            get { return "Users"; }
        }
        public UserConfiguration()
        {
            this.ToTable(TableName);
        }
    }
}