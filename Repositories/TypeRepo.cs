using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class TypeRepo {
        private DataContext _db;

        public TypeRepo() {
            _db = new DataContext();
        }
        public List<TypeListViewModel> getAllTypes() {
            var types = (from typ in _db.Type
                            select new TypeListViewModel {
                            Id = typ.Id,
                            TypeEn = typ.TypeEn,
                            TypeIs = typ.TypeIs
                            }).ToList();
            return types;
        }
    }
}