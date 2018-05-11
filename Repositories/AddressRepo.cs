using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class AddressRepo {
        private DataContext _db;

        public AddressRepo() {
            _db = new DataContext();
        }
        public List<AddressListViewModel> getAddress(int aid) {
            var address = (from a in _db.Addresses
                                where a.Id == aid
                                select new AddressListViewModel {
                                    Id = a.Id,
                                    Address1 = a.Address1,
                                    Address2 = a.Address2,
                                    CountryId = a.CountryId,
                                    Phone = a.Phone,
                                    Region = a.Region,
                                    Zip = a.Zip,
                                    UserId = a.UserId                                    
                                }).ToList();
            return address;
        }
        public List<Address> getAllAddresses() {
            var address = (from a in _db.Addresses
                                select a ).ToList();
            return address;
        }
        public bool updateAddress(Address address) {
            _db.Update(address);
            _db.SaveChanges();
            return true;
        }
        public bool deleteAddress(int aid) {
            // linq delete
            return true;
        }
        public int createAddress(Address address) {
            _db.Addresses.Add(address);
            _db.SaveChanges();
            return address.Id;
        }
    }
}