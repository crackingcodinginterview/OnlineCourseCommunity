using OnlineCourseCommunity.Library.Core.Domain;
using OnlineCourseCommunity.Library.Service.Interface;
using OnlineCourseCommunity.Library.Service.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineCourseCommunity.Library.Service.Implement.Authentication
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(DbContext context) : base(context)
        {
        }
    }
}