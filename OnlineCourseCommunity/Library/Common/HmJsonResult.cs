using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Common
{
    public class HmJsonResult
    {
        /// <summary>
        /// Success flag
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// List error messages
        /// </summary>
        public List<string> ErrorMessages
        {
            get;
            set;
        }
        /// <summary>
        /// Data model response
        /// </summary>
        public object Data { get; set; }

        public HmJsonResult()
        {
            ErrorMessages = new List<string>();
            Data = null;
            Success = false;
        }
    }
}