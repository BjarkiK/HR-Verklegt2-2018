using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    public class UserController : Controller
    {
        private UserService _userService;
       private OrderService _orderService;

        public UserController() {
            _userService = new UserService();
            _orderService = new OrderService();
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

        [Authorize]
        public bool addToFav(int bid){
            Console.WriteLine(bid);
            var userId = User.Claims.ToArray()[0].Value;
            return _userService.addFavoriteBook(userId, bid);
        }
        public IActionResult userOrderDetails(int id)
        {
            var orderDetails = _orderService.getOrderStatus(id);
            return View(orderDetails);
        }
        public IActionResult userUpdate(string uid)
        {
            /*_userService.updateUser(uid);*/
            return View();
        }
    }
}
