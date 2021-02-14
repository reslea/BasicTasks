namespace GasStation
{
    public class GasInfo
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public GasInfo(string title, decimal price)
        {
            Title = title;
            Price = price;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}