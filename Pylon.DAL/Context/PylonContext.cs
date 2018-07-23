using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Pylon.DAL.Context
{
    public class PylonContext : IdentityDbContext<User>
    {
        public PylonContext(string connectionString) : base(connectionString) { }

        public DbSet<Profile> Profile { get; set; }
    }
}
