using System.Collections.Generic;
using System.Linq;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class OrderService{
        private OrdersRepo _ordersRepo;
        private TypeRepo _typeRepo;
        public OrderService(){
            _ordersRepo = new OrdersRepo();
            _typeRepo = new TypeRepo();
        }
        public List<OrderListViewModel> getUserOrder(string uid){
            var orders = _ordersRepo.getAllOrder();
            var result = orders.Where(o => o.UserId == uid).ToList();
            return result;
        }
        public List<TypeListViewModel> getOrderStatus(int oid){
            var order = _ordersRepo.getOrder(oid);
            var types = _typeRepo.getAllTypes();
            var result = (from o in order
                            join t in types
                            on o.TypeId equals t.Id
                            select t).ToList();
            return result;
        }
    }
}