using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    public class CartController : Controller
    {
        private CartService _cartService;

        public CartController() {
            _cartService = new CartService();
        }
        public IActionResult index() {
            var cookie = Request.Cookies["TBCbooksInCart"];
            var books = _cartService.getBooksInCart(cookie);       
            return View(books);
        }
        
        public IActionResult cartDisplay(string[] bid) {
            /*cartList = _cartService.getBooksInCart(bid[]);
            return View(cartList);*/
            return View();
        }
    }
}
