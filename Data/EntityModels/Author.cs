using System;
namespace TheBookCave.Data.EntityModels {
    public class Author {
        public int Id { get; set; }
        // Authors  full name.
        public string Name { get; set; }
        // Authors date of birth.
        public DateTime DateOfBirth { get; set; }
        // Authors description in Icelandic.
        public string DescriptionIS { get; set; }
        // Authors description in English.
        public string DescriptionEN { get; set; }
    }
}