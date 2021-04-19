namespace EFSamples.Entities
{
    //[Table("Prices")]
    public class BookPrice
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        public Book Book { get; set; }

        //[ForeignKey("Book")]
        public int BookId { get; set; }

        public decimal Price { get; set; }
    }
}