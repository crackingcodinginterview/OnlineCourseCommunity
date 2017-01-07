using OnlineCourseCommunity.Library.Common;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineCourseCommunity.Library.Core.Domain.Bussiness;

namespace OnlineCourseCommunity.Models.Course
{
    public class DeleteCourseResponseModel : HmJsonResult
    {

    }
    public class UnlockCourseResponseModel : HmJsonResult
    {
        public UnlockCourseResponseModel()
        {

        }
        public UnlockCourseResponseModel(Library.Core.Domain.Bussiness.Course course,
            Profile profile)
        {
            this.Import(course, profile);
        }
        public void Import(Library.Core.Domain.Bussiness.Course course,
            Profile profile)
        {
            base.Data = new
            {
                DownloadLink = course.DownloadLink,
                MoneyLeft = profile.Money
            };
        }
    }
    public class RatingCoureResponseModel : HmJsonResult
    {
        public RatingCoureResponseModel()
        {

        }
        public RatingCoureResponseModel(Library.Core.Domain.Bussiness.Course course)
        {
            this.Import(course);
        }
        public void Import(Library.Core.Domain.Bussiness.Course course)
        {
            base.Data = new
            {
                Rating = course.Rating
            };
        }
    }
    public class IncreaseViewCountResponseModel : HmJsonResult
    {
        public IncreaseViewCountResponseModel()
        {

        }
        public IncreaseViewCountResponseModel(Library.Core.Domain.Bussiness.Course course)
        {
            this.Import(course);
        }
        public void Import(Library.Core.Domain.Bussiness.Course course)
        {
            base.Data = new
            {
                ViewCount = course.ViewCount
            };
        }
    }
    public class CoureBoxModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public CoureBoxModel()
        {

        }

        public CoureBoxModel(Library.Core.Domain.Bussiness.Course course)
        {
            Id = course.Id;
            Name = course.Name;
            Rating = course.Rating;
            ImageUrl = course.ImageUrl;
            Price = course.Price;
            Description = course.Description;
            AuthorName = course.AuthorName;
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
                Id = course.Id,
                Name = course.Name,
                ImageUrl = course.ImageUrl,
                Description = course.Description,
                AuthorName = course.AuthorName,
                ViewCount = course.ViewCount,
                Rating = course.Rating,
                SourceLink = course.SourceLink,
                Price = course.Price,
                AboutThisCourse = course.AboutThisCourse,
                Category = course.Category,
                Subcategory = course.SubCategory,
                DownloadLink = course.DownloadLink
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
                Id = course.Id,
                Name = course.Name,
                ImageUrl = course.ImageUrl,
                Description = course.Description,
                AuthorName = course.AuthorName,
                ViewCount = course.ViewCount,
                Rating = course.Rating,
                SourceLink = course.SourceLink,
                Price = course.Price,
                AboutThisCourse = course.AboutThisCourse,
                Category = course.Category,
                Subcategory = course.SubCategory
            };
        }
    }
    public class TamperCourseResponseModel : HmJsonResult
    {
        public TamperCourseResponseModel()
        {

        }
        public TamperCourseResponseModel(string Name, string Description,
            string AuthorName, string ImageUrl)
        {
            this.Import(Name, Description, AuthorName, ImageUrl);
        }
        public void Import(string Name, string Description,
            string AuthorName, string ImageUrl)
        {
            base.Data = new
            {
                Name = Name,
                ImageUrl = ImageUrl,
                Description = Description,
                AuthorName = AuthorName,
            };
        }
    }
}