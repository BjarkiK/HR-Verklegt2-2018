using System.Collections.Generic;
using TheBookCave.Data.EntityModels;

namespace TheBookCave.Models.ViewModels {
    public class UserDetailedListViewModel {
        public User User { get; set; }
        public Role Role { get; set; }
        public List<Role> AllRoles { get; set; }
    }
}