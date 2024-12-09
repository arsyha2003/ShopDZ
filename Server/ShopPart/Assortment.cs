using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice3Server
{
    public class Assortment
    {
        public List<Product> products;
        public Assortment()
        {
            products = new List<Product>();
        }
        public void AddProduct(Product product) => products.Add(product);
    }
}
