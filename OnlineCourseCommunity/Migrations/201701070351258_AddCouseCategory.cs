namespace OnlineCourseCommunity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCouseCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Category");
        }
    }
}
