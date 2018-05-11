using System;
using System.Collections.Generic;

namespace TheBookCave.Data.EntityModels {
    public class Order {
        public int Id { get; set; }
        // Id of user who made this order.
        public string UserId { get; set; }
        // Date when order was made.
        public DateTime Date { get; set; }
        // Genre id of order status (Finished, canceled, unfinsished...).
        public int TypeId { get; set; }
        // Id of address shipped to.
        public int AddressId { get; set; }
    }
}