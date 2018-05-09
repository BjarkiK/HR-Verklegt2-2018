using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using authentication_repo.Models;

namespace authentication_repo.Data
{
    public class AuthenticationDbContext : IdentityDbContext<ApplicationUser>{
        //smidur sendi beint base constructer
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }
    }
}