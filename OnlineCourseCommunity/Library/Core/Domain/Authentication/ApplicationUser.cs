using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCourseCommunity.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Core.Domain.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// IsDelete
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Picture Id
        /// </summary>
        public string PictureId { get; set; }
        /// <summary>
        /// Money Left
        /// </summary>
        public int Money { get; set; }

        public ApplicationUser()
        {

        }
        public ApplicationUser(FacebookDataModel facebookDataModel)
        {
            LastName = facebookDataModel.LastName;
            FirstName = facebookDataModel.FirstName;
            PictureId = facebookDataModel.AvatarUrl;
        }
    }
}