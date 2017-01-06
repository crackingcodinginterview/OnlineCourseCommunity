
using OnlineCourseCommunity.Filters;
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
        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [SwaggerResponse(200, "Return profile of current user", typeof(ProfileResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<HttpResponseMessage> GetProfile(string userId)
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, "");
        }
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="registerBindingModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("Register", Name = "Register")]
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
                await this._userService.RegisterUserAsync(registerBindingModel.UserName, registerBindingModel.Password);
                res.Success = true;
                return this.Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (ApplicationException ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }
    }
}
