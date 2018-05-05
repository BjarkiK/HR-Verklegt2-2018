using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class OrderService{
        private OrdersRepo _ordersRepo;
        public OrderService(){
            _ordersRepo = new OrdersRepo();
        }
        public List<OrderListViewModel> getUserOrder(string uid){
            var orders = _ordersRepo.getAllOrder();
            // Filter out where order belong to user
            return orders;
        }
        public List<OrderListViewModel> getOrderStatus(int oid){
            var order = _ordersRepo.getAllOrder();
            // Find status
            return order;
        }
    }
}