using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.App_Start
{
    public class IdentityConfig
    {
        public class ApplicationUserManager : UserManager<ApplicationUser>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
            {

            }
            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
            {
                ApplicationDbContex dbContext = context.Get<ApplicationDbContex>();
                IUserStore<ApplicationUser> store = new UserStore<ApplicationUser>(dbContext);
                ApplicationUserManager manager = new ApplicationUserManager(store);
                manager.UserValidator = new UserValidator<ApplicationUser>(manager)
                {
                    AllowOnlyAlphanumericUserNames = true,
                    RequireUniqueEmail = true
                };
                manager.PasswordValidator = new PasswordValidator() { RequiredLength = 6 };
                return manager;
            }
        }
        public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
        {
            public ApplicationSignInManager(UserManager<ApplicationUser, string> userManger, IAuthenticationManager authenticationManger)
                : base(userManger, authenticationManger)
            {

            }
            public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
            {
                return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
            }
        }
    }
}