using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFSamples
{
    public class Visitor
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        public ICollection<Book> TakenBooks { get; set; }
    }
}