using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using OnlineCourseCommunity.Library.Data;
using OnlineCourseCommunity.Library.Service.Implement.Authentication;
using OnlineCourseCommunity.Library.Service.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace OnlineCourseCommunity.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUserService _userService;
        public SimpleAuthorizationServerProvider()
        {
            DbContext context = new Context();
            this._userService = new UserService(context); ;
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            if (allowedOrigin == null)
                allowedOrigin = "*";
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var currentUser = await this._userService.FindUserAsync(context.UserName, context.Password);
            if (currentUser == null)
            {
                context.SetError("User not exist!");
                return;
            }
            ClaimsIdentity identity = await this._userService.CreateIdentityAsync(currentUser);
            context.Validated(identity);
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            context.AdditionalResponseParameters.Add("userID", context.Identity.FindFirstValue(ClaimTypes.Role));
            context.AdditionalResponseParameters.Add("role", context.Identity.FindFirstValue(ClaimTypes.NameIdentifier));

            return Task.FromResult<object>(null);
        }
    }
}