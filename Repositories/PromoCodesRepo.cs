using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class PromoCodesRepo {
        private DataContext _db;

        public PromoCodesRepo() {
            _db = new DataContext();
        }
        /*public List<PromoCodesListViewModel> getPromoCode(string pcid) {
            var promoCode = (from pc in _db.PromoCodes
                                where pc.Id == pcid
                                select new PromoCodesListViewModel {
                                Id = pc.Id,
                                Description = pc.Description,
                                Discount = pc.Discount,
                                Published = pc.Published
                                }).ToList();
            return promoCode;
        }
        public List<PromoCodesListViewModel> getAllPromoCode() {
            var promoCodes = (from pc in _db.PromoCodes
                                select new PromoCodesListViewModel {
                                Id = pc.Id,
                                Description = pc.Description,
                                Discount = pc.Discount,
                                Published = pc.Published
                                }).ToList();
            return promoCodes;
        }
        public bool updatePromoCode(int pcid) {
            // linq update
            return true;
        }
        public bool deletePromoCode(int pcid) {
            // linq delete
            return true;
        }
        public bool createPromoCode() {
            // linq insert
            return true;
        }*/
    }
}