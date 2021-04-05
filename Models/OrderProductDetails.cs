using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProductAssignment.Models
{
    public class OrderProductDetails
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        
        public DateTime SoldDate { get; set; }
        public string ProductName { get; set; }
        public int TotalQuantity { get; set; }

        public float TotalPrice { get; set; }
    }
}
