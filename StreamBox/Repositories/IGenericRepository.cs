using System.Collections.Generic;

namespace StreamBox.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        TEntity GetById(int ID);
        IEnumerable<TEntity> All();
        TEntity Add(TEntity entity);
        TEntity Delete(int id);
        TEntity Update(TEntity entity);
    }
}
