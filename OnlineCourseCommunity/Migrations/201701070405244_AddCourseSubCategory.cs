namespace OnlineCourseCommunity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseSubCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "SubCategory", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "SubCategory");
        }
    }
}
