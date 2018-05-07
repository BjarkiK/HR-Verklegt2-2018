using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models.ViewModels;
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
            var books = _cartService.getBooksInCart(getCartBookIdList());            
            return View(books);
        }
        

        private List<int> getCartBookIdList() {
            var cookie = Request.Cookies["TBCbooksInChart"];
            if(cookie != null) {
                return unpackCookie(cookie);
            }
            return new List<int>();
        }

        private List<int> unpackCookie(string cookie) {
            var bookIdsString = cookie.Split(".");
            var bookIds = new List<int>();
            foreach(var b in bookIdsString) {
                bookIds.Add(Int32.Parse(b));
            }
            return bookIds;
        }
        public IActionResult cartDisplay(string[] bid) {
            /*cartList = _cartService.getBooksInCart(bid[]);
            return View(cartList);*/
            return View();
        }
    }
}
