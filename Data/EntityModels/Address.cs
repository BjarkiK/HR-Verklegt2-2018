/*
    Address entity class
    Address2 not required 
 */
namespace TheBookCave.Data.EntityModels {
    public class Address {
        public int Id { get; set; }
        // Id of user owning this address.
         public string UserId { get; set; }
         // Required home address.
        public string Address1 { get; set; }
        // Not required. More detailed address.
        public string Address2 { get; set; }
         // Id that connects address to a certain country.
        public int CountryId { get; set; }
        // Region.
        public string Region { get; set; }
         // Zip code
        public string Zip { get; set; }
        // Not required user phone number.
        public string Phone { get; set; }


    }
}