using System;
using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services
{
    public class CartService {
        
        private BookRepo _bookRepo;
        private PromoCodesRepo _promoCodesRepo;
        private ConvertService _convertService;
        public CartService(){
            _bookRepo = new BookRepo();
            _promoCodesRepo = new PromoCodesRepo();
            _convertService = new ConvertService();
        }
        public List<CartListViewModel> getBooksInCart(string cookie) {
            var books = new List<CartListViewModel>();
            if(cookie == null || cookie == "") {
                return new List<CartListViewModel>();
            }
            var cookieContent = getCookiecontent(cookie);
            var id = cookieContent[0];
            var quantity = cookieContent[1];
            for(var i = 0; i < id.Count; i++) {
                var book = _bookRepo.getBook(id[i]);
                if(book.Count  != 0) {
                    var eBook = _convertService.bookListViewToEntity(book).First();
                    var sum = eBook.Price * (1 - eBook.Discount/100.0)*quantity[i];
                    books.Add(new CartListViewModel { Book = eBook, Quantity = quantity[i], Sum = sum });
                }
                else {
                    Console.WriteLine("Book with id '" + id[i] + "' was not found!");
                }
            }
            return books;
        }

        private List<List<int>> getCookiecontent(string cookie) {
            var unpacked = new List<List<int>>();
            var id = new List<int>();
            var quant = new List<int>();
            var cookieItems = cookie.Split('.');
            foreach(var ci in cookieItems) {
                var content = ci.Split('-').Select(Int32.Parse).ToList();
                id.Add(content[0]);
                quant.Add(content[1]);
            }
            unpacked.Add(id);
            unpacked.Add(quant);
            return unpacked;
        }
        private List<int> getCartBookQuantity(string cookie) {
            return cookie.Split('.').Select(Int32.Parse).ToList();
        }
       public int validatePromoCode(string code){
            var promoCodes = _promoCodesRepo.getAllPromoCode();
            var promoCode =  (from pc in promoCodes
                            where pc.Code == code
                            && pc.Published == true
                            select pc).SingleOrDefault();
            return promoCode.Discount;
        }

       /* public bool addBookToCart(int bid) {
            return true;
        }*/ 
        public void removeFromCart(int bid) {
            // AJAX?
        }
        public void updateQuantity(int bid, int quantity){
            // TODO
        }

        public void checkout(){
            
        }
    }
}