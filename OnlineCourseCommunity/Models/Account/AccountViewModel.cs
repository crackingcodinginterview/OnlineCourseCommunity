using OnlineCourseCommunity.Library.Common;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Results;

namespace OnlineCourseCommunity.Models.Account
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
        /// <summary>
        /// Id of user
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// UserName
        /// </summary>
        public string Username { get; set; }
        public ProfileResponseModel()
        {

        }
        public ProfileResponseModel(User user)
        {
            this.Import(user);
        }

        public void Import(User user)
        {
            base.Data = new
            {
                Id = Id,
                UserName = Username
            };
        }
    }
}