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

        public Address getAddress(int aid) {
            var addresses = _addressRepo.getAllAddresses();
            var address = (from a in addresses
                            where aid == a.Id
                            select a ).SingleOrDefault();
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
        public int getCountryId(string country) {
            if (country == "") {
                return 0;
            }
            var countries = _countryRepo.getAllCountries();
            var cid = (from c in countries
                        where country == c.CountryCode
                        select c.Id).SingleOrDefault();
            return cid;
        }

        public List<Country> getAllCountries() {
           return _countryRepo.getAllCountries();
        }

        public int initialiceUserAddress() {
            return _addressRepo.createAddress(new Address());
        }
        public void updateAddress(Address address) {
            _addressRepo.updateAddress(address);
        }

        public int createAddress(string uid, string address1, string address2, string country, string region, string zip, string phone) {
            var countryId = getCountryId(country);
            var address = new Address();
            address.UserId = uid;
            address.Address1 = address1;
            address.Address2 = address2;
            address.CountryId = countryId;
            address.Region = region;
            address.Zip = zip;
            address.Phone = phone;
            var aid = _addressRepo.createAddress(address);
            return aid;
        }
    }
}