using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Models.Course
{
    public class RatingCoureBindingModel
    {
        /// <summary>
        /// Number
        /// </summary>
        [Required(ErrorMessage = "Number Is Require!")]
        public int Number { get; set; }
    }
    public class UnlockCourseBindingModel
    {
        /// <summary>
        /// User Id
        /// </summary>
        [Required(ErrorMessage = "UserId Is Require!")]
        public string UserId { get; set; }
    }
    public class AddCourseBindingModel
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "Name Of Course Is Require!")]
        public string Name { get; set; }
        /// <summary>
        /// Image Url
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Required(ErrorMessage = "Description Of Course Is Require!")]
        public string Description { get; set; }
        /// <summary>
        /// Author Name
        /// </summary>
        [Required(ErrorMessage = "AuthorName Of Course Is Require!")]
        public string AuthorName { get; set; }
        /// <summary>
        /// Source Link
        /// </summary>
        public string SourceLink { get; set; }
        /// <summary>
        /// About This Course
        /// </summary>
        public string AboutThisCourse { get; set; }
        /// <summary>
        /// Download Link
        /// </summary>
        [Required(ErrorMessage = "DownloadLink Of Course Is Require!")]
        public string DownloadLink { get; set; }
    }
}