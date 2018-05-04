using TheBookCave.Data.EntityModels;

namespace TheBookCave.Models.ViewModels {
    public class OrderItemViewModel {
        public int Id { get; set; }
        // Copy of book purched.
        public Book Book { get; set; }
        // Number of books of same type bought.
        public int Quantity { get; set; }
        // If there is any discount on this book.
        public int Discount { get; set; }
    }
}
