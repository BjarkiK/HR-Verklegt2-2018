using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class AdminOrderService {
        private OrdersRepo _orderRepo;

        public AdminOrderService() {
            _orderRepo = new OrdersRepo();
        }

         public List<OrderListViewModel> getOrder(int oid) {
            var order = _orderRepo.getOrder(oid);

            return order;
        }

        public List<OrderListViewModel> getAllOrder() {
            var orders = _orderRepo.getAllOrder();

            return orders;
        }

         public void updateOrder(OrderListViewModel o) {
            var order = convertOrderListViewModelToOrder(o);
            var successfull = _orderRepo.updateOrder(order);
        }

        public void createOrder(OrderListViewModel o) {
            var order = convertOrderListViewModelToOrder(o);
            var successfull = _orderRepo.createOrder(order);
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

         public List<OrderListViewModel> getSearchResult(string searchString) {
            var orders = _orderRepo.getAllOrder();
            var searchResult = (from o in orders
                        where o.Date.ToString().Contains(searchString)
                        select new OrderListViewModel
                        {
                            Id = o.Id,
                            AddressId = o.AddressId,
                            Date = o.Date,
                            TypeId = o.TypeId,
                            UserId = o.UserId
                        }).ToList();

            return searchResult;
        }

        public void removeO(OrderListViewModel o ) {
            var order = convertOrderListViewModelToOrder(o);
            var successfull = _orderRepo.removeOrder(order);
        }


    }
}