namespace TheBookCave.Data.EntityModels {
    public class OrderStatus {
        public int Id { get; set; }
        // The name of type in Icelandic.
        public string StatusIS { get; set; }
        // The name of type in English.
        public string StatusEN { get; set; }
        // Use to identify between type to use like orders and help
      //  public string TypeOfType { get; set; }

    }
}