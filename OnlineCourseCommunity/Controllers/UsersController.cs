using OnlineCourseCommunity.Library.Service.Interface.Authentication;
using OnlineCourseCommunity.Models.Account;
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
    }
}
