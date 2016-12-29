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
        private static IKernel _kernel;
        public static IKernel CreateKernel()
        {
            _kernel = new StandardKernel();

            _kernel.Bind<DbContext>().To<Context>();
            _kernel.Bind<IUserService>().To<UserService>();

            return _kernel;
        }
    }
}