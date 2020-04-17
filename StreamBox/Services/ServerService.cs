using StreamBox.Models;
using StreamBox.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace StreamBox.Services
{
    public class ServerService : IGenericRepository<Server>
    {
        private readonly AppDbContext dbContext;
        public ServerService(AppDbContext dbContext)
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

        public IEnumerable<Server> All()
        {
            return dbContext.Servers;
        }

        public IEnumerable<Server> AllActive()
        {
            return dbContext.Servers.Where(s => s.State == true).ToList();
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
