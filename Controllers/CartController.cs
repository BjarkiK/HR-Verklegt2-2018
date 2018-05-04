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
    public class CartController : Controller
    {
        //private CookService _cookService;

        public CartController() {
            //_cartService = new CookService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult cartDisplay(string[] bid)
        {
            /*cartList = _cartService.getBooksInCart(bid[]);
            return View(cartList);*/
            return View();
        }
    }
}
