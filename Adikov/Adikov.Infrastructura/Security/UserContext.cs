using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace Adikov.Infrastructura.Security
{
    public class UserContext : BaseUserContext, IUserContext
    {
        private string userId;
        private string email;
        private string avatar;
        private bool? isAdmin;

        public string UserId => userId ?? (userId = GetClaimValue(ClaimsTypes.USER_ID));

        public string Email => email ?? (email = GetClaimValue(ClaimsTypes.USER_EMAIL));

        public string Avatar => avatar ?? (avatar = GetClaimValue(ClaimsTypes.USER_AVATAR));

        public bool IsAuth => User.Identity.IsAuthenticated;

        public bool IsAdmin
        {
            get
            {
                if (!IsAuth)
                {
                    return false;
                }

                if (!isAdmin.HasValue)
                {
                    isAdmin = User.IsInRole(UserRoles.ADMIN);
                }

                return isAdmin.Value;
            }
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
    }
}