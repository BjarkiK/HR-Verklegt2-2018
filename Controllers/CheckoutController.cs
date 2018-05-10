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
        //private CheckoutService _checkoutService;
        //private OrderService _orderservice;

        public CheckoutController() {
            //_checkoutService = new CheckoutService();
            //_orderservice = new OrderService();
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
        
        public void autofillLoggedinUserDetails(string uid)
        {
            /*
            if (_userService.loggedIn(uid)) {
                var userPaymentDetails = _checkoutService.getLoggedinUserMainPaymentDetails(uid);
                var userAddress = _checkoutService.getLoggedinUserMainAddress(uid);
            }
            */
        }
        public void createOrder()
        {
            //_checkoutService.createOrder(Order);
        }
    }
}
