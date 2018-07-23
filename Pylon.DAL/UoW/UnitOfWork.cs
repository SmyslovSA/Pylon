using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pylon.DAL.Context;
using Pylon.DAL.Interface;
using Pylon.DAL.UserManager;
using System;
using System.Threading.Tasks;

namespace Pylon.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private PylonContext _pylonContext;
        //private PylonUserManager _pylonUserManager;
        //private PylonRoleManager _pylonRoleManager;
        //private IProfileManager _profileManager;

        public UnitOfWork(string connectionString)
        {
            _pylonContext = new PylonContext(connectionString);
            UserManager = new PylonUserManager(new UserStore<User>(_pylonContext));
            UserManager.UserValidator = new UserValidator<User>(UserManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            UserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            RoleManager = new PylonRoleManager(new RoleStore<Role>(_pylonContext));
            ProfileManager = new ProfileManager(_pylonContext);
            ProductManager = new ProductManager(_pylonContext);
        }

        public PylonUserManager UserManager { get; set; }

        public PylonRoleManager RoleManager { get; set; }

        public IProfileManager ProfileManager { get; set; }

        public IProductManager ProductManager { get; set; }

        public async Task SaveChanges()
        {
            await _pylonContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    ProfileManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
