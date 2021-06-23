using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data
{
    public class Basket
    {
        public int Id { get; set; }

        public IEnumerable<BasketItem> BasketItems { get; set; }

        public bool IsPayed { get; set; }
    }
}
