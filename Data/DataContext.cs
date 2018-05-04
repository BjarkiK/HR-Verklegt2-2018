using Microsoft.EntityFrameworkCore;
using TheBookCave.Data.EntityModels;

namespace TheBookCave.Data {
    public class DataContext : DbContext {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<PaymentDetail> PaymentDetail { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PromoCodes> PromoCodes { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // erum ad nota SQL fyrir gagnagrun
            optionsBuilder.UseSqlServer(
                // tengi stregnur, talvan sem gagnagrunnur er hýstur á (postnumer)
                "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H36;Persist Security Info=False;User ID=VLN2_2018_H36_usr;Password=funnyTurtl325;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }
    }
}