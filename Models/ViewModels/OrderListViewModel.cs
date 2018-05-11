using System;
using System.Collections.Generic;
using TheBookCave.Data.EntityModels;

namespace TheBookCave.Models.ViewModels {
    public class OrderListViewModel {
        public int Id { get; set; }
        // Id of user who made this order.
        public string UserId { get; set; }
        // Id of orderStatus type
        public int OrderStatusId { get; set; }
        // Date when order was made.
        public DateTime Date { get; set; }
        // PromoCode of any
        public PromoCode PromoCode { get; set; }
        // Address shipped to
        public Address Address { get; set; }
    }
}