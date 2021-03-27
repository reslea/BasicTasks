using System;
using System.Collections.Generic;
using DbExample.Entities;

namespace DbExample.Repositories
{
    public interface IBookRepository : IRepository<Book>, IDisposable
    {
        IEnumerable<Book> Get(string title);
    }
}