using OnlineCourseCommunity.Library.Core;
using OnlineCourseCommunity.Library.Core.Domain.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OnlineCourseCommunity.Library.Service.Interface.Bussiness
{
    public interface ICourseService : IBaseService<Course>
    {
        Task<PagedList<Course>> GetCourseList(
            string keySort = null, bool orderDescending = true, string keyCompare = null,
            string keyWord = null, int pageIndex = 0, int? pageSize = null);
        Task<bool> IsUserPurchasedCourse(string courseId, string userId);
    }
}