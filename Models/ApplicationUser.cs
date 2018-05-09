
using Microsoft.AspNetCore.Identity;
// implement identityUser
namespace authentication_repo.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public int AddressId { get; set; }
        public int FavoriteBookId { get; set; }
    }
}