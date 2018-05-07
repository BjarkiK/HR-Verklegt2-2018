using System;
using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class AdminPromoCodeService {
        private PromoCodesRepo _promoCodeRepo;

        public AdminPromoCodeService() {
            _promoCodeRepo = new PromoCodesRepo();
        }

         public List<PromoCodeListViewModel> getPromoCode(int id) {
            var promoCode = _promoCodeRepo.getPromoCode(id);

            return promoCode;
        }

        public List<PromoCodeListViewModel> getAllPromoCode() {
            var promoCodes = _promoCodeRepo.getAllPromoCode();
            Console.WriteLine(promoCodes.First().Code);
            return promoCodes;
        }

         public void CreatePromocode(PromoCodeListViewModel pc) {
            var promocode = ConvertPromoCodeListViewModelToPromoCode(pc);
            var successfull = _promoCodeRepo.createPromoCode(promocode);
        }

        private PromoCode ConvertPromoCodeListViewModelToPromoCode(PromoCodeListViewModel pc) {
            var promoCode = new PromoCode {
                                Id = pc.Id,
                                Description = pc.Description,
                                Discount = pc.Discount,
                                Published = pc.Published,   
                                Code = pc.Code                           
                                };
            return promoCode;
        }


         public List<PromoCodeListViewModel> getSearchResult(string searchString) {
            var promoCode = _promoCodeRepo.getAllPromoCode();
            var searchResult = (from pc in promoCode
                        where pc.Description.ToLower().Contains(searchString.ToLower())
                        select new PromoCodeListViewModel {
                                    Id = pc.Id,
                                    Description = pc.Description,
                                    Discount = pc.Discount,
                                    Published = pc.Published,
                                    Code = pc.Code 
                        }).ToList();

            return searchResult;
        }
    }
}