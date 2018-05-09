using Microsoft.EntityFrameworkCore;
using TheBookCave.Data.EntityModels;

namespace TheBookCave.Data {
    public class DataContext : DbContext {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<HelpType> HelpType {get; set; }
        public DbSet<OrderStatus> OrderStatus {get; set; }
        public DbSet<User> AspNetUsers { get; set;}
        public DbSet<Roles> AspNetRoles { get; set;}
     
        public DbSet<UserClaims> AspNetClaims { get; set;}
         public DbSet<UserRoles> AspNetUserRoles { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // erum ad nota SQL fyrir gagnagrun
            optionsBuilder.UseSqlServer(
                // tengi stregnur, talvan sem gagnagrunnur er hýstur á (postnumer)
                "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H36;Persist Security Info=False;User ID=VLN2_2018_H36_usr;Password=funnyTurtl325;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }
    }
}