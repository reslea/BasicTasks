using System.ComponentModel.DataAnnotations;

namespace EFSamples
{
    public class BookPrice
    {
        public int Id { get; set; }

        [Required]
        public Book Book { get; set; }

        public decimal Price { get; set; }
    }
}