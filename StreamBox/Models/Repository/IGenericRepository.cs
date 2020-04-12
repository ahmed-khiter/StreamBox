using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamBox.Models
{
    public interface IGenericRepository<TEntity>
    {
        TEntity GetById(int ID);
        IEnumerable<TEntity> GetAllEntities();
        TEntity Add(TEntity entity);
        TEntity Delete(int id);
        TEntity Update(TEntity entity);
    }
}
