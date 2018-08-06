using Pylon.DAL.Context;
using Pylon.DAL.Interface;
using Pylon.DAL.Models;

namespace Pylon.DAL.UserManager
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(PylonContext context) : base(context) { }
    } 
}
