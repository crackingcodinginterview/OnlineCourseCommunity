using OnlineCourseCommunity.Library.Common;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Models.User
{
    public class ProfileResponseModel : HmJsonResult
    {
        public ProfileResponseModel()
        {

        }
        public ProfileResponseModel(ApplicationUser user)
        {
            this.Import(user);
        }
        public void Import(ApplicationUser user)
        {
            base.Data = new
            {
                Email = user.Email,
                FullName = user.FirstName + user.LastName,
                Money = user.Money,
                PictureUrl = user.PictureId
            };
        }
    }
    public class RegisterResponseModel : HmJsonResult
    {
    }
}