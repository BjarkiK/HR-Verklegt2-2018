namespace TheBookCave.Data.EntityModels {
    public class Roles {
        public int Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        // path to Country that region represents.
        public string Name { get; set; }
        public string NormalizedName { get; set; }

    }
}