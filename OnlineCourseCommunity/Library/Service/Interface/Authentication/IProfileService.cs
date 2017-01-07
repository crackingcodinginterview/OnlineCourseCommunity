using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OnlineCourseCommunity.Library.Service.Interface.Authentication
{
    public interface IProfileService : IBaseService<Profile>
    {
        Task<Profile> GetProfileByUserId(string userId);
    }
}