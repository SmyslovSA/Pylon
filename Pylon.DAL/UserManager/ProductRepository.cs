using Pylon.DAL.Context;
using Pylon.DAL.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Pylon.DAL.UserManager
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(PylonContext context) : base(context) { }
    } 
}
