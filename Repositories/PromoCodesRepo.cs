using System;
using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class PromoCodesRepo {
        private DataContext _db;

        public PromoCodesRepo() {
            _db = new DataContext();
        }
        public List<PromoCodeListViewModel> getPromoCode(int pcId) {
            var promoCode = (from pc in _db.PromoCodes
                                where pc.Id == pcId
                                select new PromoCodeListViewModel {
                                    Id = pc.Id,
                                    Description = pc.Description,
                                    Discount = pc.Discount,
                                    Published = pc.Published
                                }).ToList();
            return promoCode;
        }
        public List<PromoCodeListViewModel> getAllPromoCode() {
            var promoCodes = (from pc in _db.PromoCodes
                                select new PromoCodeListViewModel {
                                    Id = pc.Id,
                                    Code = pc.Code,
                                    Description = pc.Description,
                                    Discount = pc.Discount,
                                    Published = pc.Published
                                }).ToList();
            return promoCodes;
        }

        public bool deletePromoCode(int pcid) {
            // linq delete
            return true;
        }
         public bool createPromoCode(PromoCode promocode) {
            _db.PromoCodes.Add(promocode);
            _db.SaveChanges();
            return true;
        }
         public bool updatePromoCode(PromoCode promoCode) {
            _db.PromoCodes.Update(promoCode);
            _db.SaveChanges();
            return true;
        }
    }
}