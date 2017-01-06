using OnlineCourseCommunity.Library.Core.Domain.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Core.Domain.Authentication
{
    public class Profile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Money { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Course> PurchaseCourseList { get; set; }
    }
}