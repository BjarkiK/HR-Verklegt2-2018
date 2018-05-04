using System;
namespace TheBookCave.Models.ViewModels {
    public class AuthorListViewModel {
        public int AuthorId { get; set; }
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