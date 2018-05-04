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

         public List<OrderListViewModel> GetOrder(int oid) {
            var order = _orderRepo.getOrder(oid);

            return order;
        }

        public List<OrderListViewModel> GetAllOrder() {
            var orders = _orderRepo.getAllOrder();

            return orders;
        }
        public List<OrderListViewModel> getAllOrdersOfActiveType() {
          //  var allOrders = GetAllOrder().Where(m.Order.TypeId => m.Order.TypeId = 2);

            return null;

          //  return activeorders;
        }
    }
}