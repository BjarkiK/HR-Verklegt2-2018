using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class SubscriptionService{
        private SubscriptionRepo _subscriptionRepo;
        public SubscriptionService(){
            _subscriptionRepo = new SubscriptionRepo();
        }
        public List<SubscriptionListViewModel> getAllSubscriptions(){
            var subscriptions = _subscriptionRepo.getAllSubscription();
            return subscriptions;
        }
        public void addNewSubscriptionToUser(string uid, int sid){
            //TODO
        }
        public void cancelSubscripton(string uid, int sid){
            //TODO
        }
        public List<SubscriptionListViewModel> getOneSubscription(int sid){
            var subscription = _subscriptionRepo.getSubscription(sid);
            return subscription;
        }
    }
}