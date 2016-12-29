using OnlineCourseCommunity.Library.Common;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace OnlineCourseCommunity.Models.Account
{
    public class AccountViewModel
    {
        public class RegisterResponseModel : HmJsonResult
        {
            public RegisterResponseModel()
            {
                Success = false;
            }
        }
        public class ProfileResponseModel : HmJsonResult
        {
            public ProfileResponseModel()
            {

            }
            public void Import(User user)
            {
                base.Data = new 
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
            }
        }
    }
}