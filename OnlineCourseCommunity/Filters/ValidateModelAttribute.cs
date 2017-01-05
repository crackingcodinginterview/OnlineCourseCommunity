using OnlineCourseCommunity.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OnlineCourseCommunity.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (!actionContext.ModelState.IsValid)
            {
                HmJsonResult res = new HmJsonResult();
                foreach(var modelState in actionContext.ModelState.Values)
                {
                    foreach(var error in modelState.Errors)
                    {
                        res.ErrorMessages.Add(error.ErrorMessage);
                    }
                }
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, res);
                Task.FromResult(0);
            }
        }
    }
}