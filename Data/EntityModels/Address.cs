/*
    Address entity class
    Address2 not required 
 */
namespace TheBookCave.Data.EntityModels {
    public class Address {
        public int Id { get; set; }
        // Path to user entity class
         public string UserId { get; set; }
         // required address
        public string Address1 { get; set; }
        // not required address
        public string Address2 { get; set; }
        public string Region { get; set; }
        public int Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }


    }
}