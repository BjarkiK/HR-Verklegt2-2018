namespace TheBookCave.Models.ViewModels {
    public class AddressListViewModel {
        public int AddressId { get; set; }
        // Id of user owning this address.
         public string UserId { get; set; }
         // Required home address.
        public string Address1 { get; set; }
        // Not required. More detailed address.
        public string Address2 { get; set; }
        // Id that connects address to a certain region.
        public int RegionId { get; set; }
         // Id that connects address to a certain zip code.
        public int ZipId { get; set; }
         // Id that connects address to a certain country.
        public string CountryId { get; set; }
        // Not required user phone number.
        public string Phone { get; set; }


    }
}