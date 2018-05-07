using System;
using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class CartService {
        
        private BookRepo _bookRepo;
        private PromoCodesRepo _promoCodesRepo;
        public CartService(){
            _bookRepo = new BookRepo();
            _promoCodesRepo = new PromoCodesRepo();
        }
        public List<BookListViewModel> getBooksInCart(List<int> bookIds) {
            var books = new List<BookListViewModel>();
            foreach(var bid in bookIds) {
                var book = _bookRepo.getBook(bid);
                if(book != null) {
                    books.Add(book[0]);
                }
                else {
                    Console.WriteLine("Book with id '" + bid + "' was not found!");
                }
            }
            return books;
        }
       /* public bool validatePromoCode(int promoCode){
            var promoCodes = _promoCodesRepo.getAllPromoCode();
            /*if(promoCodes.Contains(promoCode)){
                return true;
            }
            else {
                return false;
            }
            return false;
        }*/
        public void addBookToCartCookie(int bid) {
            // AJAX?
        }
        public void removeFromCart(int bid) {
            // AJAX?
        }
        public void updateQuantity(int bid, int quantity){
            // TODO
        }
    }
}