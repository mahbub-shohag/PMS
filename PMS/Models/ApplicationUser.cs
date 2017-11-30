using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace PMS.Models
{
    public class CustomAccount : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<CustomAccount> manager)
        {
            ClaimsIdentity claimsIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return claimsIdentity;
        }
    }
    public class ApplicationDbContex : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContex()
        {

        }
        public static ApplicationDbContex Create()
        {
            return new ApplicationDbContex();
        }
    }
}