using OnlineCourseCommunity.Library.Common;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineCourseCommunity.Library.Core.Domain.Bussiness;

namespace OnlineCourseCommunity.Models.Course
{

    public class UnlockCourseResponseModel : HmJsonResult
    {
        public UnlockCourseResponseModel()
        {

        }
        public UnlockCourseResponseModel(Library.Core.Domain.Bussiness.Course course)
        {
            this.Import(course);
        }
        public void Import(Library.Core.Domain.Bussiness.Course course)
        {
            base.Data = new
            {
                DownloadLink = course.DownloadLink
            };
        }
    }
    public class IncreaseViewCountResponseModel : HmJsonResult
    {

    }
    public class CoureBoxModel
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
        public CoureBoxModel()
        {

        }

        public CoureBoxModel(Library.Core.Domain.Bussiness.Course course)
        {
            CourseId = course.Id;
            Name = course.Name;
            Rating = course.Rating;
            ImageUrl = course.ImageUrl;
        }
    }
    public class CoursePagingResponseModel : HmJsonResult
    {
        public CoursePagingResponseModel()
        {

        }
        public CoursePagingResponseModel(int pageIndex, int pageSize,
            int totalCount, int totalPage,
            bool hasPreviousPage, bool hasNextPage,
            List<OnlineCourseCommunity.Library.Core.Domain.Bussiness.Course> courseList)
        {
            this.Import(pageIndex, pageSize, totalCount, totalPage, hasPreviousPage, hasNextPage, courseList);
        }
        public void Import(int pageIndex, int pageSize,
            int totalCount, int totalPage,
            bool hasPreviousPage, bool hasNextPage,
            List<OnlineCourseCommunity.Library.Core.Domain.Bussiness.Course> courseList)
        {
            base.Data = new
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPage = totalPage,
                HasPreviousPage = hasPreviousPage,
                HasNextPage = hasNextPage,
                CourseList = courseList.Select(o => new CoureBoxModel(o))
            };
        }
    }
    public class FullCourseResponseModel : HmJsonResult
    {
        public FullCourseResponseModel()
        {

        }
        public FullCourseResponseModel(OnlineCourseCommunity.Library.Core.Domain.Bussiness.Course course)
        {
            this.Import(course);
        }
        public void Import(OnlineCourseCommunity.Library.Core.Domain.Bussiness.Course course)
        {
            base.Data = new
            {
                Name = course.Name,
                ImageUrl = course.ImageUrl,
                Description = course.Description,
                AuthorName = course.AuthorName,
                ViewCount = course.ViewCount,
                Rating = course.Rating,
                SourceLink = course.SourceLink,
                DownloadLink = course.DownloadLink,
                PurchaseUserList = course.PurchaseUserList
            };
        }
    }
    public class SimpleCourseResponseModel : HmJsonResult
    {
        public SimpleCourseResponseModel()
        {

        }
        public SimpleCourseResponseModel(OnlineCourseCommunity.Library.Core.Domain.Bussiness.Course course)
        {
            this.Import(course);
        }
        public void Import(OnlineCourseCommunity.Library.Core.Domain.Bussiness.Course course)
        {
            base.Data = new
            {
                Name = course.Name,
                ImageUrl = course.ImageUrl,
                Description = course.Description,
                AuthorName = course.AuthorName,
                ViewCount = course.ViewCount,
                Rating = course.Rating,
                SourceLink = course.SourceLink,
            };
        }
    }
    public class PurchasedResponseModel : HmJsonResult
    {
        public PurchasedResponseModel()
        {

        }
        public PurchasedResponseModel(OnlineCourseCommunity.Library.Core.Domain.Bussiness.Course course)
        {
            this.Import(course);
        }
        public void Import(OnlineCourseCommunity.Library.Core.Domain.Bussiness.Course course)
        {
            base.Data = new
            {
                Name = course.Name,
                ImageUrl = course.ImageUrl,
                Description = course.Description,
                AuthorName = course.AuthorName,
                ViewCount = course.ViewCount,
                Rating = course.Rating,
                SourceLink = course.SourceLink,
                DownloadLink = course.DownloadLink,
            };
        }
    }
}