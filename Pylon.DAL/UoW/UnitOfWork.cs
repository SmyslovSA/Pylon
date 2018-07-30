using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pylon.DAL.Context;
using Pylon.DAL.Interface;
using Pylon.DAL.UserManager;
using System;

namespace Pylon.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private PylonContext _pylonContext;

        public UnitOfWork()
        {
            _pylonContext = new PylonContext();
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
            ProfileManager = new ProfileRepository(_pylonContext);
            ProductManager = new ProductRepository(_pylonContext);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public PylonUserManager UserManager { get; set; }

        public PylonRoleManager RoleManager { get; set; }

        public IProfileRepository ProfileManager { get; set; }

        public IProductRepository ProductManager { get; set; }

        public void SaveChanges()
        {
             _pylonContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }

            _pylonContext?.Dispose();
            _pylonContext = null;
            _disposed = true;
        }
    }
}
