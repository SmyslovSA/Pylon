using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Pylon.DAL.Context
{
    public class PylonContext : IdentityDbContext<User>
    {
        public PylonContext() : base("DefaultConnection") { }

        public DbSet<Profile> Profile { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
