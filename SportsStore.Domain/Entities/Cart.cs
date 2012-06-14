using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem (Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product == product).FirstOrDefault();
            if (line == null)
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            else
                line.Quantity++;
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product == product);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Quantity * e.Product.Price);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines 
        {
            get { return lineCollection; } 
        }

    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
