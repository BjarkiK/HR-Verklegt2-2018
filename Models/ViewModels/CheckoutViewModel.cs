using System.ComponentModel.DataAnnotations;

namespace TheBookCave.Models.ViewModels {
    public class CheckoutViewModel {
        // First name
        public string Firstname { get; set; }
        // Email
        public string Email { get; set; }
        //
        public int Id { get; set; }
        // Id of user owning this address.
        public string UserId { get; set; }
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
    }
}