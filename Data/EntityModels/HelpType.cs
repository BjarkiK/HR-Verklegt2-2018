namespace TheBookCave.Data.EntityModels {
    public class HelpType {
        public int Id { get; set; }
        // The name of type in Icelandic.
        public string TypeIS { get; set; }
        // The name of type in English.
        public string TypeEN { get; set; }
        // Use to identify between type to use like orders and help
      //  public string TypeOfType { get; set; }

    }
}