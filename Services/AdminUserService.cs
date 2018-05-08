using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class AdminUserService {
        private UserRepo _userRepo;

        public AdminUserService() {
            _userRepo = new UserRepo();
        }

         public List<UserListViewModel> getUser(string oid) {
            var order = _userRepo.getUser(oid);

            return order;
        }

        public List<UserListViewModel> getAllUsers() {
            var users = _userRepo.getAllUsers();

            return users;
        }
        public void updateUser(UserListViewModel u) {
            var user = ConvertUserListViewModelToUser(u);
            var successfull = _userRepo.updateUser(user);
        }

        public void CreateUser(UserListViewModel u) {
            var user = ConvertUserListViewModelToUser(u);
            var successfull = _userRepo.createUser(user);
        }

        private User ConvertUserListViewModelToUser(UserListViewModel u) {
            var user = new User {
                                Id = u.Id,
                                AddressId = u.AddressId,
                                FavoriteBookId = u.FavoriteBookId,
                                Name = u.Name,
                                OrderId = u.OrderId,
                                Password = u.Password,
                                Permission = u.Permission,
                                Picture = u.Picture,
                                SubscriptionId = u.SubscriptionId                         
                                };
            return user;
        }

         public List<UserListViewModel> getSearchResult(string searchString) {
            var users = _userRepo.getAllUsers();
            var searchResult = (from u in users
                        where u.Id.ToLower().Contains(searchString.ToLower())
                        select new UserListViewModel {
                                Id = u.Id,
                                AddressId = u.AddressId,
                                FavoriteBookId = u.FavoriteBookId,
                                Name = u.Name,
                                OrderId = u.OrderId,
                                Password = u.Password,
                                Permission = u.Permission,
                                Picture = u.Picture,
                                SubscriptionId = u.SubscriptionId
                        }).ToList();

            return searchResult;
        }
    }
}