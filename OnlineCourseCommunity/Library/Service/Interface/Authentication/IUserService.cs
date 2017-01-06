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
        Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user);
        Task<ApplicationUser> RegisterUserAsync(string username, string password);
        Task<ApplicationUser> FindUserAsync(string userName, string password);
        Task<ApplicationUser> FindByIdAsync(string userId);
        string GenerateLocalAccessTokenResponse(ApplicationUser user);
        Task<ApplicationUser> RegisterUserAsync(ApplicationUser user, string password);
    }
}