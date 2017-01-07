namespace OnlineCourseCommunity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProfileModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserCourse", newName: "ProfileCourse");
            RenameColumn(table: "dbo.ProfileCourse", name: "UserId", newName: "ProfileId");
            RenameIndex(table: "dbo.ProfileCourse", name: "IX_UserId", newName: "IX_ProfileId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProfileCourse", name: "IX_ProfileId", newName: "IX_UserId");
            RenameColumn(table: "dbo.ProfileCourse", name: "ProfileId", newName: "UserId");
            RenameTable(name: "dbo.ProfileCourse", newName: "UserCourse");
        }
    }
}
