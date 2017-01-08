using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace OnlineCourseCommunity.Library.Common
{
    public static class Linq
    {
        public static Expression<Func<TItem, bool>> PropertyEquals<TItem, TValue>(
PropertyInfo property, TValue value)
        {
            var param = Expression.Parameter(typeof(TItem));
            var body = Expression.Equal(Expression.Property(param, property),
                Expression.Constant(value));
            return Expression.Lambda<Func<TItem, bool>>(body, param);
        }
    }
}