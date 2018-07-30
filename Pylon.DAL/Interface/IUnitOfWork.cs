using Pylon.DAL.UserManager;
using System;

namespace Pylon.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        PylonUserManager UserManager { get; set; }

        PylonRoleManager RoleManager { get; set; }

        IProfileRepository ProfileManager { get; set; }

        IProductRepository ProductManager { get; set; }

        IOrderRepository OrderManager { get; set; }

        void SaveChanges();
    }
}
