using System.Collections.Generic;
using TheBookCave.Data.EntityModels;

namespace TheBookCave.Models.ViewModels {

        public class BookEditView {

            public string Name { get; set; }
            public double Price { get; set; }
            public string Picture {get; set; }
            public string DetailsIS {get; set; }
            public string DetailsEN {get; set; }
            public int Discount {get; set; }
            public int Quantity {get; set; }
            public int Pages {get; set; }
            public List<Author> Authors { get; set; }
            public List<Genre> Genre { get; set; }
            public List<Publisher> Publishers { get; set; }
            public bool Published { get; set; }
    }
}
