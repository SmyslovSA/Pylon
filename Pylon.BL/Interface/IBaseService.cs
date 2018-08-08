using System.Collections.Generic;

namespace Pylon.BL.Interface
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        ICollection<TEntity> GetByProfile(string id);
		int Add(TEntity product);
        void Update(TEntity product);
        void Delete(int id);
        ICollection<TEntity> GetAll();
    }
}
