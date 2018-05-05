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
        // Gets all active orders. Use all order list where TypeId == 2. 
        // If that is the case typeId will write 

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
    }
}