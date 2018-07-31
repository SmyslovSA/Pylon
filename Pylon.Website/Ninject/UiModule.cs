using Ninject.Modules;
using Pylon.BL.Interface;
using Pylon.BL.Sevices;

namespace Pylon.Website.Ninject
{
    public class UiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
            Bind<IProfileService>().To<ProfileService>();
            Bind<IOrderService>().To<OrderService>();
        }
    }
}