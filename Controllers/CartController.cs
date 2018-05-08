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

        // Every time user adds something to cart a new order and order items are created.
        // The order item is never deleted unless removed from cart
        // Good bad? 
        // Good for analises to check what users are adding th chart. 
        // Bad because of unnessesary use of memory resources.
        public bool addBookToCart(int id) {
            return _cartService.addBookToCart(id);
        }
    }
}
