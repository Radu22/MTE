using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _1_Entity.Model;
using _3_Persistency.Implementations;
using _5_Repositories.Contracts;

namespace _6_Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {

        protected DbSet<T> dbSet;
        public BaseRepository(MTEContext dbContext)
        {
            DbContext = dbContext;
            dbSet = DbContext.Set<T>();
        }

        public MTEContext DbContext { get; }

        public void Add(T entity)
        {
            DbContext.Add(entity);
        }

        public void Delete(T entity)
        {
            DbContext.Remove(entity);
        }

        public T Get(Guid id)
        {
            return DbContext.Find<T>(id);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
