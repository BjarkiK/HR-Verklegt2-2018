using System;
using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class OrdersRepo {
        private DataContext _db;

        public OrdersRepo() {
            _db = new DataContext();
        }
        public List<OrderListViewModel> getOrder(int oid) {
            var order = (from o in _db.Orders
                                where o.Id == oid
                                select new OrderListViewModel {
                                Id = o.Id,
                                AddressId = o.AddressId,
                                Date = o.Date,
                                TypeId = o.TypeId,
                                UserId = o.UserId
                                }).ToList();
            return order;
        }

        internal object getOrder()
        {
            throw new NotImplementedException();
        }

        public List<OrderListViewModel> getAllOrder() {
            var orders = (from o in _db.Orders
                                select new OrderListViewModel {
                                Id = o.Id,
                                AddressId = o.AddressId,
                                Date = o.Date,
                                TypeId = o.TypeId,
                                UserId = o.UserId
                                }).ToList();
            return orders;
        }
        public bool updateOrder(int oid) {
            // linq update
            return true;
        }
        public bool deleteOrder(int oid) {
            // linq delete
            return true;
        }
         public bool createOrder(Order order) {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return true;
        }
    }
}