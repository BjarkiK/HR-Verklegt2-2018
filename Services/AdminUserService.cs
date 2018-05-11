using System;
using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class AdminUserService {
        private UserRepo _userRepo;
        private RoleRepo _roleRepo;
        private UserRoleRepo _userRoleRepo;
        
        private ConvertService _convertService;

        public AdminUserService() {
            _userRepo = new UserRepo();
            _roleRepo = new RoleRepo();
            _userRoleRepo = new UserRoleRepo();
            _convertService = new ConvertService();
        }

        public void removeUser(UserListViewModel u) {
            var user = convertUserListViewModelToUser(u);
            var successfull = _userRepo.removeUser(user);
        }
        
        private User convertUserListViewModelToUser(UserListViewModel u) {
            var user = new User {
                                PasswordHash = u.PasswordHash,
                                AccessFailedCount = u.AccessFailedCount,
                                ConcurrencyStamp = u.ConcurrencyStamp,
                                Email = u.Email,
                                EmailConfirmed = u.EmailConfirmed,
                                LockoutEnd = u.LockoutEnd,
                                LockoutEnabled = u.LockoutEnabled,
                                NormalizedEmail = u.NormalizedEmail,
                                NormalizedUserName = u.NormalizedUserName,
                  
                                };
            return user;
        }





        public List<UserListViewModel> getAllUsers() {
            var users = _userRepo.getAllUsers();

            return users;
        }
        

        
        public UserDetailedListViewModel getUpdateUser(string uid) {
            var user = _convertService.userViewToEntity(_userRepo.getUser(uid).First());
            var userRoleId = (from ur in _userRoleRepo.getAllUserRoles()
                                where uid == ur.UserId
                                select ur.RoleId).SingleOrDefault();
            var roles = _roleRepo.getAllRoles();
            var role = (from r in roles
                        where userRoleId == r.Id
                        select r ).SingleOrDefault();

            var userDetail = new UserDetailedListViewModel { User = user, AllRoles = roles, Role = role };
            return userDetail;

        }

        public void updateUser(UserDetailedListViewModel detailedUser) {
            var successfullUser = _userRepo.updateUser(detailedUser.User);
            var newRole = detailedUser.Role.Name;
            var newRoleId = "";
            foreach(var r in detailedUser.AllRoles) {
                if(r.Name == newRole) {
                    newRoleId = r.Id;
                    break;
                }
            }
            var userRoler = new UserRole{ UserId = detailedUser.User.Id, RoleId = newRoleId};
            var successfullUserRole = _userRoleRepo.updateUserRole(userRoler);
            
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