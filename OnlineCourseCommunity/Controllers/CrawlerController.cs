using HtmlAgilityPack;
using OnlineCourseCommunity.Models.Course;
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
        public async Task<HttpResponseMessage> GetCourseInformation(string courseLink)
        {
            var res = new TamperCourseResponseModel();
            try
            {
                var website = new HtmlWeb();
                var doc = website.Load(courseLink);
                var courseNameNode = doc.DocumentNode.SelectSingleNode("//meta[@property='og:title']");
                var courseName = courseNameNode.InnerText.Trim();
                var courseDescriptionNode = doc.DocumentNode.SelectSingleNode("//property[@class='og:description']");
                var courseDescription = courseDescriptionNode.Attributes["content"].Value.Trim();
                var courseAuthorNode = doc.DocumentNode.SelectSingleNode("//a[@class='instructor-links__link']");
                var courseAuthor = courseAuthorNode.InnerText.Trim();
                var courseImageNode = doc.DocumentNode.SelectSingleNode("//meta[@property='og:image']");
                var courseImage = courseImageNode.Attributes["content"].Value.Trim();
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                res.ErrorMessages.Add(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, res);
            }
        }
    }
}
