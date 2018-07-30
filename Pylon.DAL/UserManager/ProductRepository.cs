using Pylon.DAL.Context;
using Pylon.DAL.Interface;

namespace Pylon.DAL.UserManager
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(PylonContext context) : base(context) { }
    } 
}
