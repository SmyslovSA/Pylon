using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using Ninject.Web.Common;
using Pylon.DAL.Interface;
using Pylon.DAL.Models;
using Pylon.DAL.UoW;
using Pylon.DAL.UserManager;

namespace Pylon.BL.Ninject
{
    public class BlModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<PylonUserManager>().ToSelf().InRequestScope();
            Bind<IUserStore<User>>().To<UserStore<User>>();
        }
    }
}
