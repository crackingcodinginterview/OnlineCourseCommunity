using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using OnlineCourseCommunity.Library.Service.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;

namespace OnlineCourseCommunity.Library.Service.Implement.Authentication
{
    public class ProfileService : BaseService<Profile>, IProfileService
    {
        public ProfileService(DbContext context) 
            : base(context)
        {
        }

        public async Task<Profile> GetProfileByUserId(string userId)
        {
            var result = await this._dbSet
                .FirstOrDefaultAsync(o => o.UserId == userId);
            return result;
        }
    }
}