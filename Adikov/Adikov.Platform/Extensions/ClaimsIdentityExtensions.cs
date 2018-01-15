using System;
using System.Security.Claims;

namespace Adikov.Platform.Extensions
{
    public static class ClaimsIdentityExtensions
    {
        public static void AddClaim(this ClaimsIdentity identity, string key, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                value = String.Empty;
            }

            identity.AddClaim(new Claim(key, value));
        }
    }
}