using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.Library.Common
{
    public abstract class HmJsonResult
    {
        public bool Success { get; set; }

        public List<string> ErrorMessages
        {
            get;
            set;
        }

        public object Data { get; set; }

        protected HmJsonResult()
        {
            ErrorMessages = new List<string>();
            Data = null;
            Success = false;
        }
    }
}