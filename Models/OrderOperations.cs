using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProductAssignment.Models
{
    public class OrderOperations
    {
        AppDbContext dbContext;
        public OrderOperations(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
        }

        public List<Order> GetAllOrderFromProduct(int  productId)
        {
            

            //select order.*,product.*,soldproduct.* from productsold join order on productsold.orderid =
            //order.id
            var result = from ProductsSold in dbContext.ProductsSold
                         join Orders in dbContext.Orders                          
                         on ProductsSold.OrderId equals Orders.Id                        
                         join Products in dbContext.Products
                         on ProductsSold.ProductId equals Products.Id
                         where Products.Id == productId
                         select new
                         {
                             OrderID = Orders.Id,
                             SoldDate = Orders.DateOfSale,
                             totalPrice = Orders.TotalCost

                         };

            return result.Select(item => new Order()
            {
                DateOfSale = item.SoldDate,
                TotalCost = item.totalPrice,
                Id = item.OrderID
            }).ToList();


        }

        public OrderProductDetails GetAllOrderFromProductSoldMaximum(int productId)
        {
            

            //select order.*,product.*,soldproduct.* from productsold join order on productsold.orderid =
            //order.id
            var result = from ProductsSold in dbContext.ProductsSold
                         join Orders in dbContext.Orders
                         on ProductsSold.OrderId equals Orders.Id
                         join Products in dbContext.Products
                         on ProductsSold.ProductId equals Products.Id
                         where Products.Id == productId
                         orderby ProductsSold.QtySold descending
                         select new
                         {
                             OrderID = Orders.Id,
                             SoldDate = Orders.DateOfSale,
                             totalPrice = Orders.TotalCost,
                             ProductName = ProductsSold.Product.ProductName,
                             TotalQunatity = ProductsSold.QtySold

                         };

            return result.Select(item => new OrderProductDetails()
            {
                SoldDate = item.SoldDate,
                TotalPrice = item.totalPrice,
                OrderID = item.OrderID,
                TotalQuantity = item.TotalQunatity,
                ProductName = item.ProductName
            }).ToList().FirstOrDefault();


        }
        public List<Product> GetAllproducts()
        {
            return dbContext.Products.ToList();
        }
        public void CreateOrders()
        {
            //DateTime dt = new DateTime(20221, 3, 20);
            //List<ProductSold> solditems = new List<ProductSold>();
            //solditems.Add(new ProductSold()
            //{

            //})
            Order order = new Order()
            {
                DateOfSale = DateTime.Now,
                TotalCost = 9400
            };
            dbContext.Orders.Add(order);
            ProductSold soldItem = new ProductSold()
            {
                Order = order,
                Product = dbContext.Products.Where(
                    product => product.ProductName.
                    ToLower() == "apple laptop").First(),
                QtySold = 4
            };
            dbContext.ProductsSold.Add(soldItem);

            

            soldItem = new ProductSold()
            {
                Order = order,
                Product = dbContext.Products.Where(
                    product => product.ProductName.
                    ToLower() == "oneplus mobile").First(),
                QtySold = 2
            };

            dbContext.ProductsSold.Add(soldItem);

            soldItem = new ProductSold()
            {
                Order = order,
                Product = dbContext.Products.Where(
                    product => product.ProductName.
                    ToLower() == "samsung mobile").First(),
                QtySold = 9
            };
            dbContext.ProductsSold.Add(soldItem);

            //first order
            //samsung mobile 9
            //apple laptop 4
            //oneplus 2

            //second order
           // 1 samsun
           //7 oneplus
           //apple laptop 2
            order = new Order()
            {
                DateOfSale = DateTime.Now,
                TotalCost = 15000
            };
            dbContext.Orders.Add(order);
            soldItem = new ProductSold()
            {
                Order = order,
                Product = dbContext.Products.Where(
                    product => product.ProductName.
                    ToLower() == "apple laptop").First(),
                QtySold = 2
            };
            dbContext.ProductsSold.Add(soldItem);



            soldItem = new ProductSold()
            {
                Order = order,
                Product = dbContext.Products.Where(
                    product => product.ProductName.
                    ToLower() == "oneplus mobile").First(),
                QtySold = 7
            };

            dbContext.ProductsSold.Add(soldItem);

            soldItem = new ProductSold()
            {
                Order = order,
                Product = dbContext.Products.Where(
                    product => product.ProductName.
                    ToLower() == "samsung mobile").First(),
                QtySold = 1
            };
            dbContext.ProductsSold.Add(soldItem);

            dbContext.SaveChanges();
        }
    }
}
