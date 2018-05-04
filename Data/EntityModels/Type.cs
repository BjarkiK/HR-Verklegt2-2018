namespace TheBookCave.Data.EntityModels {
    public class Type {
        public int Id { get; set; }
        // The name of genre in Icelandic.
        public string TypeIs { get; set; }
        // The name of genre in English.
        public string TypeEn { get; set; }
        // Use to identify between type to use like orders and help
        public string TypeOfType { get; set; }

    }
}