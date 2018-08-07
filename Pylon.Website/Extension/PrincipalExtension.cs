using System;
using System.Collections.Generic;
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

		public static List<string> GetUserRoles(this IPrincipal user)
		{
			var roles = new List<string>();
			var claimsIdentity = user.Identity as ClaimsIdentity;
			var claim = claimsIdentity?.FindAll(ClaimTypes.Role);

			if (claim == null)
			{
				throw new InvalidOperationException("sub claim is missing");
			}

			foreach (var role in claim)
			{
				roles.Add(role.Value);
			}
			return roles;
		}
	}


}