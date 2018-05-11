using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class CountryRepo {
        private DataContext _db;

        public CountryRepo() {
            _db = new DataContext();
        }
        public List<Country> getAllCountries() {
            var countries = (from c in _db.Countries
                                select c).ToList();
            return countries;
        }
    }
}