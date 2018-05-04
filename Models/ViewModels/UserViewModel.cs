namespace TheBookCave.Models.ViewModels {
    public class UserViewModel {
        // ID email for each User.
        public string Id { get; set; } 
        // Id add for each User
        public int AddressId { get; set; }
         // UserName
        public string Name { get; set; }
        public string Picture {get; set; }
        public string Password { get; set; }
        // ID for favoriteBookId which User can only choose from database.
        public int FavoriteBookId {get; set; }
        // ID for User subscriptions in database.
        public int SubscriptionId { get; set; }
        // Id for User orders (are made instatly when user makes order).
        public int OrderId {get; set; }
        // bool, returns true if User is employee
        public bool Permission {get; set; }

    }
}