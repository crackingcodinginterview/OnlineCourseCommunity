using OnlineCourseCommunity.Library.Core.Domain.Bussiness;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Data.Mapping
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public string TableName
        {
            get { return "Courses"; }
        }
        public CourseConfiguration()
        {
            this.ToTable(TableName);
        }
    }
}