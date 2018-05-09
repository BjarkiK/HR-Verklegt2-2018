using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class AdminUserService {
        private UserRepo _userRepo;
        private ConvertService _convertService;

        public AdminUserService() {
            _userRepo = new UserRepo();
             _convertService = new ConvertService();
        }

         public UserListViewModel getUser(string uid) {
            var user = _userRepo.getUser(uid).First();
            return user;
        }

        public List<UserListViewModel> getAllUsers() {
            var users = _userRepo.getAllUsers();

            return users;
        }
        public void updateUser(UserListViewModel u) {
            var user = _convertService.userViewToEntity(u);
            var successfull = _userRepo.updateUser(user);
        }

        public void createUser(UserListViewModel u) {
            var user = _convertService.userViewToEntity(u);
            var successfull = _userRepo.createUser(user);
        }


         public List<UserListViewModel> getSearchResult(string searchString) {
            var users = _userRepo.getAllUsers();
            var searchResult = (from u in users
                        where u.Email.ToLower().Contains(searchString.ToLower())
                        select new UserListViewModel {
                                Id = u.Id,
                                AccessFailedCount = u.AccessFailedCount,
                                ConcurrencyStamp = u.ConcurrencyStamp,
                                Email = u.Email,
                                EmailConfirmed = u.EmailConfirmed,
                                LockoutEnd = u.LockoutEnd,
                                LockoutEnabled = u.LockoutEnabled,
                                NormalizedEmail = u.NormalizedEmail,
                                NormalizedUserName = u.NormalizedUserName,
                                PasswordHash = u.PasswordHash,
                                PhoneNumber = u.PhoneNumber,
                                PhoneNumberConfirmed = u.PhoneNumberConfirmed,
                                SecurityStamp = u.SecurityStamp,
                                TwoFactorEnabled = u.TwoFactorEnabled,
                                UserName = u.UserName
                        }).ToList();

            return searchResult;
        }
    }
}