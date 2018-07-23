
namespace Pylon.BL.Interface
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
}
