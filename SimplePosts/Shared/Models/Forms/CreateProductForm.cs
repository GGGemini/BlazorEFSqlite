using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePosts.Shared.Models.Forms
{
    public class ProductForm
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
