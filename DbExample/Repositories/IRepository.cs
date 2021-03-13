using System.Collections.Generic;
using DbExample.Entities;

namespace DbExample.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> Get();

        T Get(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}