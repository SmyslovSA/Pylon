using Microsoft.AspNet.Identity;

namespace Pylon.DAL.UserManager
{
    public class PylonUserManager : UserManager<User>
    {
        public PylonUserManager(IUserStore<User> store) : base(store)
        {
        }
    }
}
