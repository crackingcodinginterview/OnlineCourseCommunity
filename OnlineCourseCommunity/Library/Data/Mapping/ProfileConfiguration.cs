using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Data.Mapping
{
    public class ProfileConfiguration : EntityTypeConfiguration<Profile>
    {
        public string TableName
        {
            get { return "Profiles"; }
        }
        public ProfileConfiguration()
        {
            this.ToTable(TableName);

            this.HasRequired(o => o.User);
                 
            this.HasMany(a => a.PurchaseCourseList)
                .WithMany(b => b.PurchaseUserList)
                .Map(r =>
                {
                    r.MapLeftKey("UserId");
                    r.MapRightKey("CourseId");
                    r.ToTable("UserCourse");
                });
        }
    }
}