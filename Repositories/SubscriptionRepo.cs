using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
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
        public bool removeSub(Subscription sub){
            _db.Subscriptions.Remove(sub);
            _db.SaveChanges();
            return true;
        }
        public bool createSubscription(Subscription subscription) {
            _db.Subscriptions.Add(subscription);
            _db.SaveChanges();
            return true;
        }
        public bool updateSubscription(Subscription subscription) {
            _db.Subscriptions.Update(subscription);
            _db.SaveChanges();
            return true;
        }
    }
}