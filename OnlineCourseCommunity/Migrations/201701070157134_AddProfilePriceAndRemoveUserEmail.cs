namespace OnlineCourseCommunity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfilePriceAndRemoveUserEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Profiles", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Email", c => c.String());
            DropColumn("dbo.Courses", "Price");
        }
    }
}
