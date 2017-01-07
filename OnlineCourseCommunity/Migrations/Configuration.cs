namespace OnlineCourseCommunity.Migrations
{
    using Library.Core.Domain.Authentication;
    using Library.Service.Implement.Authentication;
    using Library.Service.Interface.Authentication;
    using Microsoft.AspNet.Identity;
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

        protected async override void Seed(OnlineCourseCommunity.Library.Data.Context context)
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
            //var roleStore = new RoleStore<IdentityRole>(context);
            //var roleManager = new RoleManager<IdentityRole>(roleStore);
            //var userStore = new UserStore<IdentityUser>(context);
            //var userManager = new UserManager<IdentityUser>(userStore);
            //var user = new IdentityUser { UserName = "netsuft" };

            //userManager.Create(user, "123456");
            //roleManager.Create(new IdentityRole { Name = "ADMIN" });
            //userManager.AddToRole(user.Id, "ADMIN");
            //context.Set<Profile>().AddOrUpdate(
            //    x => x.Id,
            //    new Profile
            //    {
            //        FirstName = "NET",
            //        LastName = "SUFT",
            //        Money = 100000,
            //        UserId = user.Id,
            //        AvatarUrl = "http://lh4.ggpht.com/--ORv_VsDhhY/Vlpjquk2siI/AAAAAAABMnE/xwIGyrAABMo/s400/doraemon-new-series-doremon-moi-nhat3.jpg"
            //    });
        }
    }
}
