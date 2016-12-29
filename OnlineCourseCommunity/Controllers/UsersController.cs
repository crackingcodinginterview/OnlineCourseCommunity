using Newtonsoft.Json.Linq;
using OnlineCourseCommunity.Library.Service.Interface.Authentication;
using OnlineCourseCommunity.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using static OnlineCourseCommunity.Models.Account.AccountViewModel;
using Microsoft.AspNet.Identity;
using OnlineCourseCommunity.ActionResult;

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

        //[HttpGet]
        //[Authorize(Roles = "USER")]
        //public string testUser()
        //{
        //    return "aaa";
        //}
        [HttpGet]
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            if(!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }
            return Ok("WTF");
        }

        [HttpGet]
        [Authorize]
        public async Task<HttpResponseMessage> GetProfile()
        {
            var res = new ProfileResponseModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    res.ErrorMessages = base.GetModelErrorMessages(ModelState);
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
                }
                var userId = User.Identity.GetUserId();
                var user = await this._userService.FindByIdAsync(userId);
                res.Import(user);
                res.Success = true;
                return this.Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (ApplicationException ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<HttpResponseMessage> Register([FromBody]AccountBindingModel loginModel)
        {
            var res = new RegisterResponseModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    res.ErrorMessages = base.GetModelErrorMessages(ModelState);
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
                }
                await this._userService.RegisterUserAsync(loginModel.UserName, loginModel.Password);
                res.Success = true;
                return this.Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch(ApplicationException ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }
    }
}
