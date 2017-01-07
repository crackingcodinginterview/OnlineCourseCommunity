using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Core.Domain.Bussiness
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public int ViewCount { get; set; }
        public double Rating { get; set; }
        public string SourceLink { get; set; }
        public string DownloadLink { get; set; }
        public int Price { get; set; }
        public string AboutThisCourse { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public string OwnerId { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual ICollection<Profile> PurchasedProfileList { get; set; }
        public Course()
        {
            Rating = 0;
            ViewCount = 0;
        }
    }
}