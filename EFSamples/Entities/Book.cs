namespace EFSamples.Entities
{
    public class Book
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required, StringLength(255)]
        public string Title { get; set; }

        //[Required, StringLength(255)]
        public string Author { get; set; }

        public int PagesCount { get; set; }
        
        public Visitor Visitor { get; set; }

        //[ForeignKey("Visitor")]
        public int? VisitorId { get; set; }

        //[ForeignKey("BookPrice")]
        //public int? BookPriceId { get; set; }

        //public BookPrice BookPrice { get; set; }
    }
}
