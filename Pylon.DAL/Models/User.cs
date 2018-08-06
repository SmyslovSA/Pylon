using Microsoft.AspNet.Identity.EntityFramework;

namespace Pylon.DAL.Models
{
    public class User : IdentityUser
    {
        public virtual Profile Profile { get; set; }
    }
}
