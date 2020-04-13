using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamBox.Models
{
    public class SqlServerRepository : IGenericRepository<Server>
    {
        private readonly AppDbContext dbContext;
        public SqlServerRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Server Add(Server entity)
        {
            dbContext.Servers.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public Server Delete(int id)
        {
            var entity = dbContext.Servers.Find(id);
            if (entity != null)
            {
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
            return entity;
        }

        public IEnumerable<Server> GetAllEntities()
        {
            return dbContext.Servers;
        }

        public Server GetById(int ID)
        {
            return dbContext.Servers.Find(ID);
        }

        public Server Update(Server entity)
        {
            var UpdateEntity = dbContext.Servers.Attach(entity);
            UpdateEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return entity;
        }
    }
}
