using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class AddressRepo {
        private DataContext _db;

        public AddressRepo() {
            _db = new DataContext();
        }
        public List<AddressListViewModel> getAddress(int aid) {
            var address = (from a in _db.Address
                                where a.Id == aid
                                select new AddressListViewModel {
                                AddressId = a.Id,
                                Address1 = a.Address1,
                                Address2 = a.Address2,
                                CountryId = a.CountryId,
                                Phone = a.Phone,
                                RegionId = a.RegionId,
                                UserId = a.UserId,
                                ZipId = a.ZipId
                                }).ToList();
            return address;
        }
        public List<AddressListViewModel> getAllAddresses() {
            var address = (from a in _db.Address
                                select new AddressListViewModel {
                                AddressId = a.Id,
                                Address1 = a.Address1,
                                Address2 = a.Address2,
                                CountryId = a.CountryId,
                                Phone = a.Phone,
                                RegionId = a.RegionId,
                                UserId = a.UserId,
                                ZipId = a.ZipId
                                }).ToList();
            return address;
        }
        public bool updateAddress(int aid) {
            // linq update
            return true;
        }
        public bool deleteAddress(int aid) {
            // linq delete
            return true;
        }
        public bool createAddress() {
            // linq insert
            return true;
        }
    }
}