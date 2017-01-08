using HtmlAgilityPack;
using OnlineCourseCommunity.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
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
                var courseName = courseNameNode.Attributes["content"].Value.Trim();
                var courseDescriptionNode = doc.DocumentNode.SelectSingleNode("//meta[@property='og:description']");
                var courseDescription = courseDescriptionNode.Attributes["content"].Value.Trim();
                var courseAuthorNode = doc.DocumentNode.SelectSingleNode("//a[@class='thb-n prox ud-popup']");
                var courseAuthor = courseAuthorNode.InnerText.Trim();
                var courseImageNode = doc.DocumentNode.SelectSingleNode("//meta[@property='og:image']");
                var courseImage = courseImageNode.Attributes["content"].Value.Trim();
                Match match = Regex.Match(courseImage, @"480x270/(.+)\.jpg", RegexOptions.IgnoreCase);
                var courseUrl = match.Success ? "https://udemy-images.udemy.com/course/750x422/" + match.Groups[1].Value + ".jpg": "";
                res.Import(courseName, courseDescription, courseAuthor, courseImage);
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
