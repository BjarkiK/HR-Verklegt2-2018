using System;

namespace TheBookCave.Models.ViewModels {

    public class SubscriptionListViewModel {

        public int Id { get; set; }
        // type of sub in icelandic.
        public string TypeIn { get; set; }
        // type of sub in english.
        public string TypeEn { get; set; }
        public string DescriptionIn { get; set; }
        public string DescriptionEn { get; set; }
        // Is it published or not ? see statedigrama in design report.
        public bool Published { get; set; }

    }
}