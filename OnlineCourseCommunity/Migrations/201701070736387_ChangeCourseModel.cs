namespace OnlineCourseCommunity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCourseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "AboutThisCourse", c => c.String());
            AddColumn("dbo.Courses", "OwnerId", c => c.String());
            AddColumn("dbo.Courses", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Courses", "User_Id");
            AddForeignKey("dbo.Courses", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "User_Id" });
            DropColumn("dbo.Courses", "User_Id");
            DropColumn("dbo.Courses", "OwnerId");
            DropColumn("dbo.Courses", "AboutThisCourse");
        }
    }
}
