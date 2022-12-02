using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarniceriaWebApp.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string ProductDescription { get; set; }
        public string ProductId { get; set; }
        public string Brand { get; set; }
        public string ProductNationality { get; set; }
    }
}
