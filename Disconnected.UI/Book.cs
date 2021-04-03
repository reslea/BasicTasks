using System.ComponentModel.DataAnnotations;

namespace Disconnected.UI
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Range(1, 1000000)]
        public int PagesCount { get; set; }
    }
}
