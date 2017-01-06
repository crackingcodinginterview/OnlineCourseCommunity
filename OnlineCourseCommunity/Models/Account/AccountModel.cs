﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace OnlineCourseCommunity.Models.Account
{
    public class FacebookDataModel
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string Provider { get; set; }
        public string ProviderName { get; set; }
        public string AvatarUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public FacebookDataModel()
        {

        }
        public FacebookDataModel(ClaimsIdentity claimIdentity)
        {
            this.Import(claimIdentity);
        }

        public void Import(ClaimsIdentity claimIdentity)
        {
            Claim providerKeyClaim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            UserName = claimIdentity.FindFirstValue(ClaimTypes.Name);
            //var facebookUserID = claimIdentity.FindFirst(c => c.Type == "urn:facebook:id").Value;
            //string profilePicturePath = string.Format("http://graph.facebook.com/{0}/picture?type=large", facebookUserID);
            //AccessToken = claimIdentity.FindFirstValue("ExternalAccessToken");
            Provider = providerKeyClaim.Value;
            ProviderName = providerKeyClaim.Issuer;
        }
    }
}