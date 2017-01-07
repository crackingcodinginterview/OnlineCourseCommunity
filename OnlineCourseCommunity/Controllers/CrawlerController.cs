using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineCourseCommunity.Controllers
{
    [RoutePrefix("api/Crawler")]
    public class CrawlerController : BaseController
    {
        public CrawlerController()
        {
                
        }
        [HttpGet]
        [Route("{courseLink}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<HttpResponseMessage> GetCourseInformation(string courseLink)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
            //try
            //{
            //    HtmlWeb
            //}
            //catch(Exception ex)
            //{

            //}
        }
    }
}
