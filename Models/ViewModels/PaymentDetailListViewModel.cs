using System;
using System.ComponentModel.DataAnnotations;
namespace TheBookCave.Models.ViewModels {
    public class PaymentDetailListViewModel {
        public int Id { get; set; }
        // Id of user owning this payment detail.
        public string UserId { get; set; }
        // Id of address linked tho this payment detail.
        public int AddressId { get; set; }
        // Name printed on the card.
        public string NameOnCard { get; set; }
        // Cards expiry date.
        public string ExpiryDate { get; set; }
        // Card number printed on card.
        public string CardNumber { get; set; }
        // The CVC printed on back of card.
        public string CVC { get; set; }

    }
}