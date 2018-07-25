using System;
using System.Security.Claims;
using System.Security.Principal;

namespace Pylon.Website.Extension
{
    public static class PrincipalExtension
    {
        public static string GetUserId(this IPrincipal user)
        {
            var claimsIdentity = user.Identity as ClaimsIdentity;
            var claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                throw new InvalidOperationException("sub claim is missing");
            }
            return claim.Value;
        }
    }
}