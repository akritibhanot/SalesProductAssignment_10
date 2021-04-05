using Microsoft.AspNetCore.Mvc;
using SalesProductAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProductAssignment.Controllers
{
    public class OrderOperationsController : Controller
    {
        OrderOperations orderOperationsBusinessLogic;

        public  OrderOperationsController(AppDbContext appDbContext)
        {
            orderOperationsBusinessLogic = new OrderOperations(appDbContext);
        }
        public IActionResult Index()
        {
            return View();
        }

        public string CreateOrders()
        {
            orderOperationsBusinessLogic.CreateOrders();
            return "successfully loaded data";
        }

        public ViewResult ListOrdersByProduct()
        {
            List<Product> products = orderOperationsBusinessLogic.
                GetAllproducts();
            return View(products);
        }


        public ViewResult ListOrdersByProductSelected(int id)
        {
            List<Order> orders = orderOperationsBusinessLogic.
                GetAllOrderFromProduct(id);
            return View(orders);
        }
        public ViewResult ListMaximumSoldProduct()
        {
            List<Product> products = orderOperationsBusinessLogic.
                GetAllproducts();
            return View(products);

        }

        public ViewResult ListMaximumSoldProductSelected(int id)
        {
            OrderProductDetails order = orderOperationsBusinessLogic.
                GetAllOrderFromProductSoldMaximum(id);
            return View(order);

        }
    }
}
