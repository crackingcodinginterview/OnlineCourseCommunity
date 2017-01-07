using System.ComponentModel;

namespace OnlineCourseCommunity.Library.Core
{
    public enum IssueStatus
    {
        [Description("Opened")]
        Opened = 0,
        [Description("Maintained")]
        Maintained = 1,
        [Description("Need to Approve")]
        NeedToApprove = 2,
        [Description("Approved")]
        Approved = 3,
        [Description("Rejected")]
        Rejected  = 4,
        [Description("Closed")]
        Closed = 5
    }
    public enum ShootingStatus
    {       
        [Description("Created")]
        Created = 0,
        [Description("NeedToApprove")]
        NeedToApprove =1,
        [Description("Approved")]
        Approved = 2,
        [Description("Rejected")]
        Rejected = 3,
        
    }

    public enum TroubleStatus
    {
        [Description("Created")]
        Created = 0,
        [Description("NeedToApprove")]
        NeedToApprove = 1,
        [Description("Approved")]
        Approved = 2,
        [Description("Rejected")]
        Rejected = 3,

    }
    
    public enum OwnerType
    {
        [Description("User")]
        User = 1,
        [Description("Trouble")]
        Trouble = 2,
        [Description("Step")]
        Step = 3,
        [Description("Shooting")]
        Shooting = 4
    }

    public enum FileType
    {
        [Description("Picture")]
        Picture = 0,
        [Description("Video")]
        Video = 1,
        [Description("Document")]
        Document = 2,
        [Description("Other")]
        Other = 3
    }
}
