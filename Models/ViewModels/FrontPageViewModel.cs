using System.Collections.Generic;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Models.ViewModels {
    public class FrontPageViewModel {
        public List<BookDetailedListViewModel> Top10 { get; set; }
        public List<BookDetailedListViewModel> Newest { get; set; }

    }
}