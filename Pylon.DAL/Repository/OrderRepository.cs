using Pylon.DAL.Interface;
using Pylon.DAL.Context;
using Pylon.DAL.Models;

namespace Pylon.DAL.UserManager
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(PylonContext context) : base(context) { }
    }
}
