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
            //UserService
            //var roleStore = new RoleStore<IdentityRole>(context);
            //var userStore = new UserStore<IdentityUser>(context);
            //PasswordHasher passwordHasher = new PasswordHasher();
            //string[] roles = new string[] { "ADMIN", "USER" };
            //foreach (string role in roles)
            //{
            //    if (!context.Roles.Any(r => r.Name == role))
            //    {
            //        await roleStore.CreateAsync(new IdentityRole(role));
            //    }
            //}
            //var user = new IdentityUser
            //{
            //    UserName = "netsuft",
            //    PasswordHash = passwordHasher.HashPassword("123456")
            //};
            //await userStore.CreateAsync(user);
            //await userStore.AddToRoleAsync(user, "ADMIN");
            //IUserService userService = new UserService(context);
            //IProfileService profileService = new ProfileService(context);
            //userService.AddRoleList(new string[] { "USER", "ADMIN" });
            //IdentityUser user = await userService.RegisterUserAsync("netsuft", "123456", "ADMIN");
            //var profile = new Profile()
            //{
            //    UserId = user.Id,
            //    FirstName = "Net",
            //    LastName = "Suft",
            //    AvatarUrl = "",
            //    Money = 1000000
            //};
            //profile = await profileService.CreateAsync(profile);
            //var roleStore = new RoleStore<IdentityRole>(context);
            //var roleManager = new RoleManager<IdentityRole>(roleStore);
            //var userStore = new UserStore<IdentityUser>(context);
            //var userManager = new UserManager<IdentityUser>(userStore);
            //var user = new ApplicationUser { UserName = "sallen" };
            //userManager.Create(user, "password");
            //roleManager.Create(new IdentityRole { Name = "ADMIN" });
            //userManager.AddToRole(user.Id, "admin");
        }
    }
}
