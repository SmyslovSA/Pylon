using Microsoft.AspNet.Identity;

namespace Pylon.DAL.UserManager
{
    public class PylonRoleManager : RoleManager<Role>
    {
        public PylonRoleManager(IRoleStore<Role, string> store) : base(store)
        {
        }
    }
}
