using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Data.Mapping
{
    public class UserClaimsConfiguration : EntityTypeConfiguration<IdentityUserClaim>
    {
        public string TableName
        {
            get { return "UserClaims"; }
        }
        public UserClaimsConfiguration()
        {
            this.ToTable(TableName);
        }
    }
}