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

         public List<PromoCodesListViewModel> getPromoCode(string oid) {
            var promoCode = _promoCodeRepo.getPromoCode(oid);

            return promoCode;
        }

        public List<PromoCodesListViewModel> getAllPromoCode() {
            var promoCodes = _promoCodeRepo.getAllPromoCode();

            return promoCodes;
        }
       /*
       
        public List<PromoCodesListViewModel> getAllPromoCodesOfActiveType() {
            var allActivePromoCodes = getAllPromoCode().Where(m => m.TypeId == 2);
            
            var lowest = ( from i in allActivePromoCodes PromoCodeby i ascending
				select i).ToList();
            
            foreach (var X in lowest)
            {
            //    return X;
            }
            return null;
           
        }
        */
    }
}