using System;
using System.Security.Claims;
using System.Threading;
using Adikov.Platform.Configuration;

namespace Adikov.Infrastructura.Security
{
    public class UserContext : BaseUserContext, IUserContext
    {
        private string userId;
        private string email;
        private string avatar;
        private bool? isAdmin;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string occupation;
        private string interests;
        private string about;
        private string website;

        public string UserId => userId ?? (userId = GetClaimValue(ClaimsTypes.USER_ID));

        public bool IsAuth => User.Identity.IsAuthenticated;

        public bool IsAdmin
        {
            get { return true; }
        }

        public string Email => email ?? (email = GetClaimValue(ClaimsTypes.USER_EMAIL));

        public string Avatar
        {
            get
            {
                if (String.IsNullOrEmpty(avatar))
                {
                    avatar = GetClaimValue(ClaimsTypes.USER_AVATAR);
                }

                if (String.IsNullOrEmpty(avatar))
                {
                    avatar = PlatformConfiguration.DefaultAvatarPath;
                }
                
                return avatar;
            }
        }

        public string FirstName => firstName ?? (firstName = GetClaimValue(ClaimsTypes.USER_FIRST_NAME));

        public string LastName => lastName ?? (lastName = GetClaimValue(ClaimsTypes.USER_LAST_NAME));

        public string PhoneNumber => phoneNumber ?? (phoneNumber = GetClaimValue(ClaimsTypes.USER_PHONE_NUMBER));

        public string Occupation => occupation ?? (occupation = GetClaimValue(ClaimsTypes.USER_OCCUPATION));

        public string Interests => interests ?? (interests = GetClaimValue(ClaimsTypes.USER_INTERESTS));

        public string About => about ?? (about = GetClaimValue(ClaimsTypes.USER_ABOUT));

        public string Website => website ?? (website = GetClaimValue(ClaimsTypes.USER_WEBSITE));

        public void Reset()
        {
            email = null;
            avatar = null;
            firstName = null;
            lastName = null;
            phoneNumber = null;
            occupation = null;
            interests = null;
            about = null;
            website = null;
        }

        public override ClaimsPrincipal User
        {
            get
            {
                if (Thread.CurrentPrincipal is ClaimsPrincipal user)
                {
                    return user;
                }

                throw new Exception("Current principal does not support claims.");
            }
        }

        public override ClaimsIdentity Identity
        {
            get
            {
                if (User.Identity is ClaimsIdentity identity)
                {
                    return identity;
                }

                throw new Exception("Current principal does not support claims.");
            }
        }
    }
}