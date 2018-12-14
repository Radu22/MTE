using System;
using System.Linq;
using _1_Entity.Model;

namespace _5_Repositories.Contracts
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        IQueryable<T> Query();

        T Get(Guid id);

        void Add(T entity);

        void Save();

        void Delete(T entity);
    }
}
