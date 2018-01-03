using System.Security.Claims;
using System.Threading.Tasks;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Adikov.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public int AvatarId { get; set; }

        public File Avatar { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim(ClaimsTypes.USER_ID, Id));
            userIdentity.AddClaim(new Claim(ClaimsTypes.USER_EMAIL, Email));
            if (Avatar != null) userIdentity.AddClaim(new Claim(ClaimsTypes.USER_AVATAR, Avatar.PhysicalName));

            return userIdentity;
        }
    }
}