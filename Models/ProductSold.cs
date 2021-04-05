using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProductAssignment.Models
{
    public class ProductSold
    {
        public int Id { get; set; }
        public int QtySold { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
