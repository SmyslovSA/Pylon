using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pylon.BL.Interface
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
    }
}
