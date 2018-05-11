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

        public void removeSub(SubscriptionListViewModel s) {
            var sub = convertSubscriptionListViewModelToSubscription(s);
            var successfull = _subscriptionRepo.removeSub(sub);
        }

        public List<SubscriptionListViewModel> getAllSubscription() {
            var subscription = _subscriptionRepo.getAllSubscription();

            return subscription;
        }
        public void updateSubscription(SubscriptionListViewModel sub) {
            var subscription = convertSubscriptionListViewModelToSubscription(sub);
            var successfull = _subscriptionRepo.updateSubscription(subscription);
        }


        public void createSubscription(SubscriptionListViewModel sub) {
            var subscription = convertSubscriptionListViewModelToSubscription(sub);
            var successfull = _subscriptionRepo.createSubscription(subscription);
        }

         private Subscription convertSubscriptionListViewModelToSubscription(SubscriptionListViewModel sub) {
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

     
