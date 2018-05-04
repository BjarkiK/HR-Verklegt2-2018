using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    public class AdminActiveOrderController : Controller
    {
        //private AdminOrderService _adminOrderService;

        public AdminActiveOrderController() {
            //_adminOrderService = new AdminOrderService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult activeOrderListDisplay()
        {
            /*var activeOrders = _adminOrderService.getAllOrdersOfActiveType();
            return View(activeOrders);*/
            return View();
        }
        public IActionResult activeOrderDetails(int oid)
        {
            /*var order = _adminOrderService.getOrder(oid);
            return View(order);*/
            return View();
        }
        public void activeOrderUpdate(int oid)
        {
            //_adminOrderService.updateOrder(oid);
        }
        public void addNewOrder() 
        {
            //_adminOrderService.createOrder();
        }
    }
}
