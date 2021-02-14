namespace GasStation
{
    public class CafeItemInfo
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public decimal TotalPrice { get; set; }

        public CafeItemInfo(string title, decimal price)
        {
            Title = title;
            Price = price;
            Count = 0;
        }
    }
}