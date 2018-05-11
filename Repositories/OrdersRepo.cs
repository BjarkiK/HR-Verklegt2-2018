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
                                    Address = o.Address,
                                    PromoCode = o.PromoCode,
                                    Date = o.Date,
                                    OrderStatusId = o.OrderStatusId,
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
                                    Address = o.Address,
                                    PromoCode = o.PromoCode,
                                    Date = o.Date,
                                    OrderStatusId = o.OrderStatusId,
                                    UserId = o.UserId
                                }).ToList();
            return orders;
        }
        public bool deleteOrder(int oid) {
            // linq delete
            return true;
        }
         public int createOrder(Order order) {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return order.Id;
        }
        public int createOrderItem(OrderItemB orderItemB) {
            var orderItem = new OrderItem { Id = orderItemB.Id, BookId = orderItemB.Book.Id, Discount = orderItemB.Discount, Quantity = orderItemB.Quantity, OrderId = orderItemB.OrderId };
            _db.OrderItems.Add(orderItem);
            _db.SaveChanges();
            var orderItemBook = new OrderItemBook { BookId = orderItemB.Book.Id, OrderItemId = orderItem.Id, Name = orderItemB.Book.Name, Picture = orderItemB.Book.Picture, DetailsIS = orderItemB.Book.DetailsIS, DetailsEN = orderItemB.Book.DetailsEN, GenreId = orderItemB.Book.GenreId, AuthorId = orderItemB.Book.AuthorId, PublisherId = orderItemB.Book.PublisherId, Price = orderItemB.Book.Price, Discount = orderItemB.Book.Discount, Pages = orderItemB.Book.Pages, Quantity = orderItemB.Book.Quantity, Grade = orderItemB.Book.Grade, NrOfGrades = orderItemB.Book.NrOfGrades, Published = orderItemB.Book.Published};
            _db.OrderItemBook.Add(orderItemBook);
            _db.SaveChanges();
            return orderItem.Id;
        }
         public bool updateOrder(Order order) {
            _db.Orders.Update(order);
            _db.SaveChanges();
            return true;
        }
    }
}