using System.Collections.Generic;
using TheBookCave.Data.EntityModels;

namespace TheBookCave.Models.ViewModels {
    public class ProfileViewModel {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Picture { get; set; }
        public Address Address { get; set; }
        public List<Order> Orders { get; set; }
        public List<Country> Countries { get; set; }
        public string Country { get; set; }

    }
}