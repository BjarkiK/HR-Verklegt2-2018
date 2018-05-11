using TheBookCave.Data.EntityModels;

namespace TheBookCave.Models.ViewModels {
    public class CartListViewModel {
        public Book Book { get; set; }
        public int  Quantity { get; set; }
        public double Sum { get; set; }
    }
}