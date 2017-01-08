using Microsoft.AspNet.Identity;
using OnlineCourseCommunity.Filters;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using OnlineCourseCommunity.Library.Service.Interface.Authentication;
using OnlineCourseCommunity.Models.Account;
using OnlineCourseCommunity.Models.User;
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
    [RoutePrefix("api/Users")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        public UsersController(IUserService userService,
            IProfileService profileService)
        {
            this._userService = userService;
            this._profileService = profileService;
        }

        /// <summary>
        /// Return Profile List With Pagination
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerResponse(200, "Return Profile List With Pagination", typeof(UserPagingResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> GetUserList()
        {
            var res = new UserPagingResponseModel();
            try
            {
                var listUser = await this._userService.GetUserList();
                res.Import(listUser);
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
        /// Admin Delete User
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("{userId}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerResponse(200, "Admin Delete User", typeof(DeleteUserResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> DeleteCourse(string userId)
        {
            var res = new DeleteUserResponseModel();
            try
            {
                var user = await this._userService.FindByIdAsync(userId);
                if (user != null)
                {
                    var profile = await this._profileService.GetProfileByUserId(user.Id);
                    await this._profileService.DeleteAsync(profile);
                    await this._userService.DeleteUserAsync(user);
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
        /// Return profile of current user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerResponse(200, "Return profile of current user", typeof(UserInforResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> GetUserInformation(string userId)
        {
            var res = new UserInforResponseModel();
            try
            {
                var user = await this._userService.FindByIdAsync(userId);
                if(user != null)
                {
                    res.Import(user);
                    res.Success = true;
                    return this.Request.CreateResponse(HttpStatusCode.OK, res);
                }
                res.ErrorMessages.Add("Cannot Find Any User With This Id!");
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
            catch (Exception ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="registerBindingModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        [SwaggerResponse(200, "Register new user", typeof(RegisterResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> Register([FromBody]RegisterBindingModel registerBindingModel)
        {
            var res = new RegisterResponseModel();
            try
            {
                var user = await this._userService
                    .RegisterUserAsync(registerBindingModel.UserName, registerBindingModel.Password, "USER");
                if(user != null)
                {
                    var profile = new Profile()
                    {
                        UserId = user.Id
                    };
                    profile = await this._profileService.CreateAsync(profile);
                    res.Success = true;
                    return this.Request.CreateResponse(HttpStatusCode.OK, res);
                }
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
