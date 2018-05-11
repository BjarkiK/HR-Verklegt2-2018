/*
    We are not going to translate country just yet.
 */
namespace TheBookCave.Data.EntityModels {
    public class Country {
        public int Id { get; set; }
        // Name of country.
        public string Name { get; set; }
        // Country code. Example code for Iceland : IS.
        public string CountryCode { get; set; }
    }
}