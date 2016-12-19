using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Data.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {

        }
    }
}