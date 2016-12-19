using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Core.Domain.Authentication
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}