using System;
using System.Linq;
using _1_Entity.Model;
using _3_Persistency.Implementations;
using _5_Repositories.Contracts;

namespace _6_Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        public BaseRepository(MTEContext dbContext)
        {
            DbContext = dbContext;
        }

        public MTEContext DbContext { get; }

        public void Add(T entity)
        {
            this.DbContext.Add(entity);
        }

        public void Delete(T entity)
        {
            DbContext.Remove(entity);
        }

        public T Get(Guid id)
        {
            return this.DbContext.Find<T>(id);
        }

        public IQueryable<T> Query()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            this.DbContext.SaveChanges();
        }
    }
}
