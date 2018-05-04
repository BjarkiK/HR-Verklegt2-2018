namespace TheBookCave.Data.EntityModels {
    public class Book {
        public int Id { get; set; }
        // The book title.
        public string Name { get; set; }
        // Path to book picture.
        public string Picture { get; set; }
        // Book description in Icelandic.
        public string DetailsIS { get; set; }
        // Book description in English.
        public string DetailsEN { get; set; }
        // Id of genre to be able to connect book to a certain category.
        public int GenreId { get; set; }
        // Id of author that wrote the book.
        public int AuthorId { get; set; }
        // Id of books publisher.
        public int PublisherId { get; set; }
        // The price of the book.
        public double price { get; set; }
        // If the book has any discount.
        public int Discount { get; set; }
        // Books page count.
        public int pages { get; set; }
        // How many books are in stock.
        public int quantity { get; set; }
        // The total user grade of book.
        public double grade { get; set; }
        // Determains if the book is visible on the website or is
        // saved and unfinished.
        public bool published { get; set; }

    }
}