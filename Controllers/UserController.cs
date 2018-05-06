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
    public class UserController : Controller
    {
        private UserService _userService;
       // private OrderService _orderService;

        public UserController() {
            _userService = new UserService();
           // _orderService = new OrderService();
        }
        public IActionResult index()
        {
            return View();
        }
        public IActionResult details(string id)
        {
            var user = _userService.getUser(id);
            return View(user);
        }
        public IActionResult userOrderListDisplay(string uid)
        {
            /*var orders = _orderService.getUserOrder(uid);
            return View(orders);*/
            return View();
        }
        public IActionResult userOrderDetails(string oid)
        {
            /*var orderDetails = _orderService.getOrderStatus(oid);
            return View(orderDetails);*/
            return View();
        }
        public IActionResult userUpdate(string uid)
        {
            /*_userService.updateUser(uid);*/
            return View();
        }
    }
}
