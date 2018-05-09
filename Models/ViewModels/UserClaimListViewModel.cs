namespace TheBookCave.Data.ViewModels {
    public class UserClaimsListViewModel {
        public int Id { get; set; }
        public string ClaimType  { get; set; }
        // path to Country that region represents.
        public string ClaimValue { get; set; }
        public string UserId { get; set; }

    }
}