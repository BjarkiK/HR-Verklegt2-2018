using System;
using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class UserRoleRepo {
        private DataContext _db;

        public UserRoleRepo() {
            _db = new DataContext();
        }
        public string getUserRoleId(string uid) {
            var role = (from r in _db.AspNetUserRoles
                                where uid == r.UserId
                                select r.RoleId).SingleOrDefault();
            return role;
        }

        public bool updateUserRole(UserRole user) {
            _db.AspNetUserRoles.Update(user);
            _db.SaveChanges();
            return true;
        }
    }
}