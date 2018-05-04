namespace TheBookCave.Models.ViewModels {
    public class HelpListViewModel {
        public int Id { get; set; }
        // The genre of help (login transaction, profile...).
        public int GenreId { get; set; }
        // What help question is being answared.
        public string Question { get; set; }
        // Question answer in Icelandic.
        public int AnswerIS { get; set; }
        // Question answer in English.
        public int AnswerEN { get; set; }

    }
}