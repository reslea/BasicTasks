using System;
using System.Collections.Generic;

namespace EFSamples.Entities
{
    //[Index(nameof(Name), IsUnique = true)]
    public class Visitor
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required, StringLength(255)]
        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public ICollection<Book> TakenBooks { get; set; }
    }
}