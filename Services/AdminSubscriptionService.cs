using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class AdminSubscriptionService {
        private SubscriptionRepo _subscriptionRepo;

        public AdminSubscriptionService() {
            _subscriptionRepo = new SubscriptionRepo();
        }

         public List<SubscriptionListViewModel> getSubscription(int sid) {
            var subscription = _subscriptionRepo.getSubscription(sid);

            return subscription;
        }

        public List<SubscriptionListViewModel> getAllSubscription() {
            var subscription = _subscriptionRepo.getAllSubscription();

            return subscription;
        }
        public void updateSubscription(SubscriptionListViewModel sub) {
            var subscription = ConvertSubscriptionListViewModelToSubscription(sub);
            var successfull = _subscriptionRepo.updateSubscription(subscription);
        }


        public void CreateSubscription(SubscriptionListViewModel sub) {
            var subscription = ConvertSubscriptionListViewModelToSubscription(sub);
            var successfull = _subscriptionRepo.createSubscription(subscription);
        }

         private Subscription ConvertSubscriptionListViewModelToSubscription(SubscriptionListViewModel sub) {
            var subscription = new Subscription {
                                Id = sub.Id,
                                DescriptionEn = sub.DescriptionEn,
                                DescriptionIn = sub.DescriptionIn,
                                TypeEn = sub.TypeEn,
                                TypeIn = sub.TypeIn,
                                Published = sub.Published                          
                                };
            return subscription;
        }
        

         public List<SubscriptionListViewModel> getSearchResult(string searchString) {
            var subscription = _subscriptionRepo.getAllSubscription();
            var searchResult = (from sub in subscription
                        where sub.DescriptionEn.ToLower().Contains(searchString.ToLower())
                        select new SubscriptionListViewModel {
                                Id = sub.Id,
                                DescriptionEn = sub.DescriptionEn,
                                DescriptionIn = sub.DescriptionIn,
                                TypeEn = sub.TypeEn,
                                TypeIn = sub.TypeIn,
                                Published = sub.Published
                        }).ToList();

            return searchResult;
        }

    }
}    
    /*
       public List<OrderListViewModel> getAllOrdersOfActiveType() {
            var allActiveOrders = getAllOrder().Where(m => m.TypeId == 2);
            
            var lowest = ( from i in allActiveOrders orderby i ascending
				select i).ToList();
            
            foreach (var X in lowest)
            {
            //    return X;
            }
            return null;
           
        }
    }
    
     */
     
