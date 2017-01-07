using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNet.Identity;
using OnlineCourseCommunity.Filters;
using OnlineCourseCommunity.Library.Core.Domain.Bussiness;
using OnlineCourseCommunity.Library.Service.Interface.Authentication;
using OnlineCourseCommunity.Library.Service.Interface.Bussiness;
using OnlineCourseCommunity.Models.Course;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineCourseCommunity.Controllers
{
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private readonly Cloudinary _cloudinaryService;
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        public CoursesController(ICourseService courseService,
            IUserService userService,
            IProfileService profileService,
            Cloudinary cloudinaryService)
        {
            this._cloudinaryService = cloudinaryService;
            this._courseService = courseService;
            this._userService = userService;
            this._profileService = profileService;
        }

        /// <summary>
        /// Get all course
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(200, "Get all course", typeof(CoursePagingResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> GetCourseList(string keySort = null, bool orderDescending = true,
            string keyWord = null,  int pageIndex = 0, int? pageSize = null)
        {
            var res = new CoursePagingResponseModel();
            try
            {
                var courses = await this._courseService.GetCourseList(keySort, orderDescending, keyWord, pageIndex, pageSize);
                if (courses == null || !courses.Any())
                {
                    res.ErrorMessages.Add("Cannot Find Any Course Match With Id!");
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
                }
                res.Import(courses.PageIndex, courses.PageSize,
                    courses.TotalCount, courses.TotalPages,
                    courses.HasPreviousPage, courses.HasNextPage,
                    courses);
                res.Success = true;
                return this.Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }
        /// <summary>
        /// Get course by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{courseId}")]
        [SwaggerResponse(200, "Get course by id")]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> GetCourseById(string courseId)
        {
            try
            {
                var course = await this._courseService.GetById(courseId);
                if (course == null)
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Something Went Wrong!");
                var userId = User.Identity.GetUserId();
                var profile = await this._profileService.GetProfileByUserId(userId);
                if (profile != null)
                {
                    var isPurchased = await this._courseService.IsUserPurchasedCourse(courseId, profile.Id);
                    if (isPurchased)
                    {
                        var res1 = new FullCourseResponseModel(course);
                        res1.Success = true;
                        return this.Request.CreateResponse(HttpStatusCode.OK, res1);
                    }
                }
                var res = new SimpleCourseResponseModel(course);
                res.Success = true;
                return this.Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (ApplicationException ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Something Went Wrong!");
            }
        }
        /// <summary>
        /// Admin add new course to website
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerResponse(200, "Admin add new course to website", typeof(FullCourseResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> AddNewCourse([FromBody] AddOrUpdateCourseBindingModel addOrUpdateCourseBindingModel)
        {
            var res = new FullCourseResponseModel();
            try
            {
                var userId = User.Identity.GetUserId();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(addOrUpdateCourseBindingModel.ImageUrl)
                };
                var uploadResult = await this._cloudinaryService.UploadAsync(uploadParams);
                var course = new Course()
                {
                    Name = addOrUpdateCourseBindingModel.Name,
                    ImageUrl = uploadResult.Uri.ToString(),
                    SourceLink = addOrUpdateCourseBindingModel.SourceLink,
                    AuthorName = addOrUpdateCourseBindingModel.AuthorName,
                    Description = addOrUpdateCourseBindingModel.Description,
                    DownloadLink = addOrUpdateCourseBindingModel.DownloadLink,
                    AboutThisCourse = addOrUpdateCourseBindingModel.AboutThisCourse,
                    Price = addOrUpdateCourseBindingModel.Price,
                    Category = addOrUpdateCourseBindingModel.Category,
                    SubCategory = addOrUpdateCourseBindingModel.SubCategory,
                    OwnerId = userId
                };
                await this._courseService.CreateAsync(course);
                res.Import(course);
                res.Success = true;
                return this.Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (ApplicationException ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }
        /// <summary>
        /// Admin update a course information
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("{courseId}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerResponse(200, "Admin update a course information", typeof(FullCourseResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> UpdateExistingCourse(string courseId, [FromBody] AddOrUpdateCourseBindingModel addOrUpdateCourseBindingModel)
        {
            var res = new FullCourseResponseModel();
            try
            {
                var course = await this._courseService.GetById(courseId);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(addOrUpdateCourseBindingModel.ImageUrl)
                };
                var uploadResult = await this._cloudinaryService.UploadAsync(uploadParams);
                if (course != null)
                {
                    course.Name = addOrUpdateCourseBindingModel.Name;
                    course.ImageUrl = uploadResult.Uri.ToString();
                    course.SourceLink = addOrUpdateCourseBindingModel.SourceLink;
                    course.AuthorName = addOrUpdateCourseBindingModel.AuthorName;
                    course.Description = addOrUpdateCourseBindingModel.Description;
                    course.DownloadLink = addOrUpdateCourseBindingModel.DownloadLink;
                    course.AboutThisCourse = addOrUpdateCourseBindingModel.AboutThisCourse;
                    course.Price = addOrUpdateCourseBindingModel.Price;
                    course.Category = addOrUpdateCourseBindingModel.Category;
                    course.SubCategory = addOrUpdateCourseBindingModel.SubCategory;
                    await this._courseService.UpdateAsync(course);
                    res.Import(course);
                    res.Success = true;
                    return this.Request.CreateResponse(HttpStatusCode.OK, res);
                }
                res.ErrorMessages.Add("Cannot Find Any Course Match With Id!");
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
            catch (Exception ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }
        /// <summary>
        /// Admin Delete Course
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("{courseId}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerResponse(200, "Admin Delete Course", typeof(DeleteCourseResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> DeleteCourse(string courseId)
        {
            var res = new DeleteCourseResponseModel();
            try
            {
                var course = await this._courseService.GetById(courseId);
                if (course != null)
                {
                    await this._courseService.DeleteAsync(course);
                    res.Success = true;
                    return this.Request.CreateResponse(HttpStatusCode.OK, res);
                }
                res.ErrorMessages.Add("Cannot Find Any Course Match With Id!");
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
            catch (Exception ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }
        /// <summary>
        /// Unlock course
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("{courseId}/Unlock")]
        [Authorize]
        [SwaggerResponse(200, "Unlock course", typeof(UnlockCourseResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> UnlockCourse(string courseId)
        {
            var res = new UnlockCourseResponseModel();
            try
            {
                var userId = User.Identity.GetUserId();
                var profile = await this._profileService.GetProfileByUserId(userId);
                var course = await this._courseService.GetById(courseId);
                if(profile.Money > course.Price)
                {
                    profile.Money -= course.Price;
                    course.PurchasedProfileList.Add(profile);
                    await this._profileService.UpdateAsync(profile);
                    await this._courseService.UpdateAsync(course);
                    res.Import(course, profile);
                    res.Success = true;
                    return this.Request.CreateResponse(HttpStatusCode.OK, res);
                }
                res.ErrorMessages.Add("You Don't Have Enough Money!");
                return this.Request.CreateResponse(HttpStatusCode.BadGateway, res);
            }
            catch (Exception ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }
        /// <summary>
        /// User Rating A Course
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("{courseId}/RateCourse")]
        [Authorize]
        [SwaggerResponse(200, "User Rating A Course", typeof(IncreaseViewCountResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> RateCourse(string courseId, RatingCoureBindingModel ratingCoureBindingModel)
        {
            var res = new RatingCoureResponseModel();
            try
            {
                var course = await this._courseService.GetById(courseId);
                if (course != null)
                {
                    course.Rating += ratingCoureBindingModel.Number;
                    await this._courseService.UpdateAsync(course);
                    res.Import(course);
                    res.Success = true;
                    return this.Request.CreateResponse(HttpStatusCode.OK, res);
                }
                res.ErrorMessages.Add("Cannot Find Any Course Match With This Id!");
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
            catch (Exception ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }
        /// <summary>
        /// Increase View Count
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("{courseId}/IncreaseView")]
        [SwaggerResponse(200, "Increase View Count")]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> IncreaseViewCount(string courseId)
        {
            var res = new IncreaseViewCountResponseModel();
            try
            {
                var course = await this._courseService.GetById(courseId);
                if(course != null)
                {
                    course.ViewCount += 1;
                    await this._courseService.UpdateAsync(course);
                    res.Import(course);
                    res.Success = true;
                    return this.Request.CreateResponse(HttpStatusCode.OK, res);
                }
                res.ErrorMessages.Add("Cannot Find Any Course Match With This Id!");
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
            catch (Exception ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }
    }
}
