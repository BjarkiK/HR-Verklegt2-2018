using System.Collections.Generic;
using System.Linq;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class OrderService{
        private OrdersRepo _ordersRepo;
        private OrderStatusRepo _orderStatusRepo;
        public OrderService(){
            _ordersRepo = new OrdersRepo();
            _orderStatusRepo = new OrderStatusRepo();
        }
        public List<OrderListViewModel> getUserOrder(string uid){
            var orders = _ordersRepo.getAllOrder();
            var result = orders.Where(o => o.UserId == uid).ToList();
            return result;
        }
        public List<OrderStatusListViewModel> getOrderStatus(int oid){
            var order = _ordersRepo.getOrder(oid);
            var types = _orderStatusRepo.getAllOrderStatus();
            var result = (from o in order
                            join t in types
                            on o.OrderStatusId equals t.Id
                            select t).ToList();
            return result;
        }
    }
}