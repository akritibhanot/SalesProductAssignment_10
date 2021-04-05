using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesProductAssignment.Models;


namespace SalesProductAssignment.Models
{

    
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSold> ProductsSold { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SalesProductAssignment.Models.OrderProductDetails> OrderProductDetails { get; set; }
    }

}
