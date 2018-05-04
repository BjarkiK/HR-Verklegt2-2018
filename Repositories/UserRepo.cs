using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class UserRepo {
        private DataContext _db;

        public UserRepo() {
            _db = new DataContext();
        }
        public List<UserListViewModel> getUser(string uid) {
            var user = (from u in _db.Users
                                where u.Id == uid
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
            return user;
        }
        public List<UserListViewModel> getAllUsers() {
            var users = (from u in _db.Users
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
            return users;
        }
        public bool updateUser(int uid) {
            // linq update
            return true;
        }
        public bool deleteUser(int uid) {
            // linq delete
            return true;
        }
        public bool createUser() {
            // linq insert
            return true;
        }
    }
}