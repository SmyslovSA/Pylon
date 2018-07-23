using Pylon.DAL.UserManager;
using System;
using System.Threading.Tasks;

namespace Pylon.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        PylonUserManager UserManager { get; set; }

        PylonRoleManager RoleManager { get; set; }

        IProfileManager ProfileManager { get; set; }

        Task SaveChanges();
    }
}
