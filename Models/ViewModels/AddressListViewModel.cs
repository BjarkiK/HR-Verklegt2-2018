using System.ComponentModel.DataAnnotations;

namespace TheBookCave.Models.ViewModels {
    public class AddressListViewModel {
        public int Id { get; set; }
        // Id of user owning this address.
         public string UserId { get; set; }
         // Required home address.
        [Required]
        public string Address1 { get; set; }
        // Not required. More detailed address.
        public string Address2 { get; set; }
         // Id that connects address to a certain country.
        public int CountryId { get; set; }
        // Region.
        [Required]
        public string Region { get; set; }
         // Zip code
        [Required]
        public string Zip { get; set; }
        // Not required user phone number.
        public string Phone { get; set; }
    }
}