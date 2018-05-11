using System;
using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class RoleRepo {
        private DataContext _db;

        public RoleRepo() {
            _db = new DataContext();
        }
        public Role getRole(string rId) {
            var role = (from r in _db.AspNetRoles
                            where r.Id == rId
                            select r).SingleOrDefault();
            return role;
        }
        public List<Role> getAllRoles() {
            var roles = (from r in _db.AspNetRoles
                            select r).ToList();
            return roles;
        }

    }
}