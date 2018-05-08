using TheBookCave.Data.EntityModels;

namespace TheBookCave.Models.ViewModels {
    public class ChartListViewModel {
        // Name of country.
        public Book Book { get; set; }
        public int  Quantity { get; set; }
    }
}