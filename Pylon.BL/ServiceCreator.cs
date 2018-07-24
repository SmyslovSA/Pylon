using Pylon.BL.Interface;
using Pylon.DAL.UoW;

namespace Pylon.BL
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new UnitOfWork());
        }
    }
}
