using Microsoft.AspNet.Identity;
using Pylon.DAL.Models;

namespace Pylon.DAL.UserManager
{
    public class PylonRoleManager : RoleManager<Role>
    {
        public PylonRoleManager(IRoleStore<Role, string> store) : base(store)
        {
        }
    }
}
