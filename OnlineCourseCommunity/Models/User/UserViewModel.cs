using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCourseCommunity.Library.Common;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Models.User
{
    public class UserInforResponseModel : HmJsonResult
    {
        public UserInforResponseModel()
        {

        }
        public UserInforResponseModel(IdentityUser user)
        {
            this.Import(user);
        }
        public void Import(IdentityUser user)
        {
            base.Data = new
            {
                UserId = user.Id,
                UserName = user.UserName
            };
        }
    }
    public class ProfileResponseModel : HmJsonResult
    {
        public ProfileResponseModel()
        {

        }
        public ProfileResponseModel(Profile profile)
        {
            this.Import(profile);
        }
        public void Import(Profile profile)
        {
            base.Data = new
            {
                FullName = profile.FirstName + " " + profile.LastName,
                Money = profile.Money,
                PictureUrl = profile.AvatarUrl
            };
        }
    }
    public class RegisterResponseModel : HmJsonResult
    {
    }
}