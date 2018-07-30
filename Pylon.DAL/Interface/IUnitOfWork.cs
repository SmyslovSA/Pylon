using Pylon.DAL.UserManager;
using System;
using System.Threading.Tasks;

namespace Pylon.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        PylonUserManager UserManager { get; set; }

        PylonRoleManager RoleManager { get; set; }

        IProfileRepository ProfileManager { get; set; }

        IProductRepository ProductManager { get; set; }

        void SaveChanges();
    }
}
