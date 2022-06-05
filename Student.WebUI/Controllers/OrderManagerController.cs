using Student.Core.Contracts;
using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class OrderManagerController : Controller
    {
        IOrderService orderService;

        public OrderManagerController(IOrderService OrderService)
        {
            this.orderService = OrderService;
        }
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrderList();
            orders = orderService.GetOrderList().Where(p => p.OrderStatus != "Order Complete").OrderByDescending(p => p.CreatedAt).ToList();
            return View(orders);
        }
        public ActionResult OrderHistory()
        {
            List<Order> orders = orderService.GetOrderList();
            orders = orderService.GetOrderList().Where(p => p.OrderStatus == "Order Complete").OrderByDescending(p => p.CreatedAt).ToList();
            return View(orders);
        }

    }
}