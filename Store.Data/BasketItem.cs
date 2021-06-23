using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data
{
    public class BasketItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Count { get; set; }

        public int BasketId { get; set; }

        public Basket Basket { get; set; }
    }
}
