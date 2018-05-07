using System;
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
            Console.WriteLine(promoCodes.First().Code);
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
        }
    }
}