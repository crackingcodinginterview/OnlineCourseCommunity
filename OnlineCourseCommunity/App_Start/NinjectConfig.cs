using Ninject;
using OnlineCourseCommunity.Library.Data;
using OnlineCourseCommunity.Library.Service.Implement.Authentication;
using OnlineCourseCommunity.Library.Service.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineCourseCommunity.App_Start
{
    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            //Create the bindings
            kernel.Bind<DbContext>().To<Context>();
            kernel.Bind<IUserService>().To<UserService>();

            return kernel;
        }
    }
}