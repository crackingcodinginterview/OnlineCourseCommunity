using Facebook;
using Microsoft.Owin.Security.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace OnlineCourseCommunity.Providers
{
    public class FacebookAuthProvider : FacebookAuthenticationProvider
    {
        public override Task Authenticated(FacebookAuthenticatedContext context)
        {
            var facebookClient = new FacebookClient(context.AccessToken);
            var myInfo = facebookClient.Get("/me?fields=email,first_name,last_name,picture") as IDictionary<string, object>;
            context.Identity.AddClaim(new Claim("ExternalAccessToken", context.AccessToken));
            context.Identity.AddClaim(new Claim("FirstName", myInfo["first_name"].ToString()));
            context.Identity.AddClaim(new Claim("LastName", myInfo["last_name"].ToString()));
            context.Identity.AddClaim(new Claim("Avatar", ((myInfo["picture"] as IDictionary<string, object>)["data"] as IDictionary<string, object>)["url"].ToString()));
            context.Identity.AddClaim(new Claim("Email", myInfo["email"].ToString()));
            context.Identity.AddClaim(new Claim("Id", myInfo["id"].ToString()));
            return Task.FromResult<object>(null);
        }
    }
}
