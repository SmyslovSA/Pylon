using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Pylon.DAL
{
    public class User : IdentityUser
    {
        public virtual Profile Profile { get; set; }

        public List<Product> Products { get; set; }
    }
}
