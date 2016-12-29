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

namespace OnlineCourseCommunity.Library.Service.Implement.Authentication
{
    public class UserService : IUserService
    {
        private DbContext _ctx;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserService(DbContext context)
        {
            this._ctx = context;
            this._userManager = new UserManager<User>(new UserStore<User>(_ctx));
            this._roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_ctx));
        }

        public async Task<User> FindByIdAsync(string userId)
        {
            return await this._userManager.FindByIdAsync(userId);
        }
        public async Task<ClaimsIdentity> CreateIdentityAsync(User user)
        {
            ClaimsIdentity identity = await this._userManager.CreateIdentityAsync(
                user,
                DefaultAuthenticationTypes.ExternalBearer);
            return identity;
        }
        public async Task<User> RegisterUserAsync(string username, string password)
        {
            var currentUser = await FindUserAsync(username, password);
            if (currentUser != null)
                throw new ApplicationException("User already exist!");
            User user = new User
            {
                UserName = username
            };
            var userCreateResult = await this._userManager.CreateAsync(user, password);
            if(!userCreateResult.Succeeded)
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

        public async Task<User> FindUserAsync(string userName, string password)
        {
            return await this._userManager.FindAsync(userName, password);
        }
    }
}