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
     
