using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pylon.DAL.Interface
{
    public interface IProductManager
    {
        Product GetById<TKey>(TKey id);
        void Insert(Product product);
        void Update(Product product);
        void Delete<TKey>(TKey id);
        void Delete(Product product);
        IEnumerable<Product> Get();
    }
}
