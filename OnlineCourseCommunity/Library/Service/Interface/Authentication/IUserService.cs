using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        Task<ClaimsIdentity> CreateIdentityAsync(User user);
        Task<User> RegisterUserAsync(string username, string password);
        Task<User> FindUserAsync(string userName, string password);
        Task<User> FindByIdAsync(string userId);
    }
}