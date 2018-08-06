using Microsoft.AspNet.Identity;
using Pylon.DAL.Models;

namespace Pylon.DAL.UserManager
{
    public class PylonUserManager : UserManager<User>
    {
        public PylonUserManager(IUserStore<User> store) : base(store)
        {
        }
    }
}
