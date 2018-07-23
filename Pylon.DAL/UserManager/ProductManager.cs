using Pylon.DAL.Context;
using Pylon.DAL.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Pylon.DAL.UserManager
{
    public class ProductManager : IProductManager
    {
        private PylonContext _pylonContext;

        public ProductManager(PylonContext context)
        {
            _pylonContext = context;
        }

        public void Delete<TKey>(TKey id)
        {
            var item = _pylonContext.Set<Product>().Find(id);
            _pylonContext.Set<Product>().Remove(item);
            _pylonContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            _pylonContext.Set<Product>().Remove(product);
            _pylonContext.SaveChanges();
        }

        public Product GetById<TKey>(TKey id)
        {
            return _pylonContext.Set<Product>().Find(id);
        }

        public void Insert(Product product)
        {
            _pylonContext.Products.Add(product);
            _pylonContext.SaveChanges();
        }

        public void Update(Product product)
        {
            _pylonContext.Set<Product>().Attach(product);
            _pylonContext.Entry(product).State = EntityState.Modified;
            _pylonContext.SaveChanges();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _pylonContext.Set<Product>().ToListAsync();
        }
    }
}
