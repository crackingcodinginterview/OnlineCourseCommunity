using OnlineCourseCommunity.Library.Core.Domain.Bussiness;
using OnlineCourseCommunity.Library.Service.Interface.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using OnlineCourseCommunity.Library.Core;

namespace OnlineCourseCommunity.Library.Service.Implement.Bussiness
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        protected readonly string defaultKeySort = "CreateOnDate";
        public CourseService(DbContext context)
            : base(context)
        {
        }

        public async Task<bool> IsUserPurchasedCourse(string courseId, string userId)
        {
            return false;
        }
        public async Task<PagedList<Course>> GetCourseList(string keySort = null, bool orderDescending = true,
            string keyWord = null, int pageIndex = 0, int? pageSize = null)
        {
            IQueryable<Course> query = this._dbSet.AsQueryable();

            if (string.IsNullOrEmpty(keySort))
            {
                var property = typeof(Course).GetProperties().FirstOrDefault(p => string.Compare(p.Name, keySort,
                StringComparison.OrdinalIgnoreCase) == 0);
                keySort = (property == null) ? defaultKeySort : property.Name;
            }

            if (!string.IsNullOrEmpty(keyWord))
            {
                query = query.Where(o => o.Name.Contains(keyWord));
            }
            if(pageSize == null)
            {
                pageSize = query.Count();
            }
            query = orderDescending ? query.OrderByDescending(keySort) : query.OrderBy(keySort);
            return new PagedList<Course>(query, pageIndex, pageSize.GetValueOrDefault());
        }
    }
}