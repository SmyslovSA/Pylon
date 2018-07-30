using Ninject.Modules;
using Ninject.Web.Common;
using Pylon.DAL.Interface;
using Pylon.DAL.UoW;
using Pylon.DAL.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylon.BL.Ninject
{
    public class BlModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<PylonUserManager>().ToSelf().InRequestScope();
        }
    }
}
