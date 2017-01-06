﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Core.Domain.Bussiness
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public int ViewCount { get; set; }
        public double Rating { get; set; }
        public string SourceLink { get; set; }
        public string DownloadLink { get; set; }
        public virtual ICollection<IdentityUser> PurchaseUserList { get; set; }
    }
}