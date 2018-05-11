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
    public class CheckoutController : Controller
    {
        private CartService _cartService;
        private OrderService _orderService;

        public CheckoutController() {
            _cartService = new CartService();
            _orderService = new OrderService();
        }
        public IActionResult index()
        {
            return View();
        }
        public IActionResult creditInfo()
        {
            return View();
        }
        public IActionResult overview()
        {
            return View();
        }
        public void checkout() 
        {
            var cookie = Request.Cookies["TBCbooksInCart"];
            _orderService.checkOut(cookie);
        }
        public void autofillLoggedinUserDetails(string uid)
        {
            /*
            if (_userService.loggedIn(uid)) {
                var userPaymentDetails = _checkoutService.getLoggedinUserMainPaymentDetails(uid);
                var userAddress = _checkoutService.getLoggedinUserMainAddress(uid);
            }
            */
        }
    }
}
