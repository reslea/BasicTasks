using System;
using System.Collections.Generic;
using System.Linq;
using EFSamples.Entities;

namespace EFSamples.Logic
{
    public class VisitorService : IVisitorService
    {
        private readonly LibraryContext _context;

        public VisitorService()
        {
            _context = new LibraryContext();
        }

        public IEnumerable<Visitor> Get()
        {
            return _context.Visitors.ToList();
        }

        public IEnumerable<Visitor> GetVisitorsWithBooks()
        {
            return _context.Visitors.Where(_ => _.TakenBooks.Any()).ToList();
        }
    }
}
