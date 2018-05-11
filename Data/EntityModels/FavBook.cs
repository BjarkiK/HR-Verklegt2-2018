using System;
namespace TheBookCave.Data.EntityModels {
    public class FavBook {
        public int Id { get; set; }
        public int bookId { get; set; }
        public string UserId { get; set; }
        
    }
}