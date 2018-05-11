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
        private FavBookRepo _favBookRepo;
        private ConvertService _convertService;

        public UserService() {
            _userRepo = new UserRepo();
            _addressRepo = new AddressRepo();
            _subscriptionRepo = new SubscriptionRepo();
            _bookRepo = new BookRepo();
            _contryRepo = new CountryRepo();
            _favBookRepo = new FavBookRepo();
            _convertService = new ConvertService();
            
        }

        public List<UserListViewModel> getUser(string uid){
            var user = _userRepo.getUser(uid);
            return user;
        }

        public List<Book> getFavoriteBooks(string uid) {
            var books = _bookRepo.getAllBooks();
            var favBooks = (from fb in _favBookRepo.getAllFavBooks()
                                where fb.UserId == uid
                                join b in books
                                on fb.bookId equals b.Id
                                select b).ToList();
            return _convertService.bookListViewToEntity(favBooks);
        }

        public bool addFavoriteBook(string uid, int bid) {
            var bookExists = _bookRepo.getBook(bid).Count;
            if(bookExists == 0) {
                 return false;
            }
            var favBook = (from fb in _favBookRepo.getAllFavBooks()
                                    where uid == fb.UserId &&  bid == fb.bookId
                                    select fb).SingleOrDefault();
            if(favBook == null) {
                _favBookRepo.addFavoriteBook(new FavBook { UserId = uid, bookId = bid });
                return true;
            }
            removeFavBook(favBook);
            return false;
        }

        public void removeFavBook(FavBook fb) {
            _favBookRepo.removeFavBook(fb);
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
    }
}