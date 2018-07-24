using Ninject.Modules;
using Pylon.BL.Interface;
using Pylon.BL.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pylon.Website.Ninject
{
    public class UiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
        }
    }
}