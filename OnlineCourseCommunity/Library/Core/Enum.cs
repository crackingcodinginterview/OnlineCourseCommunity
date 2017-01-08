using System.ComponentModel;

namespace OnlineCourseCommunity.Library.Core
{
    public enum Category
    {
        [Description("Development")]
        Development = 0,
        [Description("IT & Software")]
        ItAndSoftWare = 1,
        [Description("Design")]
        Design = 2,
    }
    public enum SubCategory
    {
        [Description("Web Development")]
        WebDevelopment = 0,
    }
}
