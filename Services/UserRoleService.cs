using System.Collections.Generic;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;
using System.Linq;

namespace TheBookCave.Services {
    public class UserRoleService{
        private RoleRepo _roleRepo;
        private UserRoleRepo _userRoleRepo;
        public UserRoleService(){
            _roleRepo = new RoleRepo();
            _userRoleRepo = new UserRoleRepo();
        }

        public string getUsersRole(string uid) {
            var roleId = (from ur in _userRoleRepo.getAllUserRoles()
                                where uid == ur.UserId
                                select ur.RoleId).SingleOrDefault();

            var role = (from r in _roleRepo.getAllRoles()
                        where roleId ==  r.Id
                        select r.Name ).SingleOrDefault();
            return role;
        }
        public string getUserRoleIdFromName(string name) {
            var roles = _roleRepo.getAllRoles();
            var role = (from r in roles
                        where name == r.Name
                        select r.Name ).SingleOrDefault();
            return role;
        }
    }
}