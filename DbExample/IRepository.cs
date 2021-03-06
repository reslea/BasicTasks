using System.Collections.Generic;

namespace DbExample
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        T Get(int id);

        void Add(T book);

        void Update(T book);

        void Delete(T book);
    }
}