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
        private bool? isAuth;
        private bool? isAdmin;

        public string UserId => userId ?? (userId = GetClaimValue(ClaimsTypes.USER_ID));

        public string Email => email ?? (email = GetClaimValue(ClaimsTypes.USER_EMAIL));

        public bool IsAuth { get; set; }

        public string Avatar { get; set; }

        public bool IsAdmin { get; set; }

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