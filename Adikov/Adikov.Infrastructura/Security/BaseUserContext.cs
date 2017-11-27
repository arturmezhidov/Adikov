using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Adikov.Infrastructura.Security
{
    public abstract class BaseUserContext
    {
        public abstract ClaimsPrincipal User { get; }

        protected virtual Claim GetClaim(string type)
        {
            Claim claim = User.FindFirst(ClaimsTypes.USER_ID);
            return claim;
        }

        protected virtual IEnumerable<Claim> GetClaims(string type)
        {
            IEnumerable<Claim> claims = User.FindAll(ClaimsTypes.USER_ID);
            return claims;
        }

        protected virtual string GetClaimValue(string type, string defaultValue = null)
        {
            Claim claim = GetClaim(type);
            return claim?.Value ?? defaultValue;
        }

        protected virtual int GetClaimValueInt(string type, int defaultValue = 0)
        {
            string stringValue = GetClaimValue(type);

            if (int.TryParse(stringValue, out var value))
            {
                return value;
            }

            return defaultValue;
        }

        protected virtual bool GetClaimValueBool(string type, bool defaultValue = false)
        {
            string stringValue = GetClaimValue(type);

            if (bool.TryParse(stringValue, out var value))
            {
                return value;
            }

            return defaultValue;
        }

        protected virtual IEnumerable<string> GetClaimsValues(string type)
        {
            IEnumerable<string> claimsValues = User
                .FindAll(ClaimsTypes.USER_ID)
                .Select(claim => claim.Value);
            return claimsValues;
        }
    }
}