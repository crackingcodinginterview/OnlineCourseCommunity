using OnlineCourseCommunity.Library.Core.Domain.Bussiness;
using OnlineCourseCommunity.Library.Service.Interface.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using OnlineCourseCommunity.Library.Core;
using System.Linq.Expressions;
using System.Reflection;
using OnlineCourseCommunity.Library.Common;

namespace OnlineCourseCommunity.Library.Service.Implement.Bussiness
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        protected readonly string defaultKeySort = "CreateOnDate";
        protected readonly string defaultKeyCompare = "Name";
        public CourseService(DbContext context)
            : base(context)
        {
        }

        public async Task<bool> IsUserPurchasedCourse(string courseId, string profileId)
        {
            return await this._dbSet.Where(o => o.PurchasedProfileList.Any(b => b.Id == profileId))
                .CountAsync() > 0;
        }
        public async Task<PagedList<Course>> GetCourseList(
            string keySort = null, bool orderDescending = true, string keyCompare = null,
            string keyWord = null, int pageIndex = 0, int? pageSize = null)
        {
            IQueryable<Course> query = this._dbSet.AsQueryable();

            var coursePropertyList = typeof(Course).GetProperties();
            var sortProperty = coursePropertyList.FirstOrDefault(p => string.Compare(p.Name, keySort, StringComparison.OrdinalIgnoreCase) == 0);
            keySort = (keySort == null) ? defaultKeySort : sortProperty.Name;
            if (!string.IsNullOrEmpty(keyWord))
            {
                var keyCompareProperty = coursePropertyList.FirstOrDefault(p => string.Compare(p.Name, keyCompare, StringComparison.OrdinalIgnoreCase) == 0);
                var keyComparePropertyDefault = coursePropertyList.FirstOrDefault(p => string.Compare(p.Name, defaultKeyCompare, StringComparison.OrdinalIgnoreCase) == 0);
                keyCompareProperty = (keyCompareProperty == null) ? keyComparePropertyDefault : keyCompareProperty;
                object targetValue = keyWord;
                if (keyCompareProperty.PropertyType.FullName.Contains("Int32"))
                    targetValue = int.Parse(keyWord);
                else if (keyCompareProperty.PropertyType.FullName.Contains("Category"))
                    targetValue = Enum.Parse(typeof(Category), keyWord);
                else if (keyCompareProperty.PropertyType.FullName.Contains("SubCategory"))
                    targetValue = Enum.Parse(typeof(Category), keyWord);
                else if (keyCompareProperty.PropertyType.FullName.Contains("Double"))
                    targetValue = Enum.Parse(typeof(Category), keyWord);
                query = query.Where(Linq.PropertyEquals<Course, object>(keyCompareProperty, targetValue));
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