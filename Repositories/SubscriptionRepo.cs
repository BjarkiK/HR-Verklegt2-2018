using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class SubscriptionRepo {
        private DataContext _db;

        public SubscriptionRepo() {
            _db = new DataContext();
        }
        public List<SubscriptionListViewModel> getSubscription(int sid) {
            var subscription = (from sub in _db.Subscriptions 
                                where sub.Id == sid
                                select new SubscriptionListViewModel {
                                Id = sub.Id,
                                DescriptionEn = sub.DescriptionEn,
                                DescriptionIn = sub.DescriptionIn,
                                TypeEn = sub.TypeEn,
                                TypeIn = sub.TypeIn,
                                Published = sub.Published
                                }).ToList();
            return subscription;
        }
        public List<SubscriptionListViewModel> getAllSubscription() {
            var subscription = (from sub in _db.Subscriptions 
                                select new SubscriptionListViewModel {
                                Id = sub.Id,
                                DescriptionEn = sub.DescriptionEn,
                                DescriptionIn = sub.DescriptionIn,
                                TypeEn = sub.TypeEn,
                                TypeIn = sub.TypeIn,
                                Published = sub.Published
                                }).ToList();
            return subscription;
        }
        public bool updateSubscription(int sid) {
            // linq update
            return true;
        }
        public bool deleteSubscription(int sid) {
            // linq delete
            return true;
        }
        public bool createSubscription() {
            // linq insert
            return true;
        }
    }
}