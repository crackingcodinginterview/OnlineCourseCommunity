using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace OnlineCourseCommunity.Models.Account
{
    public class FacebookLoginModel
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string Provider { get; set; }
        public string ProviderName { get; set; }

        public FacebookLoginModel()
        {

        }
        public FacebookLoginModel(ClaimsIdentity claimIdentity)
        {
            this.Import(claimIdentity);
        }

        public void Import(ClaimsIdentity claimIdentity)
        {
            Claim providerKeyClaim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            UserName = claimIdentity.FindFirstValue(ClaimTypes.Name);
            AccessToken = claimIdentity.FindFirstValue("ExternalAccessToken");
            Provider = providerKeyClaim.Value;
            ProviderName = providerKeyClaim.Issuer;
        }
    }
}