using System;
namespace TheBookCave.Data.EntityModels {
    public class UserReview {
        public int Id { get; set; }
        // Id of the user that wrote the review.
        public string UserId { get; set; }
        // Id of the book the review referes to.
        public int BookId { get; set; }
        // Date when review was written.
        public DateTime Date { get; set; }
        // The grad user gives the book.
        public double Grade { get; set; }
        // Written review user gives book.
        public string Review { get; set; }

    }
}