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
using Microsoft.AspNet.Identity;
using OnlineCourseCommunity.ActionResult;
using System.Security.Claims;
using Swashbuckle.Swagger.Annotations;
using OnlineCourseCommunity.Filters;
using OnlineCourseCommunity.Library.Core.Domain.Authentication;
using OnlineCourseCommunity.Models.User;

namespace OnlineCourseCommunity.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// Use for facebook login
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        [HttpGet]
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        [SwaggerResponse(200, "Auto redirect to callback url")]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            if(error != null) return BadRequest(Uri.EscapeDataString(error));
            if(!User.Identity.IsAuthenticated) return new ChallengeResult(provider, this);
            var queryString = Request.GetQueryNameValuePairs();
            var redirectUri = queryString.FirstOrDefault(keyValue => string.Compare(keyValue.Key, "redirectUri", true) == 0).Value;
            var facebookLoginModel = new FacebookDataModel(User.Identity as ClaimsIdentity);
            ApplicationUser user = await this._userService.FindUserAsync(facebookLoginModel.Provider, facebookLoginModel.ProviderName);
            if (user == null)
                user = await this._userService.RegisterUserAsync(facebookLoginModel.Provider, facebookLoginModel.ProviderName);
            var localAccessToken = this._userService.GenerateLocalAccessTokenResponse(user);
            redirectUri = string.Format("{0}#access_token={1}&provider={2}",
                                redirectUri,
                                localAccessToken,
                                "Facebook");
            return Redirect(redirectUri);
        }
        /// <summary>
        /// Return profile of current user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("GetProfile", Name = "GetProfile")]
        [SwaggerResponse(200, "Return profile of current user", typeof(ProfileResponseModel))]
        [SwaggerResponse(400, "Bad request")]
        [SwaggerResponse(401, "Don't have permission")]
        [SwaggerResponse(500, "Internal Server Error")]
        [ValidateModelAttribute]
        public async Task<HttpResponseMessage> GetProfile()
        {
            var res = new ProfileResponseModel();
            try
            {
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
    }
}
