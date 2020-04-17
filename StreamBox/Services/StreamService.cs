﻿using StreamBox.Models;
using StreamBox.Repositories;
using System.Collections.Generic;

namespace StreamBox.Services
{
    public class StreamService : IGenericRepository<Stream>
    {
        private readonly AppDbContext dbContext;
        public StreamService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Stream Add(Stream entity)
        {
            dbContext.Streams.Add(entity);
            dbContext.SaveChangesAsync();
            return entity;
        }

        public Stream Delete(int id)
        {
            var entity = dbContext.Streams.Find(id);
            if (entity != null)
            {
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
            return entity;
        }

        public IEnumerable<Stream> All()
        {
            return dbContext.Streams;
        }

        public Stream GetById(int ID)
        {
            return dbContext.Streams.Find(ID);
        }

        public Stream Update(Stream entity)
        {
            var UpdateEntity = dbContext.Streams.Attach(entity);
            UpdateEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return entity;
        }
    }
}
