namespace OnlineCourseCommunity.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineCourseCommunity.Library.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineCourseCommunity.Library.Data.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //PasswordHasher
            //context.Set<IdentityUser>().AddOrUpdate(
            //    x => x.Id,
            //    new IdentityUser
            //    {
            //        UserName = "netsuft",
            //        PasswordHash = "",
            //        Roles = new 
            //    });
        }
    }
}
