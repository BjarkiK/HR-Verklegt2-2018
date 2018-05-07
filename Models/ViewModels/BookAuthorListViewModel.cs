using System.ComponentModel.DataAnnotations;

namespace TheBookCave.Models.ViewModels {
    public class BookAuthorListViewModel {
        // ISBN of book
        public int Id { get; set; }
        // The book title.
        [Required(ErrorMessage = "Can't be empty! Please enter a title")]
        public string Name { get; set; }
        // Path to book picture.
        public string Picture { get; set; }
        // The author that wrote the book.
        public string Author { get; set; }
        public double Price { get; set; }
        // If the book has any discount.
        public double Grade { get; set; }

    }
}