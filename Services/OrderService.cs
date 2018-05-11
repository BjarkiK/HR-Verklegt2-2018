using System;
using System.Collections.Generic;
using System.Linq;
using authentication_repo.Models;
using Microsoft.AspNetCore.Identity;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class OrderService{
        private OrdersRepo _orderRepo;
        private OrderStatusRepo _orderStatusRepo;
        private BookRepo _bookRepo;
        private ConvertService _convertService;
        //private readonly UserManager<ApplicationUser> _userManager;
        public OrderService(){
            _bookRepo = new BookRepo();
            _orderRepo = new OrdersRepo();
            _orderStatusRepo = new OrderStatusRepo();
            _convertService = new ConvertService();
            //_userManager = userManager;
        }
        public List<OrderListViewModel> getUserOrder(string uid){
            var orders = _orderRepo.getAllOrder();
            var result = orders.Where(o => o.UserId == uid).ToList();
            return result;
        }
        public List<OrderStatusListViewModel> getOrderStatus(int oid){
            var order = _orderRepo.getOrder(oid);
            var types = _orderStatusRepo.getAllOrderStatus();
            var result = (from o in order
                            join t in types
                            on o.OrderStatusId equals t.Id
                            select t).ToList();
            return result;
        }
        private Order convertOrderListViewModelToOrder(OrderListViewModel o) {
            var order = new Order {
                                Id = o.Id,
                                AddressId = o.AddressId,
                                Date = o.Date,
                                TypeId = o.TypeId,
                                UserId = o.UserId                              
                                };
            return order;
        }
        public List<OrderItemB> getOrderItemsFromCart(string cookie, int oid) {
            var orderItemList = new List<OrderItemB>();
            if (cookie == null || cookie == "") {
                return null;
            }
            var cookieContent = getCookiecontent(cookie);
            var id = cookieContent[0];
            var quantity = cookieContent[1];
            for(var i = 0; i < id.Count; i++) {
                var book = _bookRepo.getBook(id[i]);
                if (book.Count != 0) {
                    var eBook = _convertService.bookListViewToEntity(book).First();
                    var sum = eBook.Price * (1 - eBook.Discount/100.0)*quantity[i];
                    var orderItem = new OrderItemB{Book = eBook, Quantity = quantity[i], Discount = eBook.Discount, OrderId = oid};
                    var orderItemId = _orderRepo.createOrderItem(orderItem);
                    orderItemList.Add(new OrderItemB {Id = orderItemId, Book = eBook, Quantity = quantity[i], Discount = eBook.Discount, OrderId = oid });
                }
                else {
                    Console.WriteLine("Book with id '" + id[i] + "' was not found!");
                }
            }
            return orderItemList;
        }

        private List<List<int>> getCookiecontent(string cookie) {
            var unpacked = new List<List<int>>();
            var id = new List<int>();
            var quant = new List<int>();
            var cookieItems = cookie.Split('.');
            foreach (var ci in cookieItems) {
                var content = ci.Split('-').Select(Int32.Parse).ToList();
                id.Add(content[0]);
                quant.Add(content[1]);
            }
            unpacked.Add(id);
            unpacked.Add(quant);
            return unpacked;
        }

        public int createOrder(OrderListViewModel o) {
            var order = convertOrderListViewModelToOrder(o);
            return _orderRepo.createOrder(order);
        } 

        public void checkOut(string cookie) {
            var order = new OrderListViewModel();
            //var user = await _userManager.GetUserAsync(User);
            order.UserId = "";
            order.Date = DateTime.Now; 
            order.TypeId = 2; // Default = 2 Í vinnslu
            order.AddressId = -1; // Þarf að stofna Address í fyrri glugga og tengja hér við
            var orderId = createOrder(order);
            var orderItems = getOrderItemsFromCart(cookie, orderId);
            
            order.OrderItemId = new List<int>();
            foreach (var o in orderItems) {
                order.OrderItemId.Add(o.Id);
            }

            _orderRepo.updateOrder(convertOrderListViewModelToOrder(order));
        }
    }
}