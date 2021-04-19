using System;
using System.Collections.Generic;
using System.Text;
using EFSamples.Entities;

namespace EFSamples.Logic
{
    public interface IVisitorService
    {
        IEnumerable<Visitor> Get();

        IEnumerable<Visitor> GetVisitorsWithBooks();

        IEnumerable<Visitor> GetVisitorsByName(string searchTerm);
    }
}
