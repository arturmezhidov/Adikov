using System.Security.Claims;
using System.Threading.Tasks;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Files;
using Adikov.Infrastructura.Security;
using Adikov.Platform.Extensions;
using Microsoft.AspNet.Identity;

namespace Adikov.Domain
{
    public class ApplicationUser : BaseApplicationUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Occupation { get; set; }

        public string Interests { get; set; }

        public string About { get; set; }

        public string Website { get; set; }

        public bool IsLock { get; set; }

        public int? AvatarId { get; set; }

        public File Avatar { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(ClaimsTypes.USER_ID, Id);
            userIdentity.AddClaim(ClaimsTypes.USER_EMAIL, Email);
            userIdentity.AddClaim(ClaimsTypes.USER_FIRST_NAME, FirstName);
            userIdentity.AddClaim(ClaimsTypes.USER_LAST_NAME, LastName);
            userIdentity.AddClaim(ClaimsTypes.USER_PHONE_NUMBER, PhoneNumber);
            userIdentity.AddClaim(ClaimsTypes.USER_OCCUPATION, Occupation);
            userIdentity.AddClaim(ClaimsTypes.USER_INTERESTS, Interests);
            userIdentity.AddClaim(ClaimsTypes.USER_ABOUT, About);
            userIdentity.AddClaim(ClaimsTypes.USER_WEBSITE, Website);

            if (AvatarId.HasValue)
            {
                FindUserAvatarQueryResult result = Query.For<FindUserAvatarQueryResult>().ById(Id);

                if (result != null)
                {
                    Avatar = result.Avatar;
                    userIdentity.AddClaim(ClaimsTypes.USER_AVATAR, result.ImageUrl);
                }
            }

            return userIdentity;
        }
    }
}