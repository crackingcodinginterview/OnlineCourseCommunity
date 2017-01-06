using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Data.Entity;
using OnlineCourseCommunity.Library.Service.Interface.Authentication;
using System.Security.Claims;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using Newtonsoft.Json.Linq;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity.Owin;

namespace OnlineCourseCommunity.Library.Service.Implement.Authentication
{
    public class UserService : IUserService
    {
        private DbContext _ctx;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserService(DbContext context)
        {
            this._ctx = context;
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));
            this._roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_ctx));
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return await this._userManager.FindByIdAsync(userId);
        }
        public async Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user)
        {
            ClaimsIdentity identity = await this._userManager.CreateIdentityAsync(
                user,
                DefaultAuthenticationTypes.ExternalBearer);
            return identity;
        }
        public string GenerateLocalAccessTokenResponse(ApplicationUser user)
        {
            var tokenExpiration = TimeSpan.FromDays(1);
            ClaimsIdentity identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "USER"));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            var props = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
            };
            var ticket = new AuthenticationTicket(identity, props);
            var accessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);
            return accessToken;
        }
        public async Task<ApplicationUser> RegisterUserAsync(string username, string password)
        {
            var currentUser = await FindUserAsync(username, password);
            if (currentUser != null)
                throw new ApplicationException("User already exist!");
            ApplicationUser user = new ApplicationUser
            {
                UserName = username
            };
            return await RegisterUserAsync(user, password);
        }
        public async Task<ApplicationUser> RegisterUserAsync(ApplicationUser user, string password)
        {
            var userCreateResult = await this._userManager.CreateAsync(user, password);
            if (!userCreateResult.Succeeded)
                throw new ApplicationException("Add User Failed!");
            var isRoleExist = await this._roleManager.RoleExistsAsync("USER");
            if (!isRoleExist)
            {
                var roleResult = await this._roleManager.CreateAsync(new IdentityRole("USER"));
                if (!roleResult.Succeeded)
                    throw new ApplicationException("Creating role failed with error(s): " + roleResult.Errors);
            }
            var isInRole = await this._userManager.IsInRoleAsync(user.Id, "USER");
            if (!isInRole)
            {
                var addToRoleResult = await this._userManager.AddToRoleAsync(user.Id, "USER");
                if (!addToRoleResult.Succeeded)
                    throw new ApplicationException("Add To Role Failed!");
            }
            return user;
        }

        public async Task<ApplicationUser> FindUserAsync(string userName, string password)
        {
            return await this._userManager.FindAsync(userName, password);
        }
    }
}