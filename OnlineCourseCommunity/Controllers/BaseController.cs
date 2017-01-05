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
    }
}