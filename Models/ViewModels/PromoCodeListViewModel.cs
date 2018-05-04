namespace TheBookCave.Models.ViewModels {
    public class PromoCodesListViewModel {
        public int Id { get; set; }
        // How much discount this promo code gives.
        public int Discount { get; set; }
        // Discription af the promo code.
        public int Description { get; set; }
        // Determines if the promi code can be used or not.
        public int Published { get; set; }
    }
}