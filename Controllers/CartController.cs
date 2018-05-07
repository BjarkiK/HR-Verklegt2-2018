using System;
using Microsoft.AspNetCore.Mvc;

namespace TheBookCave.Controllers
{
    public class CartController : Controller
    {
        //private CookService _cookService;

        public CartController() {
            //_cartService = new CookService();
        }
        public IActionResult index() {
            var cookie = Request.Cookies["bajrki"];
            if(cookie != null) {
                Console.WriteLine(cookie);
            } else {
                Console.WriteLine("cookie not set");
            }
            
            return View();
        }
        public IActionResult cartDisplay(string[] bid) {
            /*cartList = _cartService.getBooksInCart(bid[]);
            return View(cartList);*/
            return View();
        }
    }
}
