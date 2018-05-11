using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using TheBookCave.Data.EntityModels;
namespace TheBookCave.Models.ViewModels {
    public class BookDetailedListViewModel {
        // ISBN of book
        public int Id { get; set; }
        // The book title.
        [Required(ErrorMessage = "Can't be empty! Please enter a title")]
        public string Name { get; set; }
        // Path to book picture.
         public string Picture { get; set; }
        // Books Genre
        public string Genre { get; set; }
        // The author that wrote the book.
        public string Author { get; set; }
        // Books publisher
        public string Publisher { get; set; }
        //Price of book
        public double Price { get; set; }
        // Total number of user grades - To calculate the average grade
        public int NrOfGrades { get; set; }
        // Total user grades
        public double Grade { get; set; }

        public string DetailsIS { get; set; }
        // Book description in English.
        public string DetailsEN { get; set; }
        // If the book has any discount.
        public int Discount { get; set; }
        // Books page count.
        public int Pages { get; set; }
        // How many books are in stock.
        public int Quantity { get; set; }
        // Determains if the book is visible on the website or is
        // saved and unfinished.
        public bool Published { get; set; }

        public List <GenreListViewModel> Genres { get; set; }
        // The author that wrote the book.
        public List <AuthorListViewModel> Authors { get; set; }
        // Books publisher
        public List <PublisherListViewModel> Publishers { get; set; }

    }
}