using Microsoft.AspNet.Identity.EntityFramework;

namespace Pylon.DAL
{
    public class User : IdentityUser
    {
        public virtual Profile Profile { get; set; }
    }
}
