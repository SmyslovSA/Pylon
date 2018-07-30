using System.Collections.Generic;

namespace Pylon.BL.Interface
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity GetProduct(int id);
        ICollection<TEntity> GetProducts(string id);
        int AddProduct(TEntity product);
        void UpdateProduct(TEntity product);
        void DeleteProduct(int id);
        ICollection<TEntity> GetAllProducts();
    }
}
