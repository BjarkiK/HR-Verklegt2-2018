using System;
using System.Collections.Generic;

namespace TheBookCave.Models.ViewModels {
    public class OrderListViewModel {
        public int Id { get; set; }
        // Id of user who made this order.
        public int UserId { get; set; }
        // List of order item ids used in this order.
        public List<int> OrderItemId  { get; set; }
        // Date when order was made.
        public DateTime Date { get; set; }
        // Genre id of order status (Finished, canceled, unfinsished...).
        public int TypeId { get; set; }
        // Id of address shipped to.
        public int AddressId { get; set; }


    }
}