using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class OrderStatusRepo {
        private DataContext _db;

        public OrderStatusRepo() {
            _db = new DataContext();
        }
        public List<OrderStatusListViewModel> getAllOrderStatus() {
            var types = (from stat in _db.OrderStatus
                            select new OrderStatusListViewModel {
                            Id = stat.Id,
                            StatusEN = stat.StatusEN,
                            StatusIS = stat.StatusIS
                            }).ToList();
            return types;
        }
    }
}