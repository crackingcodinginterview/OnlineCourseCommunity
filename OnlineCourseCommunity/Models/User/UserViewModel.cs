using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCourseCommunity.Library.Common;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Models.User
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public UserModel()
        {

        }
        public UserModel(IdentityUser user)
        {
            this.Import(user);
        }
        public void Import(IdentityUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
        }
    }
    
    public class DeleteUserResponseModel : HmJsonResult
    {
        public DeleteUserResponseModel()
        {

        }
    }
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
                Id = user.Id,
                UserName = user.UserName
            };
        }
    }
    public class UserPagingResponseModel : HmJsonResult
    {
        public UserPagingResponseModel()
        {

        }
        public UserPagingResponseModel(List<IdentityUser> listUser)
        {
            this.Import(listUser);
        }
        public void Import(List<IdentityUser> listUser)
        {
            base.Data = new
            {
                UserList = listUser.Select(o => new UserModel(o))
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