using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class UserRepo {
        private DataContext _db;

        public UserRepo() {
            _db = new DataContext();
        }
       
        public List<UserListViewModel> getUser(string uid) {
            var user = (from u in _db.AspNetUsers
                                where u.Id == uid
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
            return user;
        }
        public List<UserListViewModel> getAllUsers() {
            var users = (from u in _db.AspNetUsers
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
            return users;
        }
       
        public bool deleteUser(int uid) {
            // linq delete
            return true;
        }
        public bool createUser(User user) {
            _db.AspNetUsers.Add(user);
            _db.SaveChanges();
            return true;
        }
          public bool updateUser(User user) {
            _db.AspNetUsers.Update(user);
            _db.SaveChanges();
            return true;
        }
    }
}