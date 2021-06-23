using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }
    }
}
