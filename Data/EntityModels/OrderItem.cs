namespace TheBookCave.Data.EntityModels {
    public class OrderItem {
        public int Id { get; set; }
        // Copy of book purched.
        public int BookId { get; set; }
        // Number of books of same type bought.
        public int Quantity { get; set; }
        // If there is any discount on this book.
        public int Discount { get; set; }
        // If of order this order item belongs to
        public int OrderId { get; set; }
    }
}