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
    }
}