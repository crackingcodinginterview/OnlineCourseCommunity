using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json.Linq;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace OnlineCourseCommunity.Library.Service.Interface.Authentication
{
    public interface IUserService 
    {
        Task<ClaimsIdentity> CreateIdentityAsync(IdentityUser user);
        Task<IdentityUser> RegisterUserAsync(string username, string password, string role);
        Task<IdentityUser> FindUserAsync(string userName, string password);
        Task<IdentityUser> FindByIdAsync(string userId);
        Task<string> GenerateLocalAccessTokenResponse(IdentityUser user);
        Task<IdentityUser> RegisterUserAsync(IdentityUser user, string password, string role);
        Task<string> GetRoleAsync(string userId);
        Task<bool> DeleteUserAsync(IdentityUser user);
        Task<List<IdentityUser>> GetUserList();
    }
}