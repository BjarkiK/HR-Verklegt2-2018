using System.Collections.Generic;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;
using System.Linq;

namespace TheBookCave.Services {
    public class AddressService{

        private AddressRepo _addressRepo;
        private CountryRepo _countryRepo;

        public AddressService() {
            _addressRepo = new AddressRepo();
            _countryRepo = new CountryRepo();
        }

        public Address getUserAddress(string uid) {
            var addresses = _addressRepo.getAllAddresses();
            var address = (from a in addresses
                            where uid == a.UserId
                            select new Address {
                                Id = a.Id,
                                UserId = a.UserId,
                                Address1 = a.Address1,
                                Address2 = a.Address2,
                                CountryId = a.CountryId,
                                Region = a.Region,
                                Zip = a.Zip,
                                Phone = a.Phone,
                            }).SingleOrDefault();
            return address;
        }

        public string getUserAddressCountry(int cid) {
            if(cid == 0) {
                return null;
            }
            var countries = _countryRepo.getAllCountries();
            var address = (from c in countries
                            where cid == c.Id
                            select c.Name ).SingleOrDefault();
            return address;
        }

        public List<Country> getAllCountries() {
           return _countryRepo.getAllCountries();
        }

        public void initialiceUserAddress(string uid) {
            _addressRepo.createAddress(new Address { UserId = uid });
        }
        public void updateAddress(Address address) {
            _addressRepo.updateAddress(address);
        }
    }
}