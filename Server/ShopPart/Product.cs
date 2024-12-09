using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice3Server
{
    public class Product
    {
        public string name;
        public decimal price;
        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
        public override string ToString()
        {
            return $"{name} - {price}$";
        }
    }
}
