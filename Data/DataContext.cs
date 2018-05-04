using Microsoft.EntityFrameworkCore;
using TheBookCave.Data.EntityModels;

namespace TheBookCave.Data {
    public class DataContext : DbContext {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // erum ad nota SQL fyrir gagnagrun
            optionsBuilder.UseSqlServer(
                // tengi stregnur, talvan sem gagnagrunnur er hýstur á (postnumer)
                "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H36;Persist Security Info=False;User ID=VLN2_2018_H36_usr;Password=funnyTurtl325;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }
    }
}