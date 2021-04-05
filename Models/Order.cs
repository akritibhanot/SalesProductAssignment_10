using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProductAssignment.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOfSale { get; set; }
        public int TotalCost { get; set; }
        public List<ProductSold> ProductsSold { get; set; }
    }
}
