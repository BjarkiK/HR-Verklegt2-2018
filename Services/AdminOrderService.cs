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
            var order = ConvertOrderListViewModelToOrder(o);
            var successfull = _orderRepo.updateOrder(order);
        }

        public void CreateOrder(OrderListViewModel o) {
            var order = ConvertOrderListViewModelToOrder(o);
            var successfull = _orderRepo.createOrder(order);
        }

        private Order ConvertOrderListViewModelToOrder(OrderListViewModel o) {
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


/*

        public List<OrderListViewModel> getAllOrdersOfActiveType() {
            var allActiveOrders = getAllOrder().Where(m => m.TypeId == 2);
            
            var lowest = ( from i in allActiveOrders orderby i ascending
				select i).ToList();
            
            foreach (var X in lowest)
            {
            //    return X;
            }
            return null;
           
        }
 */
    }
}