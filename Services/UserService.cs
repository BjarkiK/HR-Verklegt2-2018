using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;


namespace TheBookCave.Services{
    public class UserService {
        /*private UserRepo _userRepo;
        private AddressRepo _addressRepo;
        private SubscriptionRepo _subscriptionRepo;
        private BookRepo _bookRepo;*/

        public UserService() {
            /*_userRepo = new UserRepo();
            _addressRepo*/
        }

        public List<UserListViewModel> getUser(string uid){
            /*var user = _userRepo.GetUser(uid);
            return user;*/
            return null;
        }
        public List<AddressListViewModel> getUserAddresss(string uid) {
            /* var user = _userRepo.GetUser(uid);
            var address = _addressRepo.GetAddress(user.addressId);
            return address */
            return null;
        }
        public List<SubscriptionListViewModel> getUserSubscriptions(string uid) {
            /* var user = _userRepo.GetUser(uid);
            var subscriptions = _subscriptionRepo.GetAllSubscriptions();
            finna svo þar sem user.subscription passar við og skila */
            return null;
        }
        public List<BookListViewModel> getUserFavoriteBooks(string uid) {
            /*var user = _userRepo.GetUser(uid);
            var books = _bookRepo.GetAllBooks();
            bera svo saman við user.favoriteBooks við allar bækur og skila.*/
            return null;
        }
        public void updateUser(UserListViewModel user) {
            // Ekki viss hvernig er best að græja þetta.
        }
    }
}