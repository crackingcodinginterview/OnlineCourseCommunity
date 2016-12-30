using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Models.Account
{
    public class RegisterBindingModel
    {
        /// <summary>
        /// Username
        /// </summary>
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}