using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace OnlineCourseCommunity.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected BaseController()
        {

        }

        protected List<string> GetModelErrorMessages(
            ModelStateDictionary ModelState
            )
        {
            List<string> res = new List<string>();
            foreach (ModelState modelState in ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    res.Add(error.ErrorMessage);
                }
            }
            return res;
        }
    }
}