using System.Collections.Generic;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;
using System.Linq;


namespace TheBookCave.Services{
    public class UserService {
        private UserRepo _userRepo;
        private AddressRepo _addressRepo;
        private SubscriptionRepo _subscriptionRepo;
        private BookRepo _bookRepo;
        private CountryRepo _contryRepo;

        public UserService() {
            _userRepo = new UserRepo();
            _addressRepo = new AddressRepo();
            _subscriptionRepo = new SubscriptionRepo();
            _bookRepo = new BookRepo();
            _contryRepo = new CountryRepo();
        }

        public List<UserListViewModel> getUser(string uid){
            var user = _userRepo.getUser(uid);
            return user;
        }

        public string  getUserIdByEmail(string email) {
            var users = _userRepo.getAllUsers();

            var userId = (from u in users
                        where email == u.Email
                        select u.Id).SingleOrDefault();
            return userId;
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