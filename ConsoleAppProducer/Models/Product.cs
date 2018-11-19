using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProducer.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Decimal Price { get; set; }
    }
}
