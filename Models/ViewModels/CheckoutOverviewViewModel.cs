using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TheBookCave.Data.EntityModels;

namespace TheBookCave.Models.ViewModels {
    public class CheckoutOverviewViewModel {
        // First name
        public string Firstname { get; set; }
        // Email
        public string Email { get; set; }
         // Required home address.
        public string Address1 { get; set; }
        // Not required. More detailed address.
        public string Address2 { get; set; }
         // Id that connects address to a certain country.
        public string CountryCode { get; set; }
        // Region.
        public string Region { get; set; }
         // Zip code
        public string Zip { get; set; }
        // Not required user phone number.
        public string Phone { get; set; }
        // Name printed on the card.
        public string NameOnCard { get; set; }
        // Cards expiry date.
        public string ExpiryDate { get; set; }
        // Card number printed on card.
        public string CardNumber { get; set; }
        // The CVC printed on back of card.
        public string CVC { get; set; }
        // List of items in order for display.
        public List<OrderItemB> OrderItems { get; set; }
        public double Sum { get; set; }
    }
}