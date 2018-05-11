using System;
using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class OrderService{
        private OrdersRepo _orderRepo;
        private OrderStatusRepo _orderStatusRepo;
        private BookRepo _bookRepo;
        private PaymentDetailRepo _paymentDetailRepo;
        private ConvertService _convertService;

        private double orderSum;
        public OrderService(){
            _bookRepo = new BookRepo();
            _orderRepo = new OrdersRepo();
            _orderStatusRepo = new OrderStatusRepo();
            _paymentDetailRepo = new PaymentDetailRepo();
            _convertService = new ConvertService();
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
                            on o.TypeId equals t.Id
                            select t).ToList();
            return result;
        }
        private Order convertOrderListViewModelToOrder(OrderListViewModel o) {
            var order = new Order {
                                Id = o.Id,
                                AddressId = o.AddressId,
                                Date = o.Date,
                                TypeId = o.TypeId,
                                UserId = o.UserId,
                                PromoCode = o.PromoCode                           
                                };
            return order;
        }
        public List<OrderItemB> getOrderItemsFromCart(string cookie, int oid) {
            var orderItemList = new List<OrderItemB>();
            if (cookie == null || cookie == "") {
                return null;
            }
            orderSum = 0;
            var cookieContent = getCookiecontent(cookie);
            var id = cookieContent[0];
            var quantity = cookieContent[1];
            for(var i = 0; i < id.Count; i++) {
                var book = _bookRepo.getBook(id[i]);
                if (book.Count != 0) {
                    var eBook = _convertService.bookListViewToEntity(book).First();
                    var sum = eBook.Price * (1 - eBook.Discount/100.0)*quantity[i];
                    orderSum += sum;
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

        public void checkOut(string userId, string cookie, int addressId, string promoCode) {
            var order = new OrderListViewModel();
            //var user = await _userManager.GetUserAsync(User);
            if (promoCode != null) {
                order.PromoCode = promoCode;
            }
            order.UserId = userId;
            order.Date = DateTime.Now; 
            order.TypeId = 2; // Default = 2 Í vinnslu
            order.AddressId = addressId;
            var orderId = createOrder(order);
            var orderItems = getOrderItemsFromCart(cookie, orderId);
            
            order.OrderItemId = new List<int>();
            foreach (var o in orderItems) {
                order.OrderItemId.Add(o.Id);
            }
            _orderRepo.updateOrder(convertOrderListViewModelToOrder(order));
        }

        public CheckoutOverviewViewModel getOrderOverview(string orderDetails, string cartCookie, string promoCode) {
            if (orderDetails == null || orderDetails == "") {
                return null;
            }
            string[] orderInfo = orderDetails.Split(';');
            var orderitems = getOrderItemsFromCart(cartCookie, -1);
            var overviewList =  new CheckoutOverviewViewModel();
            overviewList.Firstname = orderInfo[1];
            overviewList.Email = orderInfo[2];
            overviewList.Phone = orderInfo[3];
            overviewList.Address1 = orderInfo[4];
            overviewList.Address2 = orderInfo[5];
            overviewList.CountryCode = orderInfo[6];
            overviewList.Region = orderInfo[7];
            overviewList.Zip = orderInfo[8];
            overviewList.NameOnCard = orderInfo[10];
            overviewList.CardNumber = orderInfo[11];
            overviewList.ExpiryDate = orderInfo[12];
            overviewList.CVC = orderInfo[13];
            overviewList.OrderItems = new List<OrderItemB>();
            overviewList.Sum = orderSum;
            foreach (var oi in orderitems) {
                overviewList.OrderItems.Add(oi);
            }
            if (promoCode != null) {
                string[] promoSplit = promoCode.Split(':');
                int promoDiscount = Int32.Parse(promoSplit[1]);
                overviewList.Sum = orderSum * (1 - promoDiscount / 100.0);
            }
            return overviewList;
        }

        public int savePaymentDetails(string userId, string name, string cardNumber, string expiryDate, string cvc, int addressId) {
            var pd = new PaymentDetail();
            pd.UserId = userId;
            pd.AddressId = addressId;
            pd.NameOnCard = name;
            pd.ExpiryDate = expiryDate;
            pd.CardNumber = cardNumber;
            pd.CVC = cvc;
            return _paymentDetailRepo.createPaymentDetail(pd);
        }
    }
}